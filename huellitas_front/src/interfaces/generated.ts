// Generated from http://localhost:5189/swagger/v1/swagger.json; do not edit by hand.

export interface ArchivosAdjuntoDto {
  id: string;
  historialId?: string | null;
  hospitalizacionId?: string | null;
  urlArchivo?: string | null;
  tipoArchivo?: string | null;
  nombreArchivo?: string | null;
  createdAt?: string | null;
  historial: HistorialClinicoDto;
  hospitalizacion: HospitalizacioneDto;
}

export interface CatalogoVacunaDto {
  id: number;
  especieId: number;
  productoId?: string | null;
  nombre?: string | null;
  diasParaRefuerzo: number;
  createdAt?: string | null;
  updatedAt?: string | null;
  deletedAt?: string | null;
  especie: EspecyDto;
  producto: ProductoDto;
  vacunasAplicada?: VacunasAplicadaDto[] | null;
}

export interface CategoriasProductoDto {
  id: number;
  nombre?: string | null;
  descripcion?: string | null;
  createdAt?: string | null;
  updatedAt?: string | null;
  deletedAt?: string | null;
  productos?: ProductoDto[] | null;
}

export interface CierresCajaDto {
  id: string;
  cajeroId: string;
  fecha: string;
  turno?: string | null;
  totalEfectivo: number;
  totalQrTransferencia: number;
  totalTarjeta: number;
  montoTotalRecaudado: number;
  createdAt?: string | null;
  cajero: UsuarioRelacionadoDto;
}

export interface CitaDto {
  id: string;
  mascotaId: string;
  veterinarioId: string;
  fechaHora: string;
  origen?: string | null;
  prioridad?: string | null;
  estado?: string | null;
  motivoCancelacion?: string | null;
  createdAt?: string | null;
  updatedAt?: string | null;
  deletedAt?: string | null;
  historialClinicos?: HistorialClinicoDto[] | null;
  mascota: MascotaDto;
  veterinario: UsuarioRelacionadoDto;
}

export interface ConfiguracionClinicaDto {
  id: number;
  clave?: string | null;
  valor?: string | null;
  descripcion?: string | null;
  updatedAt?: string | null;
}

export interface DetallesRecetumDto {
  id: string;
  recetaId: string;
  productoId?: string | null;
  medicamentoTextoLibre?: string | null;
  dosis?: string | null;
  frecuencia?: string | null;
  duracion?: string | null;
  producto: ProductoDto;
  receta: RecetaDto;
}

export interface DetallesTransaccionDto {
  id: string;
  transaccionId: string;
  productoId?: string | null;
  servicioId?: number | null;
  cantidad: number;
  precioUnitario: number;
  subtotal: number;
  tipoCobro?: string | null;
  producto: ProductoDto;
  servicio: ServicioDto;
  transaccion: TransaccionesCajaDto;
}

export interface EspecyDto {
  id: number;
  nombre?: string | null;
  descripcion?: string | null;
  createdAt?: string | null;
  updatedAt?: string | null;
  deletedAt?: string | null;
  catalogoVacunas?: CatalogoVacunaDto[] | null;
  razas?: RazaDto[] | null;
}

export interface ExpedienteClinicoDto {
  id: string;
  mascotaId: string;
  createdAt?: string | null;
  updatedAt?: string | null;
  deletedAt?: string | null;
  historialClinicos?: HistorialClinicoDto[] | null;
  mascota: MascotaDto;
}

export interface FechasBloqueadaDto {
  id: string;
  veterinarioId: string;
  fecha: string;
  motivo?: string | null;
  veterinario: UsuarioRelacionadoDto;
}

export interface HistorialClinicoDto {
  id: string;
  expedienteId: string;
  citaId?: string | null;
  veterinarioId: string;
  peso: number;
  temperatura: number;
  frecuenciaCardiaca: number;
  frecuenciaRespiratoria: number;
  motivoConsulta?: string | null;
  diagnostico?: string | null;
  notasInternas?: string | null;
  estado?: string | null;
  createdAt?: string | null;
  updatedAt?: string | null;
  deletedAt?: string | null;
  archivosAdjuntos?: ArchivosAdjuntoDto[] | null;
  cita: CitaDto;
  expediente: ExpedienteClinicoDto;
  hospitalizaciones?: HospitalizacioneDto[] | null;
  receta?: RecetaDto[] | null;
  transaccionesCajas?: TransaccionesCajaDto[] | null;
  vacunasAplicada?: VacunasAplicadaDto[] | null;
  veterinario: UsuarioRelacionadoDto;
}

export interface HorariosAtencionDto {
  id: string;
  veterinarioId: string;
  diaSemana: number;
  horaInicio: string;
  horaFin: string;
  createdAt?: string | null;
  updatedAt?: string | null;
  veterinario: UsuarioRelacionadoDto;
}

export interface HospitalizacionInsumoDto {
  id: string;
  hospitalizacionId: string;
  productoId?: string | null;
  servicioId?: number | null;
  cantidad: number;
  subtotal: number;
  createdAt?: string | null;
  hospitalizacion: HospitalizacioneDto;
  producto: ProductoDto;
  servicio: ServicioDto;
}

export interface HospitalizacioneDto {
  id: string;
  historialId: string;
  mascotaId: string;
  veterinarioId: string;
  fechaIngreso: string;
  fechaEgreso?: string | null;
  estado?: string | null;
  observaciones?: string | null;
  createdAt?: string | null;
  updatedAt?: string | null;
  archivosAdjuntos?: ArchivosAdjuntoDto[] | null;
  historial: HistorialClinicoDto;
  hospitalizacionInsumos?: HospitalizacionInsumoDto[] | null;
  mascota: MascotaDto;
  monitoreoDiarios?: MonitoreoDiarioDto[] | null;
  transaccionesCajas?: TransaccionesCajaDto[] | null;
  vacunasAplicada?: VacunasAplicadaDto[] | null;
  veterinario: UsuarioRelacionadoDto;
}

export interface InteraccionesBotDto {
  id: string;
  mascotaId?: string | null;
  mensajeUsuario?: string | null;
  intencionDetectada?: string | null;
  respuestaIa?: string | null;
  createdAt?: string | null;
  mascota: MascotaDto;
}

export interface KardexInventarioDto {
  id: string;
  productoId: string;
  tipoMovimiento?: string | null;
  cantidad: number;
  saldoResultante: number;
  motivo?: string | null;
  createdAt?: string | null;
  producto: ProductoDto;
}

export interface LogsSistemaDto {
  id: string;
  usuarioId?: string | null;
  categoria?: string | null;
  accion?: string | null;
  detalles?: string | null;
  createdAt?: string | null;
  usuario: UsuarioRelacionadoDto;
}

export interface LotesCaducidadDto {
  id: string;
  productoId: string;
  numeroLote?: string | null;
  fechaVencimiento: string;
  cantidadInicial: number;
  cantidadActual: number;
  createdAt?: string | null;
  producto: ProductoDto;
  vacunasAplicada?: VacunasAplicadaDto[] | null;
}

export interface MascotaDto {
  id: string;
  "dueñoId": string;
  razaId: number;
  nombre?: string | null;
  genero?: string | null;
  fechaNacimiento?: string | null;
  pesoActual?: number | null;
  hashQrIdentidad?: string | null;
  perdida?: boolean | null;
  latitudPerdida?: number | null;
  longitudPerdida?: number | null;
  puntoEntrega?: string | null;
  recompensa?: number | null;
  mensajeEncontrado?: string | null;
  createdAt?: string | null;
  updatedAt?: string | null;
  deletedAt?: string | null;
  cita?: CitaDto[] | null;
  "dueño": UsuarioRelacionadoDto;
  expedienteClinico: ExpedienteClinicoDto;
  hospitalizaciones?: HospitalizacioneDto[] | null;
  interaccionesBots?: InteraccionesBotDto[] | null;
  raza: RazaDto;
  registroEscaneosQrs?: RegistroEscaneosQrDto[] | null;
}

export interface MonitoreoDiarioDto {
  id: string;
  hospitalizacionId: string;
  responsableId: string;
  turno?: string | null;
  peso: number;
  temperatura: number;
  frecuenciaCardiaca: number;
  observaciones?: string | null;
  createdAt?: string | null;
  hospitalizacion: HospitalizacioneDto;
  responsable: UsuarioRelacionadoDto;
}

export interface ProductoDto {
  id: string;
  categoriaId: number;
  nombre?: string | null;
  descripcion?: string | null;
  precioVenta: number;
  stockActual: number;
  stockMinimo: number;
  requiereReceta?: boolean | null;
  esServicio?: boolean | null;
  createdAt?: string | null;
  updatedAt?: string | null;
  deletedAt?: string | null;
  catalogoVacunas?: CatalogoVacunaDto[] | null;
  categoria: CategoriasProductoDto;
  detallesReceta?: DetallesRecetumDto[] | null;
  detallesTransaccions?: DetallesTransaccionDto[] | null;
  hospitalizacionInsumos?: HospitalizacionInsumoDto[] | null;
  kardexInventarios?: KardexInventarioDto[] | null;
  lotesCaducidads?: LotesCaducidadDto[] | null;
}

export interface RazaDto {
  id: number;
  especieId: number;
  nombre?: string | null;
  createdAt?: string | null;
  updatedAt?: string | null;
  deletedAt?: string | null;
  especie: EspecyDto;
  mascota?: MascotaDto[] | null;
}

export interface RecetaDto {
  id: string;
  historialId: string;
  veterinarioId: string;
  indicacionesGenerales?: string | null;
  createdAt?: string | null;
  detallesReceta?: DetallesRecetumDto[] | null;
  historial: HistorialClinicoDto;
  veterinario: UsuarioRelacionadoDto;
}

export interface RegistroEscaneosQrDto {
  id: string;
  mascotaId: string;
  latitud: number;
  longitud: number;
  userAgent?: string | null;
  createdAt?: string | null;
  mascota: MascotaDto;
}

export interface RegistroNotificacioneDto {
  id: string;
  usuarioId: string;
  canal?: string | null;
  mensaje?: string | null;
  estado?: string | null;
  createdAt?: string | null;
  usuario: UsuarioRelacionadoDto;
}

export interface RoleDto {
  id: number;
  nombre?: string | null;
  descripcion?: string | null;
  createdAt?: string | null;
  updatedAt?: string | null;
  deletedAt?: string | null;
  usuarios?: UsuarioRelacionadoDto[] | null;
}

export interface ServicioDto {
  id: number;
  nombre?: string | null;
  descripcion?: string | null;
  precio: number;
  duracionMinutos: number;
  requiereVeterinario?: boolean | null;
  createdAt?: string | null;
  updatedAt?: string | null;
  deletedAt?: string | null;
  detallesTransaccions?: DetallesTransaccionDto[] | null;
  hospitalizacionInsumos?: HospitalizacionInsumoDto[] | null;
}

export interface TokenResponse {
  jwtToken?: string | null;
  refreshToken?: string | null;
}

export interface TransaccionesCajaDto {
  id: string;
  cajeroId: string;
  historialId?: string | null;
  hospitalizacionId?: string | null;
  subtotal: number;
  descuento?: number | null;
  total: number;
  metodoPago?: string | null;
  estado?: string | null;
  createdAt?: string | null;
  updatedAt?: string | null;
  cajero: UsuarioRelacionadoDto;
  detallesTransaccions?: DetallesTransaccionDto[] | null;
  historial: HistorialClinicoDto;
  hospitalizacion: HospitalizacioneDto;
}

export interface UserCred {
  email?: string | null;
  password?: string | null;
}

export interface UsuarioDto {
  id: string;
  rolId: number;
  nombres?: string | null;
  apellidos?: string | null;
  email?: string | null;
  telefono?: string | null;
  intentosFallidos?: number | null;
  bloqueadoHasta?: string | null;
  createdAt?: string | null;
  updatedAt?: string | null;
  deletedAt?: string | null;
  cierresCajas?: CierresCajaDto[] | null;
  cita?: CitaDto[] | null;
  fechasBloqueada?: FechasBloqueadaDto[] | null;
  historialClinicos?: HistorialClinicoDto[] | null;
  horariosAtencions?: HorariosAtencionDto[] | null;
  hospitalizaciones?: HospitalizacioneDto[] | null;
  logsSistemas?: LogsSistemaDto[] | null;
  mascota?: MascotaDto[] | null;
  monitoreoDiarios?: MonitoreoDiarioDto[] | null;
  receta?: RecetaDto[] | null;
  registroNotificaciones?: RegistroNotificacioneDto[] | null;
  rol: RoleDto;
  transaccionesCajas?: TransaccionesCajaDto[] | null;
}

export interface UsuarioRelacionadoDto {
  id: string;
  rolId: number;
  nombres?: string | null;
  apellidos?: string | null;
  email?: string | null;
  telefono?: string | null;
  intentosFallidos?: number | null;
  bloqueadoHasta?: string | null;
  createdAt?: string | null;
  updatedAt?: string | null;
  deletedAt?: string | null;
}

export interface VacunasAplicadaDto {
  id: string;
  historialId?: string | null;
  hospitalizacionId?: string | null;
  catalogoVacunaId: number;
  loteId: string;
  fechaAplicacion: string;
  fechaProximaDosis: string;
  catalogoVacuna: CatalogoVacunaDto;
  historial: HistorialClinicoDto;
  hospitalizacion: HospitalizacioneDto;
  lote: LotesCaducidadDto;
}
