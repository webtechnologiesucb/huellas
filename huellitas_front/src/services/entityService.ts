import { http } from '../api/http'
import type { EntityRecord } from '../interfaces/entity'
import type { EntityDefinition } from '../constants/entities.generated'

function getEntityPath(entity: EntityDefinition): string {
  return entity.endpoint.replace(/^\/api(?=\/)/u, '')
}

export const entityService = {
  async list<T extends EntityRecord>(entity: EntityDefinition): Promise<T[]> {
    const { data } = await http.get<T[]>(getEntityPath(entity))
    return data
  },

  async getById<T extends EntityRecord>(
    entity: EntityDefinition,
    id: string,
  ): Promise<T> {
    const { data } = await http.get<T>(
      `${getEntityPath(entity)}/${encodeURIComponent(id)}`,
    )
    return data
  },

  async create<T extends EntityRecord>(
    entity: EntityDefinition,
    values: Record<string, unknown>,
  ): Promise<T> {
    const { data } = await http.post<T>(getEntityPath(entity), values)
    return data
  },

  async update<T extends EntityRecord>(
    entity: EntityDefinition,
    id: string,
    values: Record<string, unknown>,
  ): Promise<T> {
    const idField = entity.fields.find(
      (field) => field.name === entity.idField,
    )
    const body = {
      ...values,
      [entity.idField]:
        idField?.type === 'integer' ? Number(id) : id,
    }
    const { data } = await http.put<T>(
      `${getEntityPath(entity)}/${encodeURIComponent(id)}`,
      body,
    )
    return data
  },

  async remove(entity: EntityDefinition, id: string): Promise<void> {
    await http.delete(`${getEntityPath(entity)}/${encodeURIComponent(id)}`)
  },
}
