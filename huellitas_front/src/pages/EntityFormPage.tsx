import { useState } from 'react'
import { Link, useNavigate, useParams } from 'react-router-dom'
import Swal from 'sweetalert2'
import { EntityForm } from '../components/EntityForm'
import { ErrorState, LoadingState } from '../components/LoadingState'
import { entities } from '../constants/entities.generated'
import { useEntityMutations, useEntityRecord } from '../hooks/useEntities'
import type { EntityRecord } from '../interfaces/entity'
import { getApiErrorMessage } from '../utils/format'

export function EntityFormPage({ mode }: { mode: 'new' | 'edit' }) {
  const { module = '', id = '' } = useParams()
  const navigate = useNavigate()
  const entity = entities.find((item) => item.key === module)
  const recordQuery = useEntityRecord(module, id)
  const mutations = useEntityMutations(module)
  const [submissionError, setSubmissionError] = useState<string>()

  if (!entity) {
    return (
      <ErrorState
        message="El módulo solicitado no existe en la documentación de la API."
      />
    )
  }

  if (mode === 'edit' && recordQuery.isLoading) return <LoadingState rows={5} />
  if (mode === 'edit' && recordQuery.isError) {
    return (
      <ErrorState
        message={getApiErrorMessage(recordQuery.error)}
        onRetry={() => void recordQuery.refetch()}
      />
    )
  }

  const onSubmit = async (values: Record<string, unknown>) => {
    setSubmissionError(undefined)
    try {
      if (mode === 'edit') {
        await mutations.update.mutateAsync({ id, values })
      } else {
        const created = await mutations.create.mutateAsync(values)
        const createdId = created.id
        await Swal.fire({
          icon: 'success',
          title: 'Registro creado',
          text: `${entity.singularLabel} se guardó correctamente.`,
          confirmButtonText: 'Continuar',
          confirmButtonColor: '#23876c',
        })
        navigate(
          createdId !== undefined
            ? `/${entity.key}/${encodeURIComponent(String(createdId))}`
            : `/${entity.key}`,
        )
        return
      }

      await Swal.fire({
        icon: 'success',
        title: 'Cambios guardados',
        text: 'El registro se actualizó correctamente.',
        timer: 1600,
        showConfirmButton: false,
      })
      navigate(`/${entity.key}/${encodeURIComponent(id)}`)
    } catch (error) {
      const message = getApiErrorMessage(error)
      setSubmissionError(message)
    }
  }

  const record = recordQuery.data as EntityRecord | undefined

  return (
    <>
      <div className="page-heading">
        <div>
          <div className="eyebrow">{entity.group}</div>
          <h1 className="page-title">
            {mode === 'new' ? `Crear ${entity.singularLabel.toLocaleLowerCase('es')}` : 'Editar registro'}
          </h1>
          <p className="page-subtitle">
            {mode === 'new'
              ? `Completa los datos para agregar un registro a ${entity.label.toLocaleLowerCase('es')}.`
              : 'Actualiza la información del registro seleccionado.'}
          </p>
        </div>
        <Link className="button secondary" to={`/${entity.key}`}>
          Volver al listado
        </Link>
      </div>
      {submissionError && (
        <div className="error-state" role="alert" style={{ minHeight: 60, marginBottom: 14 }}>
          {submissionError}
        </div>
      )}
      <EntityForm
        entity={entity}
        record={record}
        submitting={mutations.create.isPending || mutations.update.isPending}
        onSubmit={onSubmit}
        onCancel={() =>
          navigate(
            mode === 'edit'
              ? `/${entity.key}/${encodeURIComponent(id)}`
              : `/${entity.key}`,
          )
        }
      />
    </>
  )
}
