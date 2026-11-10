import type { EntityDefinition } from '../constants/entities.generated'

export type EntityRecord = Record<string, unknown> & {
  id?: string | number
}

export type EntityFormValues = Record<string, string | number | boolean | null>

export type EntityOption = {
  id: string | number
  label: string
}

export type { EntityDefinition }
