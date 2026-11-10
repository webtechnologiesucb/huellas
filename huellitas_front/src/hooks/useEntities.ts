import {
  useMutation,
  useQuery,
  useQueryClient,
} from '@tanstack/react-query'
import { entityService } from '../services/entityService'
import { entities } from '../constants/entities.generated'
import type { EntityRecord } from '../interfaces/entity'

export const entityKeys = {
  all: ['entities'] as const,
  lists: () => [...entityKeys.all, 'list'] as const,
  list: (key: string) => [...entityKeys.lists(), key] as const,
  details: () => [...entityKeys.all, 'detail'] as const,
  detail: (key: string, id: string) =>
    [...entityKeys.details(), key, id] as const,
}

export function useEntityList(key: string, enabled = true) {
  const entity = entities.find((item) => item.key === key)
  return useQuery({
    queryKey: entityKeys.list(key),
    queryFn: () => {
      if (!entity) throw new Error(`El módulo "${key}" no existe.`)
      return entityService.list(entity)
    },
    enabled: enabled && Boolean(entity),
  })
}

export function useEntityRecord(key: string, id: string) {
  const entity = entities.find((item) => item.key === key)
  return useQuery({
    queryKey: entityKeys.detail(key, id),
    queryFn: () => {
      if (!entity) throw new Error(`El módulo "${key}" no existe.`)
      return entityService.getById(entity, id)
    },
    enabled: Boolean(entity && id),
  })
}

export function useEntityMutations(key: string) {
  const queryClient = useQueryClient()
  const entity = entities.find((item) => item.key === key)

  const invalidate = async (id?: string) => {
    await Promise.all([
      queryClient.invalidateQueries({ queryKey: entityKeys.list(key) }),
      ...(id
        ? [queryClient.invalidateQueries({ queryKey: entityKeys.detail(key, id) })]
        : []),
    ])
  }

  const create = useMutation({
    mutationFn: (values: Record<string, unknown>) => {
      if (!entity) throw new Error(`El módulo "${key}" no existe.`)
      return entityService.create<EntityRecord>(entity, values)
    },
    onSuccess: () => invalidate(),
  })

  const update = useMutation({
    mutationFn: ({
      id,
      values,
    }: {
      id: string
      values: Record<string, unknown>
    }) => {
      if (!entity) throw new Error(`El módulo "${key}" no existe.`)
      return entityService.update<EntityRecord>(entity, id, values)
    },
    onSuccess: (_, variables) => invalidate(variables.id),
  })

  const remove = useMutation({
    mutationFn: (id: string) => {
      if (!entity) throw new Error(`El módulo "${key}" no existe.`)
      return entityService.remove(entity, id)
    },
    onSuccess: (_, id) => invalidate(id),
  })

  return { create, update, remove }
}
