import { entities, type EntityDefinition } from '../constants/entities.generated'
import type { EntityRecord } from '../interfaces/entity'

export function formatValue(value: unknown): string {
  if (value === null || value === undefined || value === '') return '—'
  if (typeof value === 'boolean') return value ? 'Sí' : 'No'
  if (typeof value === 'number') return new Intl.NumberFormat('es-MX').format(value)
  if (typeof value === 'string') {
    const parsedDate = Date.parse(value)
    if (
      /^\d{4}-\d{2}-\d{2}(T.*)?$/u.test(value) &&
      !Number.isNaN(parsedDate)
    ) {
      return new Intl.DateTimeFormat('es-MX', {
        dateStyle: 'medium',
        ...(value.includes('T') ? { timeStyle: 'short' as const } : {}),
      }).format(new Date(value))
    }
    return value
  }
  if (typeof value === 'object') return relationLabel(value as Record<string, unknown>)
  return String(value)
}

export function relationLabel(value: Record<string, unknown>): string {
  const firstLast = [value.nombres, value.apellidos]
    .filter((part): part is string => typeof part === 'string' && part.length > 0)
    .join(' ')
  return (
    firstLast ||
    (typeof value.nombre === 'string' ? value.nombre : '') ||
    (typeof value.clave === 'string' ? value.clave : '') ||
    (typeof value.email === 'string' ? value.email : '') ||
    (typeof value.id === 'string' || typeof value.id === 'number'
      ? String(value.id)
      : '—')
  )
}

export function getRecordLabel(
  record: EntityRecord,
  entity?: EntityDefinition,
): string {
  const displayField = entity?.displayField
  const relatedField = entity?.fields.find(
    (field) => field.name === displayField && field.name.endsWith('Id') && field.relation,
  )
  const navigationName = relatedField?.name.slice(0, -2)
  const navigation = navigationName ? record[navigationName] : undefined
  if (navigation && typeof navigation === 'object') {
    return relationLabel(navigation as Record<string, unknown>)
  }

  const preferred = displayField ? record[displayField] : undefined
  if (preferred !== null && preferred !== undefined && preferred !== '') {
    if (
      displayField === 'nombres' &&
      typeof preferred === 'string' &&
      typeof record.apellidos === 'string'
    ) {
      return `${preferred} ${record.apellidos}`
    }
    return formatValue(preferred)
  }
  const firstRelatedField = entity?.fields.find(
    (field) => field.name.endsWith('Id') && field.relation,
  )
  const firstNavigationName = firstRelatedField?.name.slice(0, -2)
  const firstNavigation = firstNavigationName
    ? record[firstNavigationName]
    : undefined
  if (firstNavigation && typeof firstNavigation === 'object') {
    return relationLabel(firstNavigation as Record<string, unknown>)
  }
  return typeof record.id === 'string' || typeof record.id === 'number'
    ? String(record.id)
    : 'Registro'
}

export function getEntityFieldValue(
  record: EntityRecord,
  fieldName: string,
  entity: EntityDefinition,
): unknown {
  const field = entity.fields.find((item) => item.name === fieldName)
  if (!field?.relation) return record[fieldName]

  const navigationName = field.name.endsWith('Id')
    ? field.name.slice(0, -2)
    : field.name
  const navigation = record[navigationName]
  if (typeof navigation !== 'object' || navigation === null || Array.isArray(navigation)) {
    return undefined
  }

  const relatedEntity = entities.find((item) => item.key === field.relation)
  const label = getRecordLabel(navigation as EntityRecord, relatedEntity)
  const id = (navigation as EntityRecord).id
  return id !== undefined && label === String(id) ? undefined : label
}

export function getApiErrorMessage(error: unknown): string {
  if (typeof error === 'object' && error !== null && 'response' in error) {
    const response = error.response
    if (
      typeof response === 'object' &&
      response !== null &&
      'data' in response
    ) {
      const data = response.data
      if (typeof data === 'string') return data
      if (typeof data === 'object' && data !== null) {
        const message = Object.entries(data).find(
          ([key, value]) =>
            ['message', 'detail', 'title'].includes(key) &&
            typeof value === 'string',
        )?.[1]
        if (typeof message === 'string') return message
      }
    }
  }
  if (error instanceof Error) return error.message
  return 'Ocurrió un error inesperado. Inténtalo de nuevo.'
}
