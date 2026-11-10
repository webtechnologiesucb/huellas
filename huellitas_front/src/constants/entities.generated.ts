// Generated from http://localhost:5189/swagger/v1/swagger.json; do not edit by hand.
export interface EntityFieldDefinition {
  name: string
  label: string
  type: string
  format?: string
  required: boolean
  readOnly: boolean
  relation?: string
  relationDto?: string
  enumValues?: (string | number)[]
}

export interface EntityDefinition {
  key: string
  endpoint: string
  label: string
  singularLabel: string
  schema: string
  group: string
  idField: string
  displayField?: string
  columns: string[]
  fields: EntityFieldDefinition[]
  methods: string[]
}

export const entities = [
  {
    "key": "ArchivosAdjunto",
    "endpoint": "/api/ArchivosAdjunto",
    "label": "Archivos adjuntos",
    "singularLabel": "Archivo adjunto",
    "schema": "ArchivosAdjuntoDto",
    "group": "Atención clínica",
    "idField": "id",
    "displayField": "urlArchivo",
    "columns": [
      "id",
      "historialId",
      "hospitalizacionId",
      "urlArchivo",
      "tipoArchivo",
      "nombreArchivo",
      "createdAt"
    ],
    "fields": [
      {
        "name": "id",
        "label": "Id",
        "type": "string",
        "format": "uuid",
        "required": false,
        "readOnly": true
      },
      {
        "name": "historialId",
        "label": "Historial clínico",
        "type": "string",
        "format": "uuid",
        "required": false,
        "readOnly": false,
        "relation": "HistorialesClinicos",
        "relationDto": "HistorialClinicoDto"
      },
      {
        "name": "hospitalizacionId",
        "label": "Hospitalización",
        "type": "string",
        "format": "uuid",
        "required": false,
        "readOnly": false,
        "relation": "Hospitalizaciones",
        "relationDto": "HospitalizacioneDto"
      },
      {
        "name": "urlArchivo",
        "label": "Url Archivo",
        "type": "string",
        "required": false,
        "readOnly": false
      },
      {
        "name": "tipoArchivo",
        "label": "Tipo Archivo",
        "type": "string",
        "required": false,
        "readOnly": false
      },
      {
        "name": "nombreArchivo",
        "label": "Nombre Archivo",
        "type": "string",
        "required": false,
        "readOnly": false
      },
      {
        "name": "createdAt",
        "label": "Fecha de creación",
        "type": "string",
        "format": "date-time",
        "required": false,
        "readOnly": true
      },
      {
        "name": "historial",
        "label": "Historial",
        "type": "object",
        "required": false,
        "readOnly": true
      },
      {
        "name": "hospitalizacion",
        "label": "Hospitalizacion",
        "type": "object",
        "required": false,
        "readOnly": true
      }
    ],
    "methods": [
      "get",
      "post"
    ]
  },
  {
    "key": "CatalogoVacunas",
    "endpoint": "/api/CatalogoVacunas",
    "label": "Catálogo de vacunas",
    "singularLabel": "Vacuna del catálogo",
    "schema": "CatalogoVacunaDto",
    "group": "Inventario",
    "idField": "id",
    "displayField": "nombre",
    "columns": [
      "id",
      "especieId",
      "productoId",
      "nombre",
      "diasParaRefuerzo",
      "createdAt"
    ],
    "fields": [
      {
        "name": "id",
        "label": "Id",
        "type": "integer",
        "format": "int32",
        "required": false,
        "readOnly": true
      },
      {
        "name": "especieId",
        "label": "Especie",
        "type": "integer",
        "format": "int32",
        "required": true,
        "readOnly": false,
        "relation": "Especies",
        "relationDto": "EspecyDto"
      },
      {
        "name": "productoId",
        "label": "Producto",
        "type": "string",
        "format": "uuid",
        "required": false,
        "readOnly": false,
        "relation": "Productos",
        "relationDto": "ProductoDto"
      },
      {
        "name": "nombre",
        "label": "Nombre",
        "type": "string",
        "required": false,
        "readOnly": false
      },
      {
        "name": "diasParaRefuerzo",
        "label": "Dias Para Refuerzo",
        "type": "integer",
        "format": "int32",
        "required": true,
        "readOnly": false
      },
      {
        "name": "createdAt",
        "label": "Fecha de creación",
        "type": "string",
        "format": "date-time",
        "required": false,
        "readOnly": true
      },
      {
        "name": "updatedAt",
        "label": "Última actualización",
        "type": "string",
        "format": "date-time",
        "required": false,
        "readOnly": true
      },
      {
        "name": "deletedAt",
        "label": "Deleted At",
        "type": "string",
        "format": "date-time",
        "required": false,
        "readOnly": true
      },
      {
        "name": "especie",
        "label": "Especie",
        "type": "object",
        "required": false,
        "readOnly": true
      },
      {
        "name": "producto",
        "label": "Producto",
        "type": "object",
        "required": false,
        "readOnly": true
      },
      {
        "name": "vacunasAplicada",
        "label": "Vacunas Aplicada",
        "type": "array",
        "required": false,
        "readOnly": true
      }
    ],
    "methods": [
      "get",
      "post"
    ]
  },
  {
    "key": "CategoriasProducto",
    "endpoint": "/api/CategoriasProducto",
    "label": "Categorías de producto",
    "singularLabel": "Categoría de producto",
    "schema": "CategoriasProductoDto",
    "group": "Inventario",
    "idField": "id",
    "displayField": "nombre",
    "columns": [
      "id",
      "nombre",
      "descripcion",
      "createdAt"
    ],
    "fields": [
      {
        "name": "id",
        "label": "Id",
        "type": "integer",
        "format": "int32",
        "required": false,
        "readOnly": true
      },
      {
        "name": "nombre",
        "label": "Nombre",
        "type": "string",
        "required": false,
        "readOnly": false
      },
      {
        "name": "descripcion",
        "label": "Descripcion",
        "type": "string",
        "required": false,
        "readOnly": false
      },
      {
        "name": "createdAt",
        "label": "Fecha de creación",
        "type": "string",
        "format": "date-time",
        "required": false,
        "readOnly": true
      },
      {
        "name": "updatedAt",
        "label": "Última actualización",
        "type": "string",
        "format": "date-time",
        "required": false,
        "readOnly": true
      },
      {
        "name": "deletedAt",
        "label": "Deleted At",
        "type": "string",
        "format": "date-time",
        "required": false,
        "readOnly": true
      },
      {
        "name": "productos",
        "label": "Productos",
        "type": "array",
        "required": false,
        "readOnly": true
      }
    ],
    "methods": [
      "get",
      "post"
    ]
  },
  {
    "key": "CierresCaja",
    "endpoint": "/api/CierresCaja",
    "label": "Cierres de caja",
    "singularLabel": "Cierre de caja",
    "schema": "CierresCajaDto",
    "group": "Administración",
    "idField": "id",
    "displayField": "turno",
    "columns": [
      "id",
      "cajeroId",
      "fecha",
      "turno",
      "totalEfectivo",
      "totalQrTransferencia",
      "totalTarjeta"
    ],
    "fields": [
      {
        "name": "id",
        "label": "Id",
        "type": "string",
        "format": "uuid",
        "required": false,
        "readOnly": true
      },
      {
        "name": "cajeroId",
        "label": "Cajero",
        "type": "string",
        "format": "uuid",
        "required": true,
        "readOnly": false,
        "relation": "Usuarios",
        "relationDto": "UsuarioRelacionadoDto"
      },
      {
        "name": "fecha",
        "label": "Fecha",
        "type": "string",
        "format": "date",
        "required": true,
        "readOnly": false
      },
      {
        "name": "turno",
        "label": "Turno",
        "type": "string",
        "required": false,
        "readOnly": false
      },
      {
        "name": "totalEfectivo",
        "label": "Total Efectivo",
        "type": "number",
        "format": "double",
        "required": true,
        "readOnly": false
      },
      {
        "name": "totalQrTransferencia",
        "label": "Total Qr Transferencia",
        "type": "number",
        "format": "double",
        "required": true,
        "readOnly": false
      },
      {
        "name": "totalTarjeta",
        "label": "Total Tarjeta",
        "type": "number",
        "format": "double",
        "required": true,
        "readOnly": false
      },
      {
        "name": "montoTotalRecaudado",
        "label": "Monto Total Recaudado",
        "type": "number",
        "format": "double",
        "required": true,
        "readOnly": false
      },
      {
        "name": "createdAt",
        "label": "Fecha de creación",
        "type": "string",
        "format": "date-time",
        "required": false,
        "readOnly": true
      },
      {
        "name": "cajero",
        "label": "Cajero",
        "type": "object",
        "required": false,
        "readOnly": true
      }
    ],
    "methods": [
      "get",
      "post"
    ]
  },
  {
    "key": "Citas",
    "endpoint": "/api/Citas",
    "label": "Citas",
    "singularLabel": "Cita",
    "schema": "CitaDto",
    "group": "Atención clínica",
    "idField": "id",
    "displayField": "fechaHora",
    "columns": [
      "id",
      "mascotaId",
      "veterinarioId",
      "fechaHora",
      "origen",
      "prioridad",
      "estado"
    ],
    "fields": [
      {
        "name": "id",
        "label": "Id",
        "type": "string",
        "format": "uuid",
        "required": false,
        "readOnly": true
      },
      {
        "name": "mascotaId",
        "label": "Mascota",
        "type": "string",
        "format": "uuid",
        "required": true,
        "readOnly": false,
        "relation": "Mascotas",
        "relationDto": "MascotaDto"
      },
      {
        "name": "veterinarioId",
        "label": "Veterinario",
        "type": "string",
        "format": "uuid",
        "required": true,
        "readOnly": false,
        "relation": "Usuarios",
        "relationDto": "UsuarioRelacionadoDto"
      },
      {
        "name": "fechaHora",
        "label": "Fecha y hora",
        "type": "string",
        "format": "date-time",
        "required": true,
        "readOnly": false
      },
      {
        "name": "origen",
        "label": "Origen",
        "type": "string",
        "required": false,
        "readOnly": false
      },
      {
        "name": "prioridad",
        "label": "Prioridad",
        "type": "string",
        "required": false,
        "readOnly": false
      },
      {
        "name": "estado",
        "label": "Estado",
        "type": "string",
        "required": false,
        "readOnly": false
      },
      {
        "name": "motivoCancelacion",
        "label": "Motivo Cancelacion",
        "type": "string",
        "required": false,
        "readOnly": false
      },
      {
        "name": "createdAt",
        "label": "Fecha de creación",
        "type": "string",
        "format": "date-time",
        "required": false,
        "readOnly": true
      },
      {
        "name": "updatedAt",
        "label": "Última actualización",
        "type": "string",
        "format": "date-time",
        "required": false,
        "readOnly": true
      },
      {
        "name": "deletedAt",
        "label": "Deleted At",
        "type": "string",
        "format": "date-time",
        "required": false,
        "readOnly": true
      },
      {
        "name": "historialClinicos",
        "label": "Historial Clinicos",
        "type": "array",
        "required": false,
        "readOnly": true
      },
      {
        "name": "mascota",
        "label": "Mascota",
        "type": "object",
        "required": false,
        "readOnly": true
      },
      {
        "name": "veterinario",
        "label": "Veterinario",
        "type": "object",
        "required": false,
        "readOnly": true
      }
    ],
    "methods": [
      "get",
      "post"
    ]
  },
  {
    "key": "ConfiguracionClinica",
    "endpoint": "/api/ConfiguracionClinica",
    "label": "Configuración clínica",
    "singularLabel": "Configuración clínica",
    "schema": "ConfiguracionClinicaDto",
    "group": "Administración",
    "idField": "id",
    "displayField": "clave",
    "columns": [
      "id",
      "clave",
      "valor",
      "descripcion"
    ],
    "fields": [
      {
        "name": "id",
        "label": "Id",
        "type": "integer",
        "format": "int32",
        "required": false,
        "readOnly": true
      },
      {
        "name": "clave",
        "label": "Clave",
        "type": "string",
        "required": false,
        "readOnly": false
      },
      {
        "name": "valor",
        "label": "Valor",
        "type": "string",
        "required": false,
        "readOnly": false
      },
      {
        "name": "descripcion",
        "label": "Descripcion",
        "type": "string",
        "required": false,
        "readOnly": false
      },
      {
        "name": "updatedAt",
        "label": "Última actualización",
        "type": "string",
        "format": "date-time",
        "required": false,
        "readOnly": true
      }
    ],
    "methods": [
      "get",
      "post"
    ]
  },
  {
    "key": "DetallesRecetas",
    "endpoint": "/api/DetallesRecetas",
    "label": "Detalles de recetas",
    "singularLabel": "Detalle de receta",
    "schema": "DetallesRecetumDto",
    "group": "Atención clínica",
    "idField": "id",
    "displayField": "medicamentoTextoLibre",
    "columns": [
      "id",
      "recetaId",
      "productoId",
      "medicamentoTextoLibre",
      "dosis",
      "frecuencia",
      "duracion"
    ],
    "fields": [
      {
        "name": "id",
        "label": "Id",
        "type": "string",
        "format": "uuid",
        "required": false,
        "readOnly": true
      },
      {
        "name": "recetaId",
        "label": "Receta ",
        "type": "string",
        "format": "uuid",
        "required": true,
        "readOnly": false,
        "relation": "Recetas",
        "relationDto": "RecetaDto"
      },
      {
        "name": "productoId",
        "label": "Producto",
        "type": "string",
        "format": "uuid",
        "required": false,
        "readOnly": false,
        "relation": "Productos",
        "relationDto": "ProductoDto"
      },
      {
        "name": "medicamentoTextoLibre",
        "label": "Medicamento Texto Libre",
        "type": "string",
        "required": false,
        "readOnly": false
      },
      {
        "name": "dosis",
        "label": "Dosis",
        "type": "string",
        "required": false,
        "readOnly": false
      },
      {
        "name": "frecuencia",
        "label": "Frecuencia",
        "type": "string",
        "required": false,
        "readOnly": false
      },
      {
        "name": "duracion",
        "label": "Duracion",
        "type": "string",
        "required": false,
        "readOnly": false
      },
      {
        "name": "producto",
        "label": "Producto",
        "type": "object",
        "required": false,
        "readOnly": true
      },
      {
        "name": "receta",
        "label": "Receta",
        "type": "object",
        "required": false,
        "readOnly": true
      }
    ],
    "methods": [
      "get",
      "post"
    ]
  },
  {
    "key": "DetallesTransaccion",
    "endpoint": "/api/DetallesTransaccion",
    "label": "Detalles de transacción",
    "singularLabel": "Detalle de transacción",
    "schema": "DetallesTransaccionDto",
    "group": "Administración",
    "idField": "id",
    "displayField": "tipoCobro",
    "columns": [
      "id",
      "transaccionId",
      "productoId",
      "servicioId",
      "cantidad",
      "precioUnitario",
      "subtotal"
    ],
    "fields": [
      {
        "name": "id",
        "label": "Id",
        "type": "string",
        "format": "uuid",
        "required": false,
        "readOnly": true
      },
      {
        "name": "transaccionId",
        "label": "Transaccion ",
        "type": "string",
        "format": "uuid",
        "required": true,
        "readOnly": false,
        "relation": "TransaccionesCaja",
        "relationDto": "TransaccionesCajaDto"
      },
      {
        "name": "productoId",
        "label": "Producto",
        "type": "string",
        "format": "uuid",
        "required": false,
        "readOnly": false,
        "relation": "Productos",
        "relationDto": "ProductoDto"
      },
      {
        "name": "servicioId",
        "label": "Servicio",
        "type": "integer",
        "format": "int32",
        "required": false,
        "readOnly": false,
        "relation": "Servicios",
        "relationDto": "ServicioDto"
      },
      {
        "name": "cantidad",
        "label": "Cantidad",
        "type": "integer",
        "format": "int32",
        "required": true,
        "readOnly": false
      },
      {
        "name": "precioUnitario",
        "label": "Precio Unitario",
        "type": "number",
        "format": "double",
        "required": true,
        "readOnly": false
      },
      {
        "name": "subtotal",
        "label": "Subtotal",
        "type": "number",
        "format": "double",
        "required": true,
        "readOnly": false
      },
      {
        "name": "tipoCobro",
        "label": "Tipo Cobro",
        "type": "string",
        "required": false,
        "readOnly": false
      },
      {
        "name": "producto",
        "label": "Producto",
        "type": "object",
        "required": false,
        "readOnly": true
      },
      {
        "name": "servicio",
        "label": "Servicio",
        "type": "object",
        "required": false,
        "readOnly": true
      },
      {
        "name": "transaccion",
        "label": "Transaccion",
        "type": "object",
        "required": false,
        "readOnly": true
      }
    ],
    "methods": [
      "get",
      "post"
    ]
  },
  {
    "key": "Especies",
    "endpoint": "/api/Especies",
    "label": "Especies",
    "singularLabel": "Especie",
    "schema": "EspecyDto",
    "group": "Catálogos",
    "idField": "id",
    "displayField": "nombre",
    "columns": [
      "id",
      "nombre",
      "descripcion",
      "createdAt"
    ],
    "fields": [
      {
        "name": "id",
        "label": "Id",
        "type": "integer",
        "format": "int32",
        "required": false,
        "readOnly": true
      },
      {
        "name": "nombre",
        "label": "Nombre",
        "type": "string",
        "required": false,
        "readOnly": false
      },
      {
        "name": "descripcion",
        "label": "Descripcion",
        "type": "string",
        "required": false,
        "readOnly": false
      },
      {
        "name": "createdAt",
        "label": "Fecha de creación",
        "type": "string",
        "format": "date-time",
        "required": false,
        "readOnly": true
      },
      {
        "name": "updatedAt",
        "label": "Última actualización",
        "type": "string",
        "format": "date-time",
        "required": false,
        "readOnly": true
      },
      {
        "name": "deletedAt",
        "label": "Deleted At",
        "type": "string",
        "format": "date-time",
        "required": false,
        "readOnly": true
      },
      {
        "name": "catalogoVacunas",
        "label": "Catalogo Vacunas",
        "type": "array",
        "required": false,
        "readOnly": true
      },
      {
        "name": "razas",
        "label": "Razas",
        "type": "array",
        "required": false,
        "readOnly": true
      }
    ],
    "methods": [
      "get",
      "post"
    ]
  },
  {
    "key": "ExpedientesClinicos",
    "endpoint": "/api/ExpedientesClinicos",
    "label": "Expedientes clínicos",
    "singularLabel": "Expediente clínico",
    "schema": "ExpedienteClinicoDto",
    "group": "Atención clínica",
    "idField": "id",
    "displayField": "mascotaId",
    "columns": [
      "id",
      "mascotaId",
      "createdAt"
    ],
    "fields": [
      {
        "name": "id",
        "label": "Id",
        "type": "string",
        "format": "uuid",
        "required": false,
        "readOnly": true
      },
      {
        "name": "mascotaId",
        "label": "Mascota",
        "type": "string",
        "format": "uuid",
        "required": true,
        "readOnly": false,
        "relation": "Mascotas",
        "relationDto": "MascotaDto"
      },
      {
        "name": "createdAt",
        "label": "Fecha de creación",
        "type": "string",
        "format": "date-time",
        "required": false,
        "readOnly": true
      },
      {
        "name": "updatedAt",
        "label": "Última actualización",
        "type": "string",
        "format": "date-time",
        "required": false,
        "readOnly": true
      },
      {
        "name": "deletedAt",
        "label": "Deleted At",
        "type": "string",
        "format": "date-time",
        "required": false,
        "readOnly": true
      },
      {
        "name": "historialClinicos",
        "label": "Historial Clinicos",
        "type": "array",
        "required": false,
        "readOnly": true
      },
      {
        "name": "mascota",
        "label": "Mascota",
        "type": "object",
        "required": false,
        "readOnly": true
      }
    ],
    "methods": [
      "get",
      "post"
    ]
  },
  {
    "key": "FechasBloqueadas",
    "endpoint": "/api/FechasBloqueadas",
    "label": "Fechas bloqueadas",
    "singularLabel": "Fecha bloqueada",
    "schema": "FechasBloqueadaDto",
    "group": "Agenda",
    "idField": "id",
    "displayField": "motivo",
    "columns": [
      "id",
      "veterinarioId",
      "fecha",
      "motivo"
    ],
    "fields": [
      {
        "name": "id",
        "label": "Id",
        "type": "string",
        "format": "uuid",
        "required": false,
        "readOnly": true
      },
      {
        "name": "veterinarioId",
        "label": "Veterinario",
        "type": "string",
        "format": "uuid",
        "required": true,
        "readOnly": false,
        "relation": "Usuarios",
        "relationDto": "UsuarioRelacionadoDto"
      },
      {
        "name": "fecha",
        "label": "Fecha",
        "type": "string",
        "format": "date",
        "required": true,
        "readOnly": false
      },
      {
        "name": "motivo",
        "label": "Motivo",
        "type": "string",
        "required": false,
        "readOnly": false
      },
      {
        "name": "veterinario",
        "label": "Veterinario",
        "type": "object",
        "required": false,
        "readOnly": true
      }
    ],
    "methods": [
      "get",
      "post"
    ]
  },
  {
    "key": "HistorialesClinicos",
    "endpoint": "/api/HistorialesClinicos",
    "label": "Historiales clínicos",
    "singularLabel": "Historial clínico",
    "schema": "HistorialClinicoDto",
    "group": "Atención clínica",
    "idField": "id",
    "displayField": "motivoConsulta",
    "columns": [
      "id",
      "expedienteId",
      "citaId",
      "veterinarioId",
      "peso",
      "temperatura",
      "frecuenciaCardiaca"
    ],
    "fields": [
      {
        "name": "id",
        "label": "Id",
        "type": "string",
        "format": "uuid",
        "required": false,
        "readOnly": true
      },
      {
        "name": "expedienteId",
        "label": "Expediente",
        "type": "string",
        "format": "uuid",
        "required": true,
        "readOnly": false,
        "relation": "ExpedientesClinicos",
        "relationDto": "ExpedienteClinicoDto"
      },
      {
        "name": "citaId",
        "label": "Cita ",
        "type": "string",
        "format": "uuid",
        "required": false,
        "readOnly": false,
        "relation": "Citas",
        "relationDto": "CitaDto"
      },
      {
        "name": "veterinarioId",
        "label": "Veterinario",
        "type": "string",
        "format": "uuid",
        "required": true,
        "readOnly": false,
        "relation": "Usuarios",
        "relationDto": "UsuarioRelacionadoDto"
      },
      {
        "name": "peso",
        "label": "Peso",
        "type": "number",
        "format": "double",
        "required": true,
        "readOnly": false
      },
      {
        "name": "temperatura",
        "label": "Temperatura",
        "type": "number",
        "format": "double",
        "required": true,
        "readOnly": false
      },
      {
        "name": "frecuenciaCardiaca",
        "label": "Frecuencia cardíaca",
        "type": "integer",
        "format": "int32",
        "required": true,
        "readOnly": false
      },
      {
        "name": "frecuenciaRespiratoria",
        "label": "Frecuencia respiratoria",
        "type": "integer",
        "format": "int32",
        "required": true,
        "readOnly": false
      },
      {
        "name": "motivoConsulta",
        "label": "Motivo Consulta",
        "type": "string",
        "required": false,
        "readOnly": false
      },
      {
        "name": "diagnostico",
        "label": "Diagnostico",
        "type": "string",
        "required": false,
        "readOnly": false
      },
      {
        "name": "notasInternas",
        "label": "Notas Internas",
        "type": "string",
        "required": false,
        "readOnly": false
      },
      {
        "name": "estado",
        "label": "Estado",
        "type": "string",
        "required": false,
        "readOnly": false
      },
      {
        "name": "createdAt",
        "label": "Fecha de creación",
        "type": "string",
        "format": "date-time",
        "required": false,
        "readOnly": true
      },
      {
        "name": "updatedAt",
        "label": "Última actualización",
        "type": "string",
        "format": "date-time",
        "required": false,
        "readOnly": true
      },
      {
        "name": "deletedAt",
        "label": "Deleted At",
        "type": "string",
        "format": "date-time",
        "required": false,
        "readOnly": true
      },
      {
        "name": "archivosAdjuntos",
        "label": "Archivos Adjuntos",
        "type": "array",
        "required": false,
        "readOnly": true
      },
      {
        "name": "cita",
        "label": "Cita",
        "type": "object",
        "required": false,
        "readOnly": true
      },
      {
        "name": "expediente",
        "label": "Expediente",
        "type": "object",
        "required": false,
        "readOnly": true
      },
      {
        "name": "hospitalizaciones",
        "label": "Hospitalizaciones",
        "type": "array",
        "required": false,
        "readOnly": true
      },
      {
        "name": "receta",
        "label": "Receta",
        "type": "array",
        "required": false,
        "readOnly": true
      },
      {
        "name": "transaccionesCajas",
        "label": "Transacciones Cajas",
        "type": "array",
        "required": false,
        "readOnly": true
      },
      {
        "name": "vacunasAplicada",
        "label": "Vacunas Aplicada",
        "type": "array",
        "required": false,
        "readOnly": true
      },
      {
        "name": "veterinario",
        "label": "Veterinario",
        "type": "object",
        "required": false,
        "readOnly": true
      }
    ],
    "methods": [
      "get",
      "post"
    ]
  },
  {
    "key": "HorariosAtencion",
    "endpoint": "/api/HorariosAtencion",
    "label": "Horarios de atención",
    "singularLabel": "Horario de atención",
    "schema": "HorariosAtencionDto",
    "group": "Agenda",
    "idField": "id",
    "displayField": "horaInicio",
    "columns": [
      "id",
      "veterinarioId",
      "diaSemana",
      "horaInicio",
      "horaFin",
      "createdAt"
    ],
    "fields": [
      {
        "name": "id",
        "label": "Id",
        "type": "string",
        "format": "uuid",
        "required": false,
        "readOnly": true
      },
      {
        "name": "veterinarioId",
        "label": "Veterinario",
        "type": "string",
        "format": "uuid",
        "required": true,
        "readOnly": false,
        "relation": "Usuarios",
        "relationDto": "UsuarioRelacionadoDto"
      },
      {
        "name": "diaSemana",
        "label": "Dia Semana",
        "type": "integer",
        "format": "int32",
        "required": true,
        "readOnly": false
      },
      {
        "name": "horaInicio",
        "label": "Hora Inicio",
        "type": "string",
        "format": "time",
        "required": true,
        "readOnly": false
      },
      {
        "name": "horaFin",
        "label": "Hora Fin",
        "type": "string",
        "format": "time",
        "required": true,
        "readOnly": false
      },
      {
        "name": "createdAt",
        "label": "Fecha de creación",
        "type": "string",
        "format": "date-time",
        "required": false,
        "readOnly": true
      },
      {
        "name": "updatedAt",
        "label": "Última actualización",
        "type": "string",
        "format": "date-time",
        "required": false,
        "readOnly": true
      },
      {
        "name": "veterinario",
        "label": "Veterinario",
        "type": "object",
        "required": false,
        "readOnly": true
      }
    ],
    "methods": [
      "get",
      "post"
    ]
  },
  {
    "key": "Hospitalizaciones",
    "endpoint": "/api/Hospitalizaciones",
    "label": "Hospitalizaciones",
    "singularLabel": "Hospitalización",
    "schema": "HospitalizacioneDto",
    "group": "Atención clínica",
    "idField": "id",
    "displayField": "estado",
    "columns": [
      "id",
      "historialId",
      "mascotaId",
      "veterinarioId",
      "fechaIngreso",
      "fechaEgreso",
      "estado"
    ],
    "fields": [
      {
        "name": "id",
        "label": "Id",
        "type": "string",
        "format": "uuid",
        "required": false,
        "readOnly": true
      },
      {
        "name": "historialId",
        "label": "Historial clínico",
        "type": "string",
        "format": "uuid",
        "required": true,
        "readOnly": false,
        "relation": "HistorialesClinicos",
        "relationDto": "HistorialClinicoDto"
      },
      {
        "name": "mascotaId",
        "label": "Mascota",
        "type": "string",
        "format": "uuid",
        "required": true,
        "readOnly": false,
        "relation": "Mascotas",
        "relationDto": "MascotaDto"
      },
      {
        "name": "veterinarioId",
        "label": "Veterinario",
        "type": "string",
        "format": "uuid",
        "required": true,
        "readOnly": false,
        "relation": "Usuarios",
        "relationDto": "UsuarioRelacionadoDto"
      },
      {
        "name": "fechaIngreso",
        "label": "Fecha de ingreso",
        "type": "string",
        "format": "date-time",
        "required": true,
        "readOnly": false
      },
      {
        "name": "fechaEgreso",
        "label": "Fecha de egreso",
        "type": "string",
        "format": "date-time",
        "required": false,
        "readOnly": false
      },
      {
        "name": "estado",
        "label": "Estado",
        "type": "string",
        "required": false,
        "readOnly": false
      },
      {
        "name": "observaciones",
        "label": "Observaciones",
        "type": "string",
        "required": false,
        "readOnly": false
      },
      {
        "name": "createdAt",
        "label": "Fecha de creación",
        "type": "string",
        "format": "date-time",
        "required": false,
        "readOnly": true
      },
      {
        "name": "updatedAt",
        "label": "Última actualización",
        "type": "string",
        "format": "date-time",
        "required": false,
        "readOnly": true
      },
      {
        "name": "archivosAdjuntos",
        "label": "Archivos Adjuntos",
        "type": "array",
        "required": false,
        "readOnly": true
      },
      {
        "name": "historial",
        "label": "Historial",
        "type": "object",
        "required": false,
        "readOnly": true
      },
      {
        "name": "hospitalizacionInsumos",
        "label": "Hospitalizacion Insumos",
        "type": "array",
        "required": false,
        "readOnly": true
      },
      {
        "name": "mascota",
        "label": "Mascota",
        "type": "object",
        "required": false,
        "readOnly": true
      },
      {
        "name": "monitoreoDiarios",
        "label": "Monitoreo Diarios",
        "type": "array",
        "required": false,
        "readOnly": true
      },
      {
        "name": "transaccionesCajas",
        "label": "Transacciones Cajas",
        "type": "array",
        "required": false,
        "readOnly": true
      },
      {
        "name": "vacunasAplicada",
        "label": "Vacunas Aplicada",
        "type": "array",
        "required": false,
        "readOnly": true
      },
      {
        "name": "veterinario",
        "label": "Veterinario",
        "type": "object",
        "required": false,
        "readOnly": true
      }
    ],
    "methods": [
      "get",
      "post"
    ]
  },
  {
    "key": "HospitalizacionInsumos",
    "endpoint": "/api/HospitalizacionInsumos",
    "label": "Insumos de hospitalización",
    "singularLabel": "Insumo de hospitalización",
    "schema": "HospitalizacionInsumoDto",
    "group": "Inventario",
    "idField": "id",
    "displayField": "hospitalizacionId",
    "columns": [
      "id",
      "hospitalizacionId",
      "productoId",
      "servicioId",
      "cantidad",
      "subtotal",
      "createdAt"
    ],
    "fields": [
      {
        "name": "id",
        "label": "Id",
        "type": "string",
        "format": "uuid",
        "required": false,
        "readOnly": true
      },
      {
        "name": "hospitalizacionId",
        "label": "Hospitalización",
        "type": "string",
        "format": "uuid",
        "required": true,
        "readOnly": false,
        "relation": "Hospitalizaciones",
        "relationDto": "HospitalizacioneDto"
      },
      {
        "name": "productoId",
        "label": "Producto",
        "type": "string",
        "format": "uuid",
        "required": false,
        "readOnly": false,
        "relation": "Productos",
        "relationDto": "ProductoDto"
      },
      {
        "name": "servicioId",
        "label": "Servicio",
        "type": "integer",
        "format": "int32",
        "required": false,
        "readOnly": false,
        "relation": "Servicios",
        "relationDto": "ServicioDto"
      },
      {
        "name": "cantidad",
        "label": "Cantidad",
        "type": "integer",
        "format": "int32",
        "required": true,
        "readOnly": false
      },
      {
        "name": "subtotal",
        "label": "Subtotal",
        "type": "number",
        "format": "double",
        "required": true,
        "readOnly": false
      },
      {
        "name": "createdAt",
        "label": "Fecha de creación",
        "type": "string",
        "format": "date-time",
        "required": false,
        "readOnly": true
      },
      {
        "name": "hospitalizacion",
        "label": "Hospitalizacion",
        "type": "object",
        "required": false,
        "readOnly": true
      },
      {
        "name": "producto",
        "label": "Producto",
        "type": "object",
        "required": false,
        "readOnly": true
      },
      {
        "name": "servicio",
        "label": "Servicio",
        "type": "object",
        "required": false,
        "readOnly": true
      }
    ],
    "methods": [
      "get",
      "post"
    ]
  },
  {
    "key": "InteraccionesBot",
    "endpoint": "/api/InteraccionesBot",
    "label": "Interacciones del asistente",
    "singularLabel": "Interacción del asistente",
    "schema": "InteraccionesBotDto",
    "group": "Plataforma",
    "idField": "id",
    "displayField": "mensajeUsuario",
    "columns": [
      "id",
      "mascotaId",
      "mensajeUsuario",
      "intencionDetectada",
      "respuestaIa",
      "createdAt"
    ],
    "fields": [
      {
        "name": "id",
        "label": "Id",
        "type": "string",
        "format": "uuid",
        "required": false,
        "readOnly": true
      },
      {
        "name": "mascotaId",
        "label": "Mascota",
        "type": "string",
        "format": "uuid",
        "required": false,
        "readOnly": false,
        "relation": "Mascotas",
        "relationDto": "MascotaDto"
      },
      {
        "name": "mensajeUsuario",
        "label": "Mensaje Usuario",
        "type": "string",
        "required": false,
        "readOnly": false
      },
      {
        "name": "intencionDetectada",
        "label": "Intencion Detectada",
        "type": "string",
        "required": false,
        "readOnly": false
      },
      {
        "name": "respuestaIa",
        "label": "Respuesta Ia",
        "type": "string",
        "required": false,
        "readOnly": false
      },
      {
        "name": "createdAt",
        "label": "Fecha de creación",
        "type": "string",
        "format": "date-time",
        "required": false,
        "readOnly": true
      },
      {
        "name": "mascota",
        "label": "Mascota",
        "type": "object",
        "required": false,
        "readOnly": true
      }
    ],
    "methods": [
      "get",
      "post"
    ]
  },
  {
    "key": "KardexInventario",
    "endpoint": "/api/KardexInventario",
    "label": "Kardex de inventario",
    "singularLabel": "Movimiento de inventario",
    "schema": "KardexInventarioDto",
    "group": "Inventario",
    "idField": "id",
    "displayField": "tipoMovimiento",
    "columns": [
      "id",
      "productoId",
      "tipoMovimiento",
      "cantidad",
      "saldoResultante",
      "motivo",
      "createdAt"
    ],
    "fields": [
      {
        "name": "id",
        "label": "Id",
        "type": "string",
        "format": "uuid",
        "required": false,
        "readOnly": true
      },
      {
        "name": "productoId",
        "label": "Producto",
        "type": "string",
        "format": "uuid",
        "required": true,
        "readOnly": false,
        "relation": "Productos",
        "relationDto": "ProductoDto"
      },
      {
        "name": "tipoMovimiento",
        "label": "Tipo Movimiento",
        "type": "string",
        "required": false,
        "readOnly": false
      },
      {
        "name": "cantidad",
        "label": "Cantidad",
        "type": "integer",
        "format": "int32",
        "required": true,
        "readOnly": false
      },
      {
        "name": "saldoResultante",
        "label": "Saldo Resultante",
        "type": "integer",
        "format": "int32",
        "required": true,
        "readOnly": false
      },
      {
        "name": "motivo",
        "label": "Motivo",
        "type": "string",
        "required": false,
        "readOnly": false
      },
      {
        "name": "createdAt",
        "label": "Fecha de creación",
        "type": "string",
        "format": "date-time",
        "required": false,
        "readOnly": true
      },
      {
        "name": "producto",
        "label": "Producto",
        "type": "object",
        "required": false,
        "readOnly": true
      }
    ],
    "methods": [
      "get",
      "post"
    ]
  },
  {
    "key": "LogsSistema",
    "endpoint": "/api/LogsSistema",
    "label": "Registro de actividad",
    "singularLabel": "Registro de actividad",
    "schema": "LogsSistemaDto",
    "group": "Plataforma",
    "idField": "id",
    "displayField": "categoria",
    "columns": [
      "id",
      "usuarioId",
      "categoria",
      "accion",
      "detalles",
      "createdAt"
    ],
    "fields": [
      {
        "name": "id",
        "label": "Id",
        "type": "string",
        "format": "uuid",
        "required": false,
        "readOnly": true
      },
      {
        "name": "usuarioId",
        "label": "Usuario",
        "type": "string",
        "format": "uuid",
        "required": false,
        "readOnly": false,
        "relation": "Usuarios",
        "relationDto": "UsuarioRelacionadoDto"
      },
      {
        "name": "categoria",
        "label": "Categoria",
        "type": "string",
        "required": false,
        "readOnly": false
      },
      {
        "name": "accion",
        "label": "Accion",
        "type": "string",
        "required": false,
        "readOnly": false
      },
      {
        "name": "detalles",
        "label": "Detalles",
        "type": "string",
        "required": false,
        "readOnly": false
      },
      {
        "name": "createdAt",
        "label": "Fecha de creación",
        "type": "string",
        "format": "date-time",
        "required": false,
        "readOnly": true
      },
      {
        "name": "usuario",
        "label": "Usuario",
        "type": "object",
        "required": false,
        "readOnly": true
      }
    ],
    "methods": [
      "get",
      "post"
    ]
  },
  {
    "key": "LotesCaducidad",
    "endpoint": "/api/LotesCaducidad",
    "label": "Lotes y caducidad",
    "singularLabel": "Lote y caducidad",
    "schema": "LotesCaducidadDto",
    "group": "Inventario",
    "idField": "id",
    "displayField": "numeroLote",
    "columns": [
      "id",
      "productoId",
      "numeroLote",
      "fechaVencimiento",
      "cantidadInicial",
      "cantidadActual",
      "createdAt"
    ],
    "fields": [
      {
        "name": "id",
        "label": "Id",
        "type": "string",
        "format": "uuid",
        "required": false,
        "readOnly": true
      },
      {
        "name": "productoId",
        "label": "Producto",
        "type": "string",
        "format": "uuid",
        "required": true,
        "readOnly": false,
        "relation": "Productos",
        "relationDto": "ProductoDto"
      },
      {
        "name": "numeroLote",
        "label": "Numero Lote",
        "type": "string",
        "required": false,
        "readOnly": false
      },
      {
        "name": "fechaVencimiento",
        "label": "Fecha de vencimiento",
        "type": "string",
        "format": "date",
        "required": true,
        "readOnly": false
      },
      {
        "name": "cantidadInicial",
        "label": "Cantidad Inicial",
        "type": "integer",
        "format": "int32",
        "required": true,
        "readOnly": false
      },
      {
        "name": "cantidadActual",
        "label": "Cantidad Actual",
        "type": "integer",
        "format": "int32",
        "required": true,
        "readOnly": false
      },
      {
        "name": "createdAt",
        "label": "Fecha de creación",
        "type": "string",
        "format": "date-time",
        "required": false,
        "readOnly": true
      },
      {
        "name": "producto",
        "label": "Producto",
        "type": "object",
        "required": false,
        "readOnly": true
      },
      {
        "name": "vacunasAplicada",
        "label": "Vacunas Aplicada",
        "type": "array",
        "required": false,
        "readOnly": true
      }
    ],
    "methods": [
      "get",
      "post"
    ]
  },
  {
    "key": "Mascotas",
    "endpoint": "/api/Mascotas",
    "label": "Mascotas",
    "singularLabel": "Mascota",
    "schema": "MascotaDto",
    "group": "Atención clínica",
    "idField": "id",
    "displayField": "nombre",
    "columns": [
      "id",
      "dueñoId",
      "razaId",
      "nombre",
      "genero",
      "fechaNacimiento",
      "pesoActual"
    ],
    "fields": [
      {
        "name": "id",
        "label": "Id",
        "type": "string",
        "format": "uuid",
        "required": false,
        "readOnly": true
      },
      {
        "name": "dueñoId",
        "label": "Dueño",
        "type": "string",
        "format": "uuid",
        "required": true,
        "readOnly": false,
        "relation": "Usuarios",
        "relationDto": "UsuarioRelacionadoDto"
      },
      {
        "name": "razaId",
        "label": "Raza",
        "type": "integer",
        "format": "int32",
        "required": true,
        "readOnly": false,
        "relation": "Razas",
        "relationDto": "RazaDto"
      },
      {
        "name": "nombre",
        "label": "Nombre",
        "type": "string",
        "required": false,
        "readOnly": false
      },
      {
        "name": "genero",
        "label": "Genero",
        "type": "string",
        "required": false,
        "readOnly": false
      },
      {
        "name": "fechaNacimiento",
        "label": "Fecha de nacimiento",
        "type": "string",
        "format": "date",
        "required": false,
        "readOnly": false
      },
      {
        "name": "pesoActual",
        "label": "Peso actual",
        "type": "number",
        "format": "double",
        "required": false,
        "readOnly": false
      },
      {
        "name": "hashQrIdentidad",
        "label": "Hash Qr Identidad",
        "type": "string",
        "required": false,
        "readOnly": false
      },
      {
        "name": "perdida",
        "label": "Perdida",
        "type": "boolean",
        "required": false,
        "readOnly": false
      },
      {
        "name": "latitudPerdida",
        "label": "Latitud Perdida",
        "type": "number",
        "format": "double",
        "required": false,
        "readOnly": false
      },
      {
        "name": "longitudPerdida",
        "label": "Longitud Perdida",
        "type": "number",
        "format": "double",
        "required": false,
        "readOnly": false
      },
      {
        "name": "puntoEntrega",
        "label": "Punto Entrega",
        "type": "string",
        "required": false,
        "readOnly": false
      },
      {
        "name": "recompensa",
        "label": "Recompensa",
        "type": "number",
        "format": "double",
        "required": false,
        "readOnly": false
      },
      {
        "name": "mensajeEncontrado",
        "label": "Mensaje Encontrado",
        "type": "string",
        "required": false,
        "readOnly": false
      },
      {
        "name": "createdAt",
        "label": "Fecha de creación",
        "type": "string",
        "format": "date-time",
        "required": false,
        "readOnly": true
      },
      {
        "name": "updatedAt",
        "label": "Última actualización",
        "type": "string",
        "format": "date-time",
        "required": false,
        "readOnly": true
      },
      {
        "name": "deletedAt",
        "label": "Deleted At",
        "type": "string",
        "format": "date-time",
        "required": false,
        "readOnly": true
      },
      {
        "name": "cita",
        "label": "Cita",
        "type": "array",
        "required": false,
        "readOnly": true
      },
      {
        "name": "dueño",
        "label": "Dueño",
        "type": "object",
        "required": false,
        "readOnly": true
      },
      {
        "name": "expedienteClinico",
        "label": "Expediente Clinico",
        "type": "object",
        "required": false,
        "readOnly": true
      },
      {
        "name": "hospitalizaciones",
        "label": "Hospitalizaciones",
        "type": "array",
        "required": false,
        "readOnly": true
      },
      {
        "name": "interaccionesBots",
        "label": "Interacciones Bots",
        "type": "array",
        "required": false,
        "readOnly": true
      },
      {
        "name": "raza",
        "label": "Raza",
        "type": "object",
        "required": false,
        "readOnly": true
      },
      {
        "name": "registroEscaneosQrs",
        "label": "Registro Escaneos Qrs",
        "type": "array",
        "required": false,
        "readOnly": true
      }
    ],
    "methods": [
      "get",
      "post"
    ]
  },
  {
    "key": "MonitoreoDiario",
    "endpoint": "/api/MonitoreoDiario",
    "label": "Monitoreo diario",
    "singularLabel": "Monitoreo diario",
    "schema": "MonitoreoDiarioDto",
    "group": "Atención clínica",
    "idField": "id",
    "displayField": "turno",
    "columns": [
      "id",
      "hospitalizacionId",
      "responsableId",
      "turno",
      "peso",
      "temperatura",
      "frecuenciaCardiaca"
    ],
    "fields": [
      {
        "name": "id",
        "label": "Id",
        "type": "string",
        "format": "uuid",
        "required": false,
        "readOnly": true
      },
      {
        "name": "hospitalizacionId",
        "label": "Hospitalización",
        "type": "string",
        "format": "uuid",
        "required": true,
        "readOnly": false,
        "relation": "Hospitalizaciones",
        "relationDto": "HospitalizacioneDto"
      },
      {
        "name": "responsableId",
        "label": "Responsable",
        "type": "string",
        "format": "uuid",
        "required": true,
        "readOnly": false,
        "relation": "Usuarios",
        "relationDto": "UsuarioRelacionadoDto"
      },
      {
        "name": "turno",
        "label": "Turno",
        "type": "string",
        "required": false,
        "readOnly": false
      },
      {
        "name": "peso",
        "label": "Peso",
        "type": "number",
        "format": "double",
        "required": true,
        "readOnly": false
      },
      {
        "name": "temperatura",
        "label": "Temperatura",
        "type": "number",
        "format": "double",
        "required": true,
        "readOnly": false
      },
      {
        "name": "frecuenciaCardiaca",
        "label": "Frecuencia cardíaca",
        "type": "integer",
        "format": "int32",
        "required": true,
        "readOnly": false
      },
      {
        "name": "observaciones",
        "label": "Observaciones",
        "type": "string",
        "required": false,
        "readOnly": false
      },
      {
        "name": "createdAt",
        "label": "Fecha de creación",
        "type": "string",
        "format": "date-time",
        "required": false,
        "readOnly": true
      },
      {
        "name": "hospitalizacion",
        "label": "Hospitalizacion",
        "type": "object",
        "required": false,
        "readOnly": true
      },
      {
        "name": "responsable",
        "label": "Responsable",
        "type": "object",
        "required": false,
        "readOnly": true
      }
    ],
    "methods": [
      "get",
      "post"
    ]
  },
  {
    "key": "Productos",
    "endpoint": "/api/Productos",
    "label": "Productos",
    "singularLabel": "Producto",
    "schema": "ProductoDto",
    "group": "Inventario",
    "idField": "id",
    "displayField": "nombre",
    "columns": [
      "id",
      "categoriaId",
      "nombre",
      "descripcion",
      "precioVenta",
      "stockActual",
      "stockMinimo"
    ],
    "fields": [
      {
        "name": "id",
        "label": "Id",
        "type": "string",
        "format": "uuid",
        "required": false,
        "readOnly": true
      },
      {
        "name": "categoriaId",
        "label": "Categoría",
        "type": "integer",
        "format": "int32",
        "required": true,
        "readOnly": false,
        "relation": "CategoriasProducto",
        "relationDto": "CategoriasProductoDto"
      },
      {
        "name": "nombre",
        "label": "Nombre",
        "type": "string",
        "required": false,
        "readOnly": false
      },
      {
        "name": "descripcion",
        "label": "Descripcion",
        "type": "string",
        "required": false,
        "readOnly": false
      },
      {
        "name": "precioVenta",
        "label": "Precio de venta",
        "type": "number",
        "format": "double",
        "required": true,
        "readOnly": false
      },
      {
        "name": "stockActual",
        "label": "Stock Actual",
        "type": "integer",
        "format": "int32",
        "required": true,
        "readOnly": false
      },
      {
        "name": "stockMinimo",
        "label": "Stock Minimo",
        "type": "integer",
        "format": "int32",
        "required": true,
        "readOnly": false
      },
      {
        "name": "requiereReceta",
        "label": "Requiere Receta",
        "type": "boolean",
        "required": false,
        "readOnly": false
      },
      {
        "name": "esServicio",
        "label": "Es Servicio",
        "type": "boolean",
        "required": false,
        "readOnly": false
      },
      {
        "name": "createdAt",
        "label": "Fecha de creación",
        "type": "string",
        "format": "date-time",
        "required": false,
        "readOnly": true
      },
      {
        "name": "updatedAt",
        "label": "Última actualización",
        "type": "string",
        "format": "date-time",
        "required": false,
        "readOnly": true
      },
      {
        "name": "deletedAt",
        "label": "Deleted At",
        "type": "string",
        "format": "date-time",
        "required": false,
        "readOnly": true
      },
      {
        "name": "catalogoVacunas",
        "label": "Catalogo Vacunas",
        "type": "array",
        "required": false,
        "readOnly": true
      },
      {
        "name": "categoria",
        "label": "Categoria",
        "type": "object",
        "required": false,
        "readOnly": true
      },
      {
        "name": "detallesReceta",
        "label": "Detalles Receta",
        "type": "array",
        "required": false,
        "readOnly": true
      },
      {
        "name": "detallesTransaccions",
        "label": "Detalles Transaccions",
        "type": "array",
        "required": false,
        "readOnly": true
      },
      {
        "name": "hospitalizacionInsumos",
        "label": "Hospitalizacion Insumos",
        "type": "array",
        "required": false,
        "readOnly": true
      },
      {
        "name": "kardexInventarios",
        "label": "Kardex Inventarios",
        "type": "array",
        "required": false,
        "readOnly": true
      },
      {
        "name": "lotesCaducidads",
        "label": "Lotes Caducidads",
        "type": "array",
        "required": false,
        "readOnly": true
      }
    ],
    "methods": [
      "get",
      "post"
    ]
  },
  {
    "key": "Razas",
    "endpoint": "/api/Razas",
    "label": "Razas",
    "singularLabel": "Raza",
    "schema": "RazaDto",
    "group": "Catálogos",
    "idField": "id",
    "displayField": "nombre",
    "columns": [
      "id",
      "especieId",
      "nombre",
      "createdAt"
    ],
    "fields": [
      {
        "name": "id",
        "label": "Id",
        "type": "integer",
        "format": "int32",
        "required": false,
        "readOnly": true
      },
      {
        "name": "especieId",
        "label": "Especie",
        "type": "integer",
        "format": "int32",
        "required": true,
        "readOnly": false,
        "relation": "Especies",
        "relationDto": "EspecyDto"
      },
      {
        "name": "nombre",
        "label": "Nombre",
        "type": "string",
        "required": false,
        "readOnly": false
      },
      {
        "name": "createdAt",
        "label": "Fecha de creación",
        "type": "string",
        "format": "date-time",
        "required": false,
        "readOnly": true
      },
      {
        "name": "updatedAt",
        "label": "Última actualización",
        "type": "string",
        "format": "date-time",
        "required": false,
        "readOnly": true
      },
      {
        "name": "deletedAt",
        "label": "Deleted At",
        "type": "string",
        "format": "date-time",
        "required": false,
        "readOnly": true
      },
      {
        "name": "especie",
        "label": "Especie",
        "type": "object",
        "required": false,
        "readOnly": true
      },
      {
        "name": "mascota",
        "label": "Mascota",
        "type": "array",
        "required": false,
        "readOnly": true
      }
    ],
    "methods": [
      "get",
      "post"
    ]
  },
  {
    "key": "Recetas",
    "endpoint": "/api/Recetas",
    "label": "Recetas",
    "singularLabel": "Receta",
    "schema": "RecetaDto",
    "group": "Atención clínica",
    "idField": "id",
    "displayField": "indicacionesGenerales",
    "columns": [
      "id",
      "historialId",
      "veterinarioId",
      "indicacionesGenerales",
      "createdAt"
    ],
    "fields": [
      {
        "name": "id",
        "label": "Id",
        "type": "string",
        "format": "uuid",
        "required": false,
        "readOnly": true
      },
      {
        "name": "historialId",
        "label": "Historial clínico",
        "type": "string",
        "format": "uuid",
        "required": true,
        "readOnly": false,
        "relation": "HistorialesClinicos",
        "relationDto": "HistorialClinicoDto"
      },
      {
        "name": "veterinarioId",
        "label": "Veterinario",
        "type": "string",
        "format": "uuid",
        "required": true,
        "readOnly": false,
        "relation": "Usuarios",
        "relationDto": "UsuarioRelacionadoDto"
      },
      {
        "name": "indicacionesGenerales",
        "label": "Indicaciones Generales",
        "type": "string",
        "required": false,
        "readOnly": false
      },
      {
        "name": "createdAt",
        "label": "Fecha de creación",
        "type": "string",
        "format": "date-time",
        "required": false,
        "readOnly": true
      },
      {
        "name": "detallesReceta",
        "label": "Detalles Receta",
        "type": "array",
        "required": false,
        "readOnly": true
      },
      {
        "name": "historial",
        "label": "Historial",
        "type": "object",
        "required": false,
        "readOnly": true
      },
      {
        "name": "veterinario",
        "label": "Veterinario",
        "type": "object",
        "required": false,
        "readOnly": true
      }
    ],
    "methods": [
      "get",
      "post"
    ]
  },
  {
    "key": "RegistroEscaneosQr",
    "endpoint": "/api/RegistroEscaneosQr",
    "label": "Escaneos QR",
    "singularLabel": "Escaneo QR",
    "schema": "RegistroEscaneosQrDto",
    "group": "Plataforma",
    "idField": "id",
    "displayField": "userAgent",
    "columns": [
      "id",
      "mascotaId",
      "latitud",
      "longitud",
      "userAgent",
      "createdAt"
    ],
    "fields": [
      {
        "name": "id",
        "label": "Id",
        "type": "string",
        "format": "uuid",
        "required": false,
        "readOnly": true
      },
      {
        "name": "mascotaId",
        "label": "Mascota",
        "type": "string",
        "format": "uuid",
        "required": true,
        "readOnly": false,
        "relation": "Mascotas",
        "relationDto": "MascotaDto"
      },
      {
        "name": "latitud",
        "label": "Latitud",
        "type": "number",
        "format": "double",
        "required": true,
        "readOnly": false
      },
      {
        "name": "longitud",
        "label": "Longitud",
        "type": "number",
        "format": "double",
        "required": true,
        "readOnly": false
      },
      {
        "name": "userAgent",
        "label": "User Agent",
        "type": "string",
        "required": false,
        "readOnly": false
      },
      {
        "name": "createdAt",
        "label": "Fecha de creación",
        "type": "string",
        "format": "date-time",
        "required": false,
        "readOnly": true
      },
      {
        "name": "mascota",
        "label": "Mascota",
        "type": "object",
        "required": false,
        "readOnly": true
      }
    ],
    "methods": [
      "get",
      "post"
    ]
  },
  {
    "key": "RegistroNotificaciones",
    "endpoint": "/api/RegistroNotificaciones",
    "label": "Notificaciones",
    "singularLabel": "Notificación",
    "schema": "RegistroNotificacioneDto",
    "group": "Plataforma",
    "idField": "id",
    "displayField": "canal",
    "columns": [
      "id",
      "usuarioId",
      "canal",
      "mensaje",
      "estado",
      "createdAt"
    ],
    "fields": [
      {
        "name": "id",
        "label": "Id",
        "type": "string",
        "format": "uuid",
        "required": false,
        "readOnly": true
      },
      {
        "name": "usuarioId",
        "label": "Usuario",
        "type": "string",
        "format": "uuid",
        "required": true,
        "readOnly": false,
        "relation": "Usuarios",
        "relationDto": "UsuarioRelacionadoDto"
      },
      {
        "name": "canal",
        "label": "Canal",
        "type": "string",
        "required": false,
        "readOnly": false
      },
      {
        "name": "mensaje",
        "label": "Mensaje",
        "type": "string",
        "required": false,
        "readOnly": false
      },
      {
        "name": "estado",
        "label": "Estado",
        "type": "string",
        "required": false,
        "readOnly": false
      },
      {
        "name": "createdAt",
        "label": "Fecha de creación",
        "type": "string",
        "format": "date-time",
        "required": false,
        "readOnly": true
      },
      {
        "name": "usuario",
        "label": "Usuario",
        "type": "object",
        "required": false,
        "readOnly": true
      }
    ],
    "methods": [
      "get",
      "post"
    ]
  },
  {
    "key": "Roles",
    "endpoint": "/api/Roles",
    "label": "Roles",
    "singularLabel": "Rol",
    "schema": "RoleDto",
    "group": "Administración",
    "idField": "id",
    "displayField": "nombre",
    "columns": [
      "id",
      "nombre",
      "descripcion",
      "createdAt"
    ],
    "fields": [
      {
        "name": "id",
        "label": "Id",
        "type": "integer",
        "format": "int32",
        "required": false,
        "readOnly": true
      },
      {
        "name": "nombre",
        "label": "Nombre",
        "type": "string",
        "required": false,
        "readOnly": false
      },
      {
        "name": "descripcion",
        "label": "Descripcion",
        "type": "string",
        "required": false,
        "readOnly": false
      },
      {
        "name": "createdAt",
        "label": "Fecha de creación",
        "type": "string",
        "format": "date-time",
        "required": false,
        "readOnly": true
      },
      {
        "name": "updatedAt",
        "label": "Última actualización",
        "type": "string",
        "format": "date-time",
        "required": false,
        "readOnly": true
      },
      {
        "name": "deletedAt",
        "label": "Deleted At",
        "type": "string",
        "format": "date-time",
        "required": false,
        "readOnly": true
      },
      {
        "name": "usuarios",
        "label": "Usuarios",
        "type": "array",
        "required": false,
        "readOnly": true
      }
    ],
    "methods": [
      "get",
      "post"
    ]
  },
  {
    "key": "Servicios",
    "endpoint": "/api/Servicios",
    "label": "Servicios",
    "singularLabel": "Servicio",
    "schema": "ServicioDto",
    "group": "Inventario",
    "idField": "id",
    "displayField": "nombre",
    "columns": [
      "id",
      "nombre",
      "descripcion",
      "precio",
      "duracionMinutos",
      "requiereVeterinario",
      "createdAt"
    ],
    "fields": [
      {
        "name": "id",
        "label": "Id",
        "type": "integer",
        "format": "int32",
        "required": false,
        "readOnly": true
      },
      {
        "name": "nombre",
        "label": "Nombre",
        "type": "string",
        "required": false,
        "readOnly": false
      },
      {
        "name": "descripcion",
        "label": "Descripcion",
        "type": "string",
        "required": false,
        "readOnly": false
      },
      {
        "name": "precio",
        "label": "Precio",
        "type": "number",
        "format": "double",
        "required": true,
        "readOnly": false
      },
      {
        "name": "duracionMinutos",
        "label": "Duracion Minutos",
        "type": "integer",
        "format": "int32",
        "required": true,
        "readOnly": false
      },
      {
        "name": "requiereVeterinario",
        "label": "Requiere Veterinario",
        "type": "boolean",
        "required": false,
        "readOnly": false
      },
      {
        "name": "createdAt",
        "label": "Fecha de creación",
        "type": "string",
        "format": "date-time",
        "required": false,
        "readOnly": true
      },
      {
        "name": "updatedAt",
        "label": "Última actualización",
        "type": "string",
        "format": "date-time",
        "required": false,
        "readOnly": true
      },
      {
        "name": "deletedAt",
        "label": "Deleted At",
        "type": "string",
        "format": "date-time",
        "required": false,
        "readOnly": true
      },
      {
        "name": "detallesTransaccions",
        "label": "Detalles Transaccions",
        "type": "array",
        "required": false,
        "readOnly": true
      },
      {
        "name": "hospitalizacionInsumos",
        "label": "Hospitalizacion Insumos",
        "type": "array",
        "required": false,
        "readOnly": true
      }
    ],
    "methods": [
      "get",
      "post"
    ]
  },
  {
    "key": "TransaccionesCaja",
    "endpoint": "/api/TransaccionesCaja",
    "label": "Transacciones de caja",
    "singularLabel": "Transacción de caja",
    "schema": "TransaccionesCajaDto",
    "group": "Administración",
    "idField": "id",
    "displayField": "metodoPago",
    "columns": [
      "id",
      "cajeroId",
      "historialId",
      "hospitalizacionId",
      "subtotal",
      "descuento",
      "total"
    ],
    "fields": [
      {
        "name": "id",
        "label": "Id",
        "type": "string",
        "format": "uuid",
        "required": false,
        "readOnly": true
      },
      {
        "name": "cajeroId",
        "label": "Cajero",
        "type": "string",
        "format": "uuid",
        "required": true,
        "readOnly": false,
        "relation": "Usuarios",
        "relationDto": "UsuarioRelacionadoDto"
      },
      {
        "name": "historialId",
        "label": "Historial clínico",
        "type": "string",
        "format": "uuid",
        "required": false,
        "readOnly": false,
        "relation": "HistorialesClinicos",
        "relationDto": "HistorialClinicoDto"
      },
      {
        "name": "hospitalizacionId",
        "label": "Hospitalización",
        "type": "string",
        "format": "uuid",
        "required": false,
        "readOnly": false,
        "relation": "Hospitalizaciones",
        "relationDto": "HospitalizacioneDto"
      },
      {
        "name": "subtotal",
        "label": "Subtotal",
        "type": "number",
        "format": "double",
        "required": true,
        "readOnly": false
      },
      {
        "name": "descuento",
        "label": "Descuento",
        "type": "number",
        "format": "double",
        "required": false,
        "readOnly": false
      },
      {
        "name": "total",
        "label": "Total",
        "type": "number",
        "format": "double",
        "required": true,
        "readOnly": false
      },
      {
        "name": "metodoPago",
        "label": "Metodo Pago",
        "type": "string",
        "required": false,
        "readOnly": false
      },
      {
        "name": "estado",
        "label": "Estado",
        "type": "string",
        "required": false,
        "readOnly": false
      },
      {
        "name": "createdAt",
        "label": "Fecha de creación",
        "type": "string",
        "format": "date-time",
        "required": false,
        "readOnly": true
      },
      {
        "name": "updatedAt",
        "label": "Última actualización",
        "type": "string",
        "format": "date-time",
        "required": false,
        "readOnly": true
      },
      {
        "name": "cajero",
        "label": "Cajero",
        "type": "object",
        "required": false,
        "readOnly": true
      },
      {
        "name": "detallesTransaccions",
        "label": "Detalles Transaccions",
        "type": "array",
        "required": false,
        "readOnly": true
      },
      {
        "name": "historial",
        "label": "Historial",
        "type": "object",
        "required": false,
        "readOnly": true
      },
      {
        "name": "hospitalizacion",
        "label": "Hospitalizacion",
        "type": "object",
        "required": false,
        "readOnly": true
      }
    ],
    "methods": [
      "get",
      "post"
    ]
  },
  {
    "key": "Usuarios",
    "endpoint": "/api/Usuarios",
    "label": "Usuarios",
    "singularLabel": "Usuario",
    "schema": "UsuarioDto",
    "group": "Administración",
    "idField": "id",
    "displayField": "nombres",
    "columns": [
      "id",
      "rolId",
      "nombres",
      "apellidos",
      "email",
      "telefono",
      "intentosFallidos"
    ],
    "fields": [
      {
        "name": "id",
        "label": "Id",
        "type": "string",
        "format": "uuid",
        "required": false,
        "readOnly": true
      },
      {
        "name": "rolId",
        "label": "Rol",
        "type": "integer",
        "format": "int32",
        "required": true,
        "readOnly": false,
        "relation": "Roles",
        "relationDto": "RoleDto"
      },
      {
        "name": "nombres",
        "label": "Nombres",
        "type": "string",
        "required": false,
        "readOnly": false
      },
      {
        "name": "apellidos",
        "label": "Apellidos",
        "type": "string",
        "required": false,
        "readOnly": false
      },
      {
        "name": "email",
        "label": "Email",
        "type": "string",
        "required": false,
        "readOnly": false
      },
      {
        "name": "telefono",
        "label": "Telefono",
        "type": "string",
        "required": false,
        "readOnly": false
      },
      {
        "name": "intentosFallidos",
        "label": "Intentos Fallidos",
        "type": "integer",
        "format": "int32",
        "required": false,
        "readOnly": false
      },
      {
        "name": "bloqueadoHasta",
        "label": "Bloqueado Hasta",
        "type": "string",
        "format": "date-time",
        "required": false,
        "readOnly": false
      },
      {
        "name": "createdAt",
        "label": "Fecha de creación",
        "type": "string",
        "format": "date-time",
        "required": false,
        "readOnly": true
      },
      {
        "name": "updatedAt",
        "label": "Última actualización",
        "type": "string",
        "format": "date-time",
        "required": false,
        "readOnly": true
      },
      {
        "name": "deletedAt",
        "label": "Deleted At",
        "type": "string",
        "format": "date-time",
        "required": false,
        "readOnly": true
      },
      {
        "name": "cierresCajas",
        "label": "Cierres Cajas",
        "type": "array",
        "required": false,
        "readOnly": true
      },
      {
        "name": "cita",
        "label": "Cita",
        "type": "array",
        "required": false,
        "readOnly": true
      },
      {
        "name": "fechasBloqueada",
        "label": "Fechas Bloqueada",
        "type": "array",
        "required": false,
        "readOnly": true
      },
      {
        "name": "historialClinicos",
        "label": "Historial Clinicos",
        "type": "array",
        "required": false,
        "readOnly": true
      },
      {
        "name": "horariosAtencions",
        "label": "Horarios Atencions",
        "type": "array",
        "required": false,
        "readOnly": true
      },
      {
        "name": "hospitalizaciones",
        "label": "Hospitalizaciones",
        "type": "array",
        "required": false,
        "readOnly": true
      },
      {
        "name": "logsSistemas",
        "label": "Logs Sistemas",
        "type": "array",
        "required": false,
        "readOnly": true
      },
      {
        "name": "mascota",
        "label": "Mascota",
        "type": "array",
        "required": false,
        "readOnly": true
      },
      {
        "name": "monitoreoDiarios",
        "label": "Monitoreo Diarios",
        "type": "array",
        "required": false,
        "readOnly": true
      },
      {
        "name": "receta",
        "label": "Receta",
        "type": "array",
        "required": false,
        "readOnly": true
      },
      {
        "name": "registroNotificaciones",
        "label": "Registro Notificaciones",
        "type": "array",
        "required": false,
        "readOnly": true
      },
      {
        "name": "rol",
        "label": "Rol",
        "type": "object",
        "required": false,
        "readOnly": true
      },
      {
        "name": "transaccionesCajas",
        "label": "Transacciones Cajas",
        "type": "array",
        "required": false,
        "readOnly": true
      }
    ],
    "methods": [
      "get",
      "post"
    ]
  },
  {
    "key": "VacunasAplicadas",
    "endpoint": "/api/VacunasAplicadas",
    "label": "Vacunas aplicadas",
    "singularLabel": "Vacuna aplicada",
    "schema": "VacunasAplicadaDto",
    "group": "Atención clínica",
    "idField": "id",
    "displayField": "historialId",
    "columns": [
      "id",
      "historialId",
      "hospitalizacionId",
      "catalogoVacunaId",
      "loteId",
      "fechaAplicacion",
      "fechaProximaDosis"
    ],
    "fields": [
      {
        "name": "id",
        "label": "Id",
        "type": "string",
        "format": "uuid",
        "required": false,
        "readOnly": true
      },
      {
        "name": "historialId",
        "label": "Historial clínico",
        "type": "string",
        "format": "uuid",
        "required": false,
        "readOnly": false,
        "relation": "HistorialesClinicos",
        "relationDto": "HistorialClinicoDto"
      },
      {
        "name": "hospitalizacionId",
        "label": "Hospitalización",
        "type": "string",
        "format": "uuid",
        "required": false,
        "readOnly": false,
        "relation": "Hospitalizaciones",
        "relationDto": "HospitalizacioneDto"
      },
      {
        "name": "catalogoVacunaId",
        "label": "Catalogo Vacuna ",
        "type": "integer",
        "format": "int32",
        "required": true,
        "readOnly": false
      },
      {
        "name": "loteId",
        "label": "Lote ",
        "type": "string",
        "format": "uuid",
        "required": true,
        "readOnly": false,
        "relation": "LotesCaducidad",
        "relationDto": "LotesCaducidadDto"
      },
      {
        "name": "fechaAplicacion",
        "label": "Fecha de aplicación",
        "type": "string",
        "format": "date-time",
        "required": true,
        "readOnly": false
      },
      {
        "name": "fechaProximaDosis",
        "label": "Próxima dosis",
        "type": "string",
        "format": "date",
        "required": true,
        "readOnly": false
      },
      {
        "name": "catalogoVacuna",
        "label": "Catalogo Vacuna",
        "type": "object",
        "required": false,
        "readOnly": true
      },
      {
        "name": "historial",
        "label": "Historial",
        "type": "object",
        "required": false,
        "readOnly": true
      },
      {
        "name": "hospitalizacion",
        "label": "Hospitalizacion",
        "type": "object",
        "required": false,
        "readOnly": true
      },
      {
        "name": "lote",
        "label": "Lote",
        "type": "object",
        "required": false,
        "readOnly": true
      }
    ],
    "methods": [
      "get",
      "post"
    ]
  }
] satisfies EntityDefinition[]
