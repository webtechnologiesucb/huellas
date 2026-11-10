import { mkdir, writeFile } from 'node:fs/promises'

const specificationUrl =
  process.env.OPENAPI_URL ??
  'http://localhost:5189/swagger/v1/swagger.json'
const response = await fetch(specificationUrl)

if (!response.ok) {
  throw new Error(
    `No se pudo obtener el contrato OpenAPI (${response.status} ${response.statusText}) desde ${specificationUrl}`,
  )
}

const openapi = await response.json()
const schemas = openapi.components?.schemas ?? {}
const paths = openapi.paths ?? {}
const groups = {
  ArchivosAdjunto: 'Atención clínica',
  CatalogoVacunas: 'Inventario',
  CategoriasProducto: 'Inventario',
  CierresCaja: 'Administración',
  Citas: 'Atención clínica',
  ConfiguracionClinica: 'Administración',
  DetallesRecetas: 'Atención clínica',
  DetallesTransaccion: 'Administración',
  Especies: 'Catálogos',
  ExpedientesClinicos: 'Atención clínica',
  FechasBloqueadas: 'Agenda',
  HistorialesClinicos: 'Atención clínica',
  HorariosAtencion: 'Agenda',
  Hospitalizaciones: 'Atención clínica',
  HospitalizacionInsumos: 'Inventario',
  InteraccionesBot: 'Plataforma',
  KardexInventario: 'Inventario',
  LogsSistema: 'Plataforma',
  LotesCaducidad: 'Inventario',
  Mascotas: 'Atención clínica',
  MonitoreoDiario: 'Atención clínica',
  Productos: 'Inventario',
  Razas: 'Catálogos',
  Recetas: 'Atención clínica',
  RegistroEscaneosQr: 'Plataforma',
  RegistroNotificaciones: 'Plataforma',
  Roles: 'Administración',
  Servicios: 'Inventario',
  TransaccionesCaja: 'Administración',
  Usuarios: 'Administración',
  VacunasAplicadas: 'Atención clínica',
}
const labels = {
  ArchivosAdjunto: 'Archivos adjuntos',
  CatalogoVacunas: 'Catálogo de vacunas',
  CategoriasProducto: 'Categorías de producto',
  CierresCaja: 'Cierres de caja',
  Citas: 'Citas',
  ConfiguracionClinica: 'Configuración clínica',
  DetallesRecetas: 'Detalles de recetas',
  DetallesTransaccion: 'Detalles de transacción',
  Especies: 'Especies',
  ExpedientesClinicos: 'Expedientes clínicos',
  FechasBloqueadas: 'Fechas bloqueadas',
  HistorialesClinicos: 'Historiales clínicos',
  HorariosAtencion: 'Horarios de atención',
  Hospitalizaciones: 'Hospitalizaciones',
  HospitalizacionInsumos: 'Insumos de hospitalización',
  InteraccionesBot: 'Interacciones del asistente',
  KardexInventario: 'Kardex de inventario',
  LogsSistema: 'Registro de actividad',
  LotesCaducidad: 'Lotes y caducidad',
  Mascotas: 'Mascotas',
  MonitoreoDiario: 'Monitoreo diario',
  Productos: 'Productos',
  Razas: 'Razas',
  Recetas: 'Recetas',
  RegistroEscaneosQr: 'Escaneos QR',
  RegistroNotificaciones: 'Notificaciones',
  Roles: 'Roles',
  Servicios: 'Servicios',
  TransaccionesCaja: 'Transacciones de caja',
  Usuarios: 'Usuarios',
  VacunasAplicadas: 'Vacunas aplicadas',
}
const singularLabels = {
  ArchivosAdjunto: 'Archivo adjunto',
  CatalogoVacunas: 'Vacuna del catálogo',
  CategoriasProducto: 'Categoría de producto',
  CierresCaja: 'Cierre de caja',
  Citas: 'Cita',
  ConfiguracionClinica: 'Configuración clínica',
  DetallesRecetas: 'Detalle de receta',
  DetallesTransaccion: 'Detalle de transacción',
  Especies: 'Especie',
  ExpedientesClinicos: 'Expediente clínico',
  FechasBloqueadas: 'Fecha bloqueada',
  HistorialesClinicos: 'Historial clínico',
  HorariosAtencion: 'Horario de atención',
  Hospitalizaciones: 'Hospitalización',
  HospitalizacionInsumos: 'Insumo de hospitalización',
  InteraccionesBot: 'Interacción del asistente',
  KardexInventario: 'Movimiento de inventario',
  LogsSistema: 'Registro de actividad',
  LotesCaducidad: 'Lote y caducidad',
  Mascotas: 'Mascota',
  MonitoreoDiario: 'Monitoreo diario',
  Productos: 'Producto',
  Razas: 'Raza',
  Recetas: 'Receta',
  RegistroEscaneosQr: 'Escaneo QR',
  RegistroNotificaciones: 'Notificación',
  Roles: 'Rol',
  Servicios: 'Servicio',
  TransaccionesCaja: 'Transacción de caja',
  Usuarios: 'Usuario',
  VacunasAplicadas: 'Vacuna aplicada',
}
const friendlyFields = {
  apellido: 'Apellidos',
  apellidos: 'Apellidos',
  cajeroId: 'Cajero',
  categoriaId: 'Categoría',
  createdAt: 'Fecha de creación',
  dueñoId: 'Dueño',
  especieId: 'Especie',
  expedienteId: 'Expediente',
  fecha: 'Fecha',
  fechaAplicacion: 'Fecha de aplicación',
  fechaEgreso: 'Fecha de egreso',
  fechaHora: 'Fecha y hora',
  fechaIngreso: 'Fecha de ingreso',
  fechaNacimiento: 'Fecha de nacimiento',
  fechaProximaDosis: 'Próxima dosis',
  fechaVencimiento: 'Fecha de vencimiento',
  frecuenciaCardiaca: 'Frecuencia cardíaca',
  frecuenciaRespiratoria: 'Frecuencia respiratoria',
  historialId: 'Historial clínico',
  hospitalizacionId: 'Hospitalización',
  mascotaId: 'Mascota',
  pesoActual: 'Peso actual',
  peso: 'Peso',
  precioVenta: 'Precio de venta',
  precio: 'Precio',
  productoId: 'Producto',
  razaId: 'Raza',
  responsableId: 'Responsable',
  rolId: 'Rol',
  servicioId: 'Servicio',
  updatedAt: 'Última actualización',
  usuarioId: 'Usuario',
  veterinarioId: 'Veterinario',
}

function humanize(value) {
  return value
    .replace(/([a-záéíóú])([A-Z])/g, '$1 $2')
    .replace(/Id$/, '')
    .replace(/^./, (letter) => letter.toLocaleUpperCase('es'))
}

function fieldType(schema) {
  if (schema.$ref) return 'object'
  if (schema.type === 'array') return 'array'
  if (schema.enum) return 'string'
  return schema.type ?? 'object'
}

function tsType(schema) {
  let type
  if (schema.$ref) {
    type = schema.$ref.split('/').at(-1)
  } else if (schema.type === 'array') {
    const item = schema.items ?? {}
    type = `${tsType(item)}[]`
  } else {
    type =
      schema.type === 'integer' || schema.type === 'number'
        ? 'number'
        : schema.type === 'boolean'
          ? 'boolean'
          : schema.type === 'object'
            ? 'Record<string, unknown>'
            : 'string'
  }
  return schema.nullable ? `${type} | null` : type
}

const entityCandidates = Object.entries(paths)
  .filter(([path, operations]) => {
    const get = operations.get
    return (
      path.startsWith('/api/') &&
      !path.includes('{') &&
      Boolean(get?.responses?.['200'])
    )
  })
  .map(([path, operations]) => {
    const getSchema =
      operations.get.responses?.['200'].content?.['application/json']?.schema
    const dtoName = getSchema?.items?.$ref?.split('/').at(-1)
    const key = path.split('/').at(-1)
    return { key, path, dtoName, operations }
  })
  .filter(({ key, dtoName }) => key && dtoName && schemas[dtoName])

const schemaToEntity = new Map(
  entityCandidates.map(({ key, dtoName }) => [dtoName, key]),
)
schemaToEntity.set('UsuarioRelacionadoDto', 'Usuarios')

const entities = entityCandidates.map(({ key, path, dtoName, operations }) => {
  const dto = schemas[dtoName]
  const properties = dto.properties ?? {}
  const fields = Object.entries(properties).map(([name, property]) => {
    const reference = property.$ref?.split('/').at(-1)
    const relationshipName = name.endsWith('Id')
      ? name.slice(0, -2).toLocaleLowerCase('es')
      : ''
    const navigation = properties[relationshipName]
    const relatedDto = navigation?.$ref?.split('/').at(-1)
    const relation =
      property.type !== 'array' && schemaToEntity.get(relatedDto)
        ? schemaToEntity.get(relatedDto)
        : undefined
    const readOnly =
      name === 'id' ||
      ['createdAt', 'updatedAt', 'deletedAt'].includes(name) ||
      property.readOnly === true ||
      property.type === 'array' ||
      Boolean(reference) ||
      Boolean(property.$ref)

    return {
      name,
      label: friendlyFields[name] ?? humanize(name),
      type: fieldType(property),
      format: property.format,
      required:
        dto.required?.includes(name) === true ||
        (property.nullable !== true && !readOnly),
      readOnly,
      relation,
      relationDto: relatedDto,
      enumValues: property.enum,
    }
  })
  const displayField =
    ['nombre', 'nombres', 'clave', 'email', 'numeroLote', 'fechaHora'].find(
      (field) => properties[field],
    ) ??
    fields.find(
      (field) =>
        !field.readOnly &&
        !field.name.endsWith('Id') &&
        field.type === 'string' &&
        !field.format?.startsWith('date'),
    )?.name ??
    fields.find((field) => Boolean(field.relation))?.name
  const columns = fields
    .filter((field) => !['array'].includes(field.type))
    .filter((field) => !(field.readOnly && field.type === 'object'))
    .filter((field) => !['updatedAt', 'deletedAt'].includes(field.name))
    .map((field) => field.name)
    .slice(0, 7)
  const singularLabel = singularLabels[key] ?? humanize(key)

  return {
    key,
    endpoint: path,
    label: labels[key] ?? humanize(key),
    singularLabel,
    schema: dtoName,
    group: groups[key] ?? 'Administración',
    idField: 'id',
    displayField,
    columns,
    fields,
    methods: ['get', 'post', 'put', 'delete'].filter((method) =>
      Object.keys(operations).includes(method),
    ),
  }
})

const interfaces = Object.entries(schemas)
  .map(([name, schema]) => {
    const properties = Object.entries(schema.properties ?? {})
    if (!properties.length) return null
    const required = new Set(schema.required ?? [])
    const lines = properties.map(([field, property]) => {
      const optional =
        !required.has(field) && property.nullable === true ? '?' : ''
      const key = /^[$A-Z_a-z][$\w]*$/u.test(field)
        ? field
        : JSON.stringify(field)
      return `  ${key}${optional}: ${tsType(property)};`
    })
    return `export interface ${name} {\n${lines.join('\n')}\n}`
  })
  .filter(Boolean)

await mkdir('src/interfaces', { recursive: true })
await mkdir('src/constants', { recursive: true })
await writeFile(
  'src/interfaces/generated.ts',
  `// Generated from ${specificationUrl}; do not edit by hand.\n\n${interfaces.join('\n\n')}\n`,
)
await writeFile(
  'src/constants/entities.generated.ts',
  `// Generated from ${specificationUrl}; do not edit by hand.\nexport interface EntityFieldDefinition {\n  name: string\n  label: string\n  type: string\n  format?: string\n  required: boolean\n  readOnly: boolean\n  relation?: string\n  relationDto?: string\n  enumValues?: (string | number)[]\n}\n\nexport interface EntityDefinition {\n  key: string\n  endpoint: string\n  label: string\n  singularLabel: string\n  schema: string\n  group: string\n  idField: string\n  displayField?: string\n  columns: string[]\n  fields: EntityFieldDefinition[]\n  methods: string[]\n}\n\nexport const entities = ${JSON.stringify(entities, null, 2)} satisfies EntityDefinition[]\n`,
)

console.log(
  `Generados ${interfaces.length} modelos y ${entities.length} recursos desde ${specificationUrl}`,
)
