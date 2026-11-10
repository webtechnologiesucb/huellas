import {
  Activity,
  CalendarDays,
  ClipboardList,
  Package,
  PawPrint,
  Users,
} from 'lucide-react'
import {
  Bar,
  BarChart,
  CartesianGrid,
  Cell,
  Pie,
  PieChart,
  ResponsiveContainer,
  Tooltip,
  XAxis,
  YAxis,
} from 'recharts'
import { Link } from 'react-router-dom'
import { useQueries } from '@tanstack/react-query'
import { entities } from '../constants/entities.generated'
import { entityKeys } from '../hooks/useEntities'
import type { EntityRecord } from '../interfaces/entity'
import { entityService } from '../services/entityService'
import { formatValue, getRecordLabel } from '../utils/format'
import { LoadingState } from '../components/LoadingState'

const chartColors = ['#23876c', '#e89b63', '#80b79b', '#a8cfb4', '#d2e8d8', '#78a99e']
const criticalModules = [
  { key: 'Mascotas', label: 'Mascotas', Icon: PawPrint },
  { key: 'Citas', label: 'Citas', Icon: CalendarDays },
  { key: 'Productos', label: 'Productos', Icon: Package },
  { key: 'Usuarios', label: 'Usuarios', Icon: Users },
]

function isRecord(value: unknown): value is Record<string, unknown> {
  return typeof value === 'object' && value !== null
}

export function DashboardPage() {
  const results = useQueries({
    queries: entities.map((entity) => ({
      queryKey: entityKeys.list(entity.key),
      queryFn: () => entityService.list<EntityRecord>(entity),
      staleTime: 5 * 60_000,
    })),
  })
  const isLoading = results.every((query) => query.isLoading)
  const records = results.map((query) => query.data ?? [])
  const loadedTotal = records.reduce((sum, list) => sum + list.length, 0)
  const totalErrors = results.filter((query) => query.isError).length
  const getEntityRecords = (key: string) => {
    const index = entities.findIndex((entity) => entity.key === key)
    return index >= 0 ? records[index] ?? [] : []
  }
  const metrics = criticalModules.map(({ key, label, Icon }) => {
    const index = entities.findIndex((entity) => entity.key === key)
    const result = results[index]
    return {
      label,
      count: result?.isError ? '—' : (result?.data?.length ?? 0),
      Icon,
      note: result?.isError ? 'No disponible' : 'Registros activos',
    }
  })
  const modules = entities
    .map((entity, index) => ({
      name: entity.label,
      count: records[index]?.length ?? 0,
      failed: results[index]?.isError ?? false,
    }))
    .filter((entity) => !entity.failed)
    .sort((left, right) => right.count - left.count)
    .slice(0, 7)
  const recent = records
    .flatMap((list, index) =>
      list.map((record) => ({ record, entity: entities[index] })),
    )
    .sort((left, right) => {
      const leftDate = String(left.record.createdAt ?? '')
      const rightDate = String(right.record.createdAt ?? '')
      return rightDate.localeCompare(leftDate)
    })
    .slice(0, 5)
  const speciesDistribution = getEntityRecords('Mascotas').reduce<
    { name: string; value: number }[]
  >((accumulator, pet) => {
    const breed = pet.raza
    const species = isRecord(breed) ? breed.especie : undefined
    const name =
      isRecord(species) && 'nombre' in species
        ? String(species.nombre)
        : 'Sin especie'
    const item = accumulator.find((entry) => entry.name === name)
    if (item) item.value += 1
    else accumulator.push({ name, value: 1 })
    return accumulator
  }, [])

  if (isLoading) return <LoadingState rows={6} />

  return (
    <>
      <div className="page-heading">
        <div>
          <div className="eyebrow">
            {new Intl.DateTimeFormat('es-MX', {
              weekday: 'long',
              year: 'numeric',
              month: 'long',
              day: 'numeric',
            }).format(new Date())}
          </div>
          <h1 className="page-title">Resumen general</h1>
          <p className="page-subtitle">
            Así va la operación de tu clínica veterinaria.
            {totalErrors > 0 && ` ${totalErrors} módulos no respondieron.`}
          </p>
        </div>
        <Link className="button" to="/Citas/new">
          <CalendarDays size={16} />
          Nueva cita
        </Link>
      </div>

      <section className="stats-grid" aria-label="Indicadores principales">
        {metrics.map(({ label, count, Icon, note }) => (
          <article className="stat-card" key={label}>
            <div className="stat-top">
              <span>{label}</span>
              <span className="stat-icon">
                <Icon size={17} />
              </span>
            </div>
            <div className="stat-value">{count}</div>
            <div className="stat-footnote">{note}</div>
          </article>
        ))}
      </section>

      <section className="stats-grid" aria-label="Actividad del sistema">
        <article className="stat-card">
          <div className="stat-top">
            <span>Registros en la plataforma</span>
            <span className="stat-icon"><ClipboardList size={17} /></span>
          </div>
          <div className="stat-value">{loadedTotal.toLocaleString('es-MX')}</div>
          <div className="stat-footnote">En {entities.length} módulos</div>
        </article>
        <article className="stat-card">
          <div className="stat-top">
            <span>Servicios disponibles</span>
            <span className="stat-icon"><Activity size={17} /></span>
          </div>
          <div className="stat-value">
            {getEntityRecords('Servicios').length.toLocaleString('es-MX')}
          </div>
          <div className="stat-footnote">Catálogo de atención</div>
        </article>
        <article className="stat-card">
          <div className="stat-top">
            <span>Especies registradas</span>
            <span className="stat-icon"><PawPrint size={17} /></span>
          </div>
          <div className="stat-value">
            {getEntityRecords('Especies').length.toLocaleString('es-MX')}
          </div>
          <div className="stat-footnote">En el catálogo clínico</div>
        </article>
        <article className="stat-card">
          <div className="stat-top">
            <span>Conexión API</span>
            <span className="stat-icon"><Activity size={17} /></span>
          </div>
          <div className="stat-value" style={{ fontSize: 20 }}>
            {totalErrors === 0 ? 'Operativa' : 'Parcial'}
          </div>
          <div className="stat-footnote">
            {totalErrors === 0 ? 'Todos los módulos responden' : `${totalErrors} módulos sin conexión`}
          </div>
        </article>
      </section>

      <section className="dashboard-grid">
        <article className="panel">
          <div className="panel-header">
            <div>
              <h2 className="panel-title">Actividad por módulo</h2>
              <div className="panel-caption">Volumen de registros disponibles</div>
            </div>
          </div>
          <div className="chart-wrap">
            {modules.length > 0 ? (
              <ResponsiveContainer width="100%" height="100%">
                <BarChart data={modules} margin={{ top: 8, right: 6, left: -20, bottom: 30 }}>
                  <CartesianGrid stroke="var(--line)" strokeDasharray="3 3" vertical={false} />
                  <XAxis
                    dataKey="name"
                    tick={{ fill: 'var(--muted)', fontSize: 9 }}
                    angle={-28}
                    textAnchor="end"
                    interval={0}
                  />
                  <YAxis tick={{ fill: 'var(--muted)', fontSize: 10 }} allowDecimals={false} />
                  <Tooltip
                    contentStyle={{
                      background: 'var(--surface)',
                      border: '1px solid var(--line)',
                      borderRadius: 9,
                      color: 'var(--ink)',
                      fontSize: 11,
                    }}
                  />
                  <Bar dataKey="count" name="Registros" fill="#23876c" radius={[5, 5, 0, 0]} />
                </BarChart>
              </ResponsiveContainer>
            ) : (
              <div className="empty-state">No hay datos disponibles para mostrar.</div>
            )}
          </div>
        </article>

        <article className="panel">
          <div className="panel-header">
            <div>
              <h2 className="panel-title">Mascotas por especie</h2>
              <div className="panel-caption">Distribución del padrón de mascotas</div>
            </div>
          </div>
          <div className="chart-wrap">
            {speciesDistribution.some((item) => item.value > 0) ? (
              <ResponsiveContainer width="100%" height="100%">
                <PieChart>
                  <Pie
                    data={speciesDistribution}
                    dataKey="value"
                    nameKey="name"
                    innerRadius={58}
                    outerRadius={88}
                    paddingAngle={4}
                    stroke="none"
                  >
                    {speciesDistribution.map((item, index) => (
                      <Cell key={item.name} fill={chartColors[index % chartColors.length]} />
                    ))}
                  </Pie>
                  <Tooltip
                    contentStyle={{
                      background: 'var(--surface)',
                      border: '1px solid var(--line)',
                      borderRadius: 9,
                      color: 'var(--ink)',
                      fontSize: 11,
                    }}
                  />
                </PieChart>
              </ResponsiveContainer>
            ) : (
              <div className="empty-state">Aún no hay mascotas registradas.</div>
            )}
          </div>
          {speciesDistribution.length > 0 && (
            <div style={{ display: 'flex', flexWrap: 'wrap', gap: 12, justifyContent: 'center' }}>
              {speciesDistribution.map((item, index) => (
                <span key={item.name} style={{ color: 'var(--muted)', fontSize: 10 }}>
                  <span
                    style={{
                      display: 'inline-block',
                      width: 8,
                      height: 8,
                      marginRight: 6,
                      background: chartColors[index % chartColors.length],
                      borderRadius: '50%',
                    }}
                  />
                  {item.name} · {item.value}
                </span>
              ))}
            </div>
          )}
        </article>
      </section>

      <section className="panel" style={{ marginTop: 18 }}>
        <div className="panel-header">
          <div>
            <h2 className="panel-title">Registros por módulo</h2>
            <div className="panel-caption">
              Conteo de los {entities.length} recursos conectados a la API
            </div>
          </div>
        </div>
        <div
          style={{
            display: 'grid',
            gridTemplateColumns: 'repeat(auto-fit, minmax(190px, 1fr))',
            gap: 8,
          }}
        >
          {entities.map((entity, index) => {
            const query = results[index]
            return (
              <Link
                key={entity.key}
                to={`/${entity.key}`}
                style={{
                  display: 'flex',
                  alignItems: 'center',
                  justifyContent: 'space-between',
                  gap: 10,
                  padding: '10px 12px',
                  background: 'var(--surface-muted)',
                  borderRadius: 9,
                }}
              >
                <span style={{ overflow: 'hidden', color: 'var(--muted)', fontSize: 11, textOverflow: 'ellipsis', whiteSpace: 'nowrap' }}>
                  {entity.label}
                </span>
                <strong style={{ flex: '0 0 auto', fontSize: 12 }}>
                  {query?.isError ? '—' : (query?.data?.length ?? 0)}
                </strong>
              </Link>
            )
          })}
        </div>
      </section>

      <section className="panel" style={{ marginTop: 18 }}>
        <div className="panel-header">
          <div>
            <h2 className="panel-title">Actividad reciente</h2>
            <div className="panel-caption">Últimos registros de tus módulos</div>
          </div>
          <Link className="button secondary" to="/Mascotas">
            Ver módulos
          </Link>
        </div>
        {recent.length > 0 ? (
          <div style={{ display: 'grid', gap: 8 }}>
            {recent.map(({ record, entity }, index) => (
              <Link
                key={`${entity.key}-${String(record.id ?? index)}`}
                to={`/${entity.key}/${encodeURIComponent(String(record.id))}`}
                style={{
                  display: 'flex',
                  alignItems: 'center',
                  justifyContent: 'space-between',
                  gap: 12,
                  padding: '10px 12px',
                  background: 'var(--surface-muted)',
                  borderRadius: 9,
                }}
              >
                <span style={{ display: 'flex', minWidth: 0, alignItems: 'center', gap: 11 }}>
                  <span className="stat-icon" style={{ width: 31, height: 31 }}>
                    <ClipboardList size={15} />
                  </span>
                  <span style={{ minWidth: 0 }}>
                    <strong style={{ display: 'block', overflow: 'hidden', fontSize: 11, textOverflow: 'ellipsis', whiteSpace: 'nowrap' }}>
                      {getRecordLabel(record, entity)}
                    </strong>
                    <span style={{ color: 'var(--muted)', fontSize: 10 }}>{entity.label}</span>
                  </span>
                </span>
                <span style={{ flex: '0 0 auto', color: 'var(--muted)', fontSize: 10 }}>
                  {formatValue(record.createdAt)}
                </span>
              </Link>
            ))}
          </div>
        ) : (
          <div className="empty-state">No hay registros recientes.</div>
        )}
      </section>
    </>
  )
}
