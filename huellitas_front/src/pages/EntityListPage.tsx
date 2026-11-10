import { useMemo, useState } from 'react'
import {
  DataGrid,
  type GridColDef,
  type GridRenderCellParams,
} from '@mui/x-data-grid'
import { Download, Eye, FileDown, Filter, Pencil, Plus, Search, Trash2 } from 'lucide-react'
import { Link, useNavigate, useParams } from 'react-router-dom'
import Swal from 'sweetalert2'
import { entities } from '../constants/entities.generated'
import { useEntityList, useEntityMutations } from '../hooks/useEntities'
import type { EntityRecord } from '../interfaces/entity'
import {
  formatValue,
  getApiErrorMessage,
  getEntityFieldValue,
  getRecordLabel,
} from '../utils/format'
import { ErrorState, LoadingState } from '../components/LoadingState'

function statusClass(value: unknown): string {
  const status = String(value ?? '').toLocaleLowerCase('es')
  if (['cancelada', 'inactivo', 'inactiva', 'vencido', 'bloqueado', 'perdido'].some((word) => status.includes(word))) {
    return 'danger'
  }
  if (['pendiente', 'en proceso', 'hospitalizado', 'bajo'].some((word) => status.includes(word))) {
    return 'warning'
  }
  if (['activo', 'activa', 'confirmada', 'completado', 'pagado'].some((word) => status.includes(word))) {
    return ''
  }
  return 'neutral'
}

export function EntityListPage() {
  const { module = '' } = useParams()
  const navigate = useNavigate()
  const entity = entities.find((item) => item.key === module)
  const query = useEntityList(module, Boolean(entity))
  const mutations = useEntityMutations(module)
  const [search, setSearch] = useState('')
  const [filterOpen, setFilterOpen] = useState(false)
  const [filterField, setFilterField] = useState('')
  const [filterText, setFilterText] = useState('')
  const [statusFilter, setStatusFilter] = useState('')
  const [actionError, setActionError] = useState<string>()

  const rows = useMemo(() => query.data ?? [], [query.data])
  const filteredRows = useMemo(() => {
    const normalizedSearch = search.trim().toLocaleLowerCase('es')
    const normalizedFilter = filterText.trim().toLocaleLowerCase('es')
    return rows.filter((row) => {
      const matchesSearch =
        !normalizedSearch ||
        entity?.fields.some((field) =>
          field.name !== entity.idField &&
          formatValue(getEntityFieldValue(row, field.name, entity))
            .toLocaleLowerCase('es')
            .includes(normalizedSearch),
        )
      const matchesField =
        !filterField ||
        !normalizedFilter ||
        formatValue(getEntityFieldValue(row, filterField, entity!))
          .toLocaleLowerCase('es')
          .includes(normalizedFilter)
      const status = row.estado ?? row.status
      const matchesStatus =
        !statusFilter ||
        String(status ?? '').toLocaleLowerCase('es') ===
          statusFilter.toLocaleLowerCase('es')
      return matchesSearch && matchesField && matchesStatus
    })
  }, [entity, filterField, filterText, rows, search, statusFilter])

  if (!entity) {
    return (
      <div className="empty-state">
        <div>
          <strong>Módulo no encontrado</strong>
          <p style={{ marginTop: 7 }}>Este recurso no está definido en el contrato de la API.</p>
          <Link className="button" to="/">Volver al resumen</Link>
        </div>
      </div>
    )
  }

  if (query.isLoading) return <LoadingState rows={6} />
  if (query.isError) {
    return (
      <ErrorState
        message={getApiErrorMessage(query.error)}
        onRetry={() => void query.refetch()}
      />
    )
  }

  const statusValues = [
    ...new Set(
      rows
        .map((row) => row.estado ?? row.status)
        .filter((value): value is string => typeof value === 'string' && value.length > 0),
    ),
  ]
  const tableColumns = entity.columns.filter(
    (fieldName) => fieldName !== entity.idField,
  )

  const removeRecord = async (row: EntityRecord) => {
    const result = await Swal.fire({
      icon: 'warning',
      title: '¿Eliminar este registro?',
      text: `Se eliminará ${getRecordLabel(row, entity)}. Esta acción no se puede deshacer.`,
      showCancelButton: true,
      confirmButtonText: 'Eliminar',
      cancelButtonText: 'Cancelar',
      confirmButtonColor: '#c5584a',
    })
    if (!result.isConfirmed || row.id === undefined) return

    try {
      await mutations.remove.mutateAsync(String(row.id))
      setActionError(undefined)
      await Swal.fire({
        icon: 'success',
        title: 'Registro eliminado',
        timer: 1500,
        showConfirmButton: false,
      })
    } catch (error) {
      setActionError(getApiErrorMessage(error))
    }
  }

  const exportRows = () =>
    filteredRows.map((row) =>
      Object.fromEntries(
        tableColumns.map((fieldName) => {
          const field = entity.fields.find((item) => item.name === fieldName)
          return [
            field?.label ?? fieldName,
            formatValue(getEntityFieldValue(row, fieldName, entity)),
          ]
        }),
      ),
    )

  const exportExcel = async () => {
    try {
      const { default: ExcelJS } = await import('exceljs')
      const workbook = new ExcelJS.Workbook()
      const worksheet = workbook.addWorksheet(entity.label.slice(0, 31))
      const headers = tableColumns.map(
        (fieldName) =>
          entity.fields.find((field) => field.name === fieldName)?.label ??
          fieldName,
      )
      worksheet.columns = headers.map((header, index) => ({
        header,
        key: `column${index}`,
        width: Math.min(Math.max(header.length + 4, 15), 34),
      }))
      exportRows().forEach((row) =>
        worksheet.addRow(
          Object.values(row).reduce<Record<string, string>>(
            (values, value, index) => {
              values[`column${index}`] = value
              return values
            },
            {},
          ),
        ),
      )
      worksheet.getRow(1).font = { bold: true, color: { argb: 'FFFFFFFF' } }
      worksheet.getRow(1).fill = {
        type: 'pattern',
        pattern: 'solid',
        fgColor: { argb: 'FF23876C' },
      }
      const buffer = await workbook.xlsx.writeBuffer()
      const file = new Blob([buffer], {
        type: 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet',
      })
      const link = document.createElement('a')
      const fileUrl = URL.createObjectURL(file)
      link.href = fileUrl
      link.download = `${entity.key.toLocaleLowerCase('es')}.xlsx`
      link.click()
      window.setTimeout(() => URL.revokeObjectURL(fileUrl), 1000)
    } catch (error) {
      await Swal.fire({
        icon: 'error',
        title: 'No se pudo exportar a Excel',
        text: getApiErrorMessage(error),
      })
    }
  }

  const exportPdf = async () => {
    try {
      const [{ default: JsPDF }, { default: autoTable }] = await Promise.all([
        import('jspdf'),
        import('jspdf-autotable'),
      ])
      const document = new JsPDF({ orientation: 'landscape' })
      const fields = tableColumns.map((fieldName) =>
        entity.fields.find((item) => item.name === fieldName),
      )
      document.setFontSize(16)
      document.text(entity.label, 14, 16)
      document.setFontSize(9)
      document.text(
        `Exportado el ${new Intl.DateTimeFormat('es-MX', { dateStyle: 'long' }).format(new Date())}`,
        14,
        22,
      )
      autoTable(document, {
        startY: 28,
        head: [fields.map((field, index) => field?.label ?? tableColumns[index])],
        body: filteredRows.map((row) =>
          tableColumns.map((fieldName) =>
            formatValue(getEntityFieldValue(row, fieldName, entity)),
          ),
        ),
        styles: { fontSize: 8, cellPadding: 3 },
        headStyles: { fillColor: [35, 135, 108] },
      })
      document.save(`${entity.key.toLocaleLowerCase('es')}.pdf`)
    } catch (error) {
      await Swal.fire({
        icon: 'error',
        title: 'No se pudo exportar a PDF',
        text: getApiErrorMessage(error),
      })
    }
  }

  const columns: GridColDef<EntityRecord>[] = tableColumns
    .map((fieldName) => {
      const field = entity.fields.find((item) => item.name === fieldName)
      return {
        field: fieldName,
        headerName: field?.label ?? fieldName,
        flex: fieldName === entity.displayField ? 1.4 : 1,
        minWidth: field?.type === 'object' ? 140 : 120,
        sortable: true,
        filterable: true,
        valueGetter: (_value, row) => {
          const value = getEntityFieldValue(row, fieldName, entity)
          if (value && typeof value === 'object') {
            return getRecordLabel(value as EntityRecord)
          }
          return value
        },
        renderCell: (params: GridRenderCellParams<EntityRecord>) => {
          const value = getEntityFieldValue(params.row, fieldName, entity)
          if (fieldName === 'estado' || fieldName === 'status') {
            return (
              <span className={`status-pill ${statusClass(value)}`}>
                {formatValue(value)}
              </span>
            )
          }
          return (
            <span title={formatValue(value)} style={{ overflow: 'hidden', textOverflow: 'ellipsis' }}>
              {formatValue(value)}
            </span>
          )
        },
      }
    })
  columns.push({
    field: '__actions',
    headerName: 'Acciones',
    sortable: false,
    filterable: false,
    minWidth: 116,
    align: 'right',
    headerAlign: 'right',
    renderCell: (params: GridRenderCellParams<EntityRecord>) => (
      <div className="row-actions">
        <button
          className="row-action"
          type="button"
          aria-label="Ver detalle"
          title="Ver detalle"
          onClick={() => navigate(`/${entity.key}/${encodeURIComponent(String(params.row.id))}`)}
        >
          <Eye size={15} />
        </button>
        <button
          className="row-action"
          type="button"
          aria-label="Editar registro"
          title="Editar registro"
          onClick={() => navigate(`/${entity.key}/${encodeURIComponent(String(params.row.id))}/edit`)}
        >
          <Pencil size={14} />
        </button>
        <button
          className="row-action delete"
          type="button"
          aria-label="Eliminar registro"
          title="Eliminar registro"
          onClick={() => void removeRecord(params.row)}
          disabled={mutations.remove.isPending}
        >
          <Trash2 size={15} />
        </button>
      </div>
    ),
  })

  return (
    <>
      <div className="page-heading">
        <div>
          <div className="eyebrow">{entity.group}</div>
          <h1 className="page-title">{entity.label}</h1>
          <p className="page-subtitle">
            Administra y consulta los registros de {entity.label.toLocaleLowerCase('es')}.
          </p>
        </div>
        <Link className="button" to={`/${entity.key}/new`}>
          <Plus size={16} />
          Nuevo registro
        </Link>
      </div>

      <section className="table-card">
        {actionError && (
          <div className="error-state" role="alert" style={{ minHeight: 55 }}>
            {actionError}
          </div>
        )}
        <div
          className="table-toolbar"
          style={{
            minHeight: 68,
            justifyContent: 'space-between',
            flexWrap: 'wrap',
            padding: '12px 16px',
            borderBottom: '1px solid var(--line)',
          }}
        >
          <div className="table-toolbar">
            <div className="search-wrap">
              <Search size={15} />
              <input
                className="search-field"
                type="search"
                placeholder="Buscar en los registros…"
                value={search}
                onChange={(event) => setSearch(event.target.value)}
                aria-label="Buscar registros"
              />
            </div>
            {statusValues.length > 0 && (
              <select
                className="filter-select"
                value={statusFilter}
                onChange={(event) => setStatusFilter(event.target.value)}
                aria-label="Filtrar por estado"
              >
                <option value="">Todos los estados</option>
                {statusValues.map((status) => (
                  <option key={status} value={status}>{status}</option>
                ))}
              </select>
            )}
            <button
              className="button secondary"
              type="button"
              onClick={() => setFilterOpen((value) => !value)}
              aria-expanded={filterOpen}
            >
              <Filter size={15} />
              Filtros
            </button>
          </div>
          <div className="table-toolbar">
            <button className="button secondary" type="button" onClick={() => void exportExcel()}>
              <Download size={15} />
              Excel
            </button>
            <button className="button secondary" type="button" onClick={() => void exportPdf()}>
              <FileDown size={15} />
              PDF
            </button>
          </div>
        </div>

        {filterOpen && (
          <div
            className="table-toolbar"
            style={{
              flexWrap: 'wrap',
              padding: '12px 16px',
              background: 'var(--surface-muted)',
              borderBottom: '1px solid var(--line)',
            }}
          >
            <span style={{ color: 'var(--muted)', fontSize: 11, fontWeight: 600 }}>
              Filtrar campo
            </span>
            <select
              className="filter-select"
              value={filterField}
              onChange={(event) => setFilterField(event.target.value)}
              aria-label="Campo a filtrar"
            >
              <option value="">Selecciona un campo</option>
              {entity.fields
                .filter((field) => field.type !== 'array' && field.name !== entity.idField)
                .map((field) => (
                  <option key={field.name} value={field.name}>{field.label}</option>
                ))}
            </select>
            <input
              className="search-field"
              type="search"
              placeholder="El valor contiene…"
              value={filterText}
              onChange={(event) => setFilterText(event.target.value)}
              aria-label="Texto del filtro"
            />
            <button
              className="button secondary"
              type="button"
              onClick={() => {
                setFilterField('')
                setFilterText('')
                setStatusFilter('')
              }}
            >
              Limpiar filtros
            </button>
          </div>
        )}

        <DataGrid
          autoHeight
          rows={filteredRows}
          columns={columns}
          getRowId={(row) => String(row[entity.idField] ?? '')}
          pageSizeOptions={[10, 25, 50, 100]}
          initialState={{
            pagination: { paginationModel: { page: 0, pageSize: 10 } },
            sorting: {
              sortModel: [
                {
                  field: tableColumns.includes(entity.displayField ?? '')
                    ? entity.displayField!
                    : tableColumns[0] ?? '',
                  sort: 'asc',
                },
              ],
            },
          }}
          disableRowSelectionOnClick
          localeText={{
            noRowsLabel: 'No hay registros para mostrar',
            footerRowSelected: (count) => `${count.toLocaleString()} seleccionados`,
            paginationRowsPerPage: 'Filas por página',
            paginationDisplayedRows: ({ from, to, count }) =>
                `${from}–${to} de ${count !== -1 ? count : `más de ${to}`}`,
            columnMenuSortAsc: 'Orden ascendente',
            columnMenuSortDesc: 'Orden descendente',
            columnMenuFilter: 'Filtrar',
            columnMenuHideColumn: 'Ocultar columna',
            columnMenuManageColumns: 'Administrar columnas',
          }}
          sx={{
            minHeight: 300,
            border: 0,
            backgroundColor: 'var(--surface)',
            color: 'var(--ink)',
            '& .MuiDataGrid-columnHeaders': { backgroundColor: 'var(--surface-muted)' },
            '& .MuiDataGrid-cell': { borderColor: 'var(--line)' },
            '& .MuiTablePagination-root': { color: 'var(--muted)' },
          }}
        />
      </section>
    </>
  )
}
