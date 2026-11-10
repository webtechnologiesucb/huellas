import { ArrowLeft, Pencil } from 'lucide-react'
import { Link, useNavigate, useParams } from 'react-router-dom'
import { ErrorState, LoadingState } from '../components/LoadingState'
import { entities } from '../constants/entities.generated'
import { useEntityRecord } from '../hooks/useEntities'
import {
  formatValue,
  getApiErrorMessage,
  getEntityFieldValue,
  getRecordLabel,
} from '../utils/format'

export function EntityDetailPage() {
  const { module = '', id = '' } = useParams()
  const navigate = useNavigate()
  const entity = entities.find((item) => item.key === module)
  const query = useEntityRecord(module, id)

  if (!entity) return <ErrorState message="El módulo solicitado no existe." />
  if (query.isLoading) return <LoadingState rows={5} />
  if (query.isError) {
    return (
      <ErrorState
        message={getApiErrorMessage(query.error)}
        onRetry={() => void query.refetch()}
      />
    )
  }
  const record = query.data
  if (!record) return <ErrorState message="No se encontró el registro solicitado." />

  const fields = entity.fields.filter(
    (field) => field.name !== 'id' && field.type !== 'array',
  )

  return (
    <>
      <div className="page-heading">
        <div>
          <div className="eyebrow">{entity.label}</div>
          <h1 className="page-title">{getRecordLabel(record, entity)}</h1>
          <p className="page-subtitle">Detalle del registro seleccionado.</p>
        </div>
        <div className="table-toolbar">
          <button
            className="button secondary"
            type="button"
            onClick={() => navigate(`/${entity.key}`)}
          >
            <ArrowLeft size={15} />
            Volver
          </button>
          <Link className="button" to={`/${entity.key}/${encodeURIComponent(id)}/edit`}>
            <Pencil size={15} />
            Editar
          </Link>
        </div>
      </div>

      <section className="detail-card">
        <div className="detail-grid">
          {fields.map((field) => {
            const value = getEntityFieldValue(record, field.name, entity)
            return (
              <div className="detail-item" key={field.name}>
                <div className="detail-label">{field.label}</div>
                <div className="detail-value">
                  {field.name === 'estado' || field.name === 'status' ? (
                    <span className="status-pill">{formatValue(value)}</span>
                  ) : (
                    formatValue(value)
                  )}
                </div>
              </div>
            )
          })}
        </div>
        {entity.fields.some((field) => field.type === 'array') && (
          <div style={{ marginTop: 22 }}>
            <h2 className="panel-title">Relaciones</h2>
            <div className="detail-grid" style={{ marginTop: 12 }}>
              {entity.fields
                .filter((field) => field.type === 'array')
                .map((field) => {
                  const relatedValue = record[field.name]
                  const relatedCount = Array.isArray(relatedValue)
                    ? relatedValue.length
                    : 0
                  return (
                    <div className="detail-item" key={field.name}>
                      <div className="detail-label">{field.label}</div>
                      <div className="detail-value">
                        {relatedCount.toLocaleString('es-MX')} registros
                      </div>
                    </div>
                  )
                })}
            </div>
          </div>
        )}
      </section>
    </>
  )
}
