import { useMemo } from 'react'
import { zodResolver } from '@hookform/resolvers/zod'
import { Controller, useForm } from 'react-hook-form'
import { z } from 'zod'
import type {
  EntityDefinition,
  EntityFieldDefinition,
} from '../constants/entities.generated'
import { entities } from '../constants/entities.generated'
import type { EntityFormValues, EntityRecord } from '../interfaces/entity'
import { useEntityList } from '../hooks/useEntities'
import { formatValue, getRecordLabel } from '../utils/format'

function createSchema(fields: EntityFieldDefinition[]) {
  const entries = fields.map((field): [string, z.ZodType] => {
    if (field.type === 'boolean') {
      return [
        field.name,
        field.required
        ? z.boolean()
          : z.boolean().nullable().optional(),
      ]
    }
    if (field.type === 'number' || field.type === 'integer') {
      return [
        field.name,
        field.required
          ? z.number({ error: `${field.label} es obligatorio.` })
          : z.number().nullable().optional(),
      ]
    }
    return [
      field.name,
      field.required
        ? z.string().trim().min(1, `${field.label} es obligatorio.`)
        : z.string().nullable().optional(),
    ]
  })
  const shape: Record<string, z.ZodType> = Object.fromEntries(entries)
  return z.object(shape)
}

function getDefaultValues(
  entity: EntityDefinition,
  record?: EntityRecord,
): EntityFormValues {
  return Object.fromEntries(
    entity.fields
      .filter((field) => !field.readOnly)
      .map((field) => {
        const value = record?.[field.name]
        if (value !== null && value !== undefined) {
          if (field.format === 'date-time' && typeof value === 'string') {
            return [field.name, value.slice(0, 16)]
          }
          return [field.name, value]
        }
        return [
          field.name,
          field.type === 'boolean'
            ? false
            : field.type === 'number' && !field.required
              ? null
              : '',
        ]
      }),
  ) as EntityFormValues
}

export function EntityForm({
  entity,
  record,
  submitting,
  onSubmit,
  onCancel,
}: {
  entity: EntityDefinition
  record?: EntityRecord
  submitting: boolean
  onSubmit: (values: Record<string, unknown>) => Promise<void>
  onCancel: () => void
}) {
  const fields = useMemo(
    () => entity.fields.filter((field) => !field.readOnly),
    [entity.fields],
  )
  const schema = useMemo(() => createSchema(fields), [fields])
  const { register, handleSubmit, control, formState } = useForm<
    Record<string, unknown>
  >({
    resolver: zodResolver(schema),
    defaultValues: getDefaultValues(entity, record),
    mode: 'onBlur',
  })

  const submit = handleSubmit(async (values) => {
    const payload = Object.fromEntries(
      Object.entries(values).filter(
        ([, value]) => value !== undefined && value !== '',
      ),
    )
    await onSubmit(payload)
  })

  return (
    <form className="form-card" onSubmit={(event) => void submit(event)}>
      <div className="form-grid">
        {fields.map((field) => (
          <FormField
            key={field.name}
            field={field}
            register={register}
            control={control}
            error={formState.errors[field.name]?.message}
          />
        ))}
      </div>
      <div className="form-actions">
        <button
          className="button secondary"
          type="button"
          onClick={onCancel}
          disabled={submitting}
        >
          Cancelar
        </button>
        <button className="button" type="submit" disabled={submitting}>
          {submitting ? 'Guardando…' : record ? 'Guardar cambios' : 'Crear registro'}
        </button>
      </div>
    </form>
  )
}

function FormField({
  field,
  register,
  control,
  error,
}: {
  field: EntityFieldDefinition
  register: ReturnType<
    typeof useForm<Record<string, unknown>>
  >['register']
  control: ReturnType<
    typeof useForm<Record<string, unknown>>
  >['control']
  error: unknown
}) {
  const relation = useEntityList(field.relation ?? '', Boolean(field.relation))
  const inputType =
    field.format === 'date-time'
      ? 'datetime-local'
      : field.format === 'date'
        ? 'date'
        : field.format === 'time'
          ? 'time'
          : field.type === 'integer' || field.type === 'number'
            ? 'number'
            : field.name.toLocaleLowerCase('es').includes('email')
              ? 'email'
              : field.name.toLocaleLowerCase('es').includes('url')
                ? 'url'
                : 'text'
  const isLongText =
    field.name.toLocaleLowerCase('es').includes('descripcion') ||
    field.name.toLocaleLowerCase('es').includes('observaciones') ||
    field.name.toLocaleLowerCase('es').includes('mensaje') ||
    field.name.toLocaleLowerCase('es').includes('notas') ||
    field.name.toLocaleLowerCase('es').includes('diagnostico')
  const message = typeof error === 'string' ? error : undefined

  return (
    <label className="form-field">
      <span className="form-label">
        {field.label}
        {field.required && <span className="required-mark">*</span>}
      </span>

      {field.relation ? (
        <select
          className="form-select"
          {...register(field.name, {
            setValueAs: (value: string) =>
              field.type === 'integer' ? (value ? Number(value) : undefined) : value,
          })}
          aria-label={field.label}
          disabled={relation.isLoading || relation.isError}
        >
          <option value="">
            {relation.isLoading
              ? 'Cargando opciones…'
              : relation.isError
                ? 'No se pudieron cargar las opciones'
                : 'Selecciona una opción'}
          </option>
          {(relation.data ?? []).map((option) => (
            <option key={String(option.id)} value={option.id}>
              {getRecordLabel(
                option,
                entities.find((item) => item.key === field.relation),
              )}
            </option>
          ))}
        </select>
      ) : field.enumValues?.length ? (
        <select className="form-select" {...register(field.name)} >
          <option value="">Selecciona una opción</option>
          {field.enumValues.map((value) => (
            <option key={String(value)} value={value}>
              {formatValue(value)}
            </option>
          ))}
        </select>
      ) : field.type === 'boolean' ? (
        <Controller
          name={field.name}
          control={control}
          render={({ field: input }) => (
            <select
              className="form-select"
              value={String(Boolean(input.value))}
              onChange={(event) => input.onChange(event.target.value === 'true')}
            >
              <option value="true">Sí</option>
              <option value="false">No</option>
            </select>
          )}
        />
      ) : isLongText ? (
        <textarea
          className="form-textarea"
          {...register(field.name)}
          placeholder={`Ingresa ${field.label.toLocaleLowerCase('es')}`}
        />
      ) : (
        <input
          className="form-control"
          type={inputType}
          step={field.type === 'number' ? 'any' : undefined}
          {...register(field.name, {
            setValueAs: (value: string) => {
              if (value === '') return undefined
              if (field.type === 'number' || field.type === 'integer') {
                const numeric = Number(value)
                return Number.isNaN(numeric) ? undefined : numeric
              }
              return value
            },
          })}
          placeholder={`Ingresa ${field.label.toLocaleLowerCase('es')}`}
        />
      )}
      {message && <span className="field-error">{message}</span>}
    </label>
  )
}
