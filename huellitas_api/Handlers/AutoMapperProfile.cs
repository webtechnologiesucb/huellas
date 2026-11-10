using AutoMapper;
using huellitas_api.Dtos;
using huellitas_api.Models;

namespace huellitas_api.Handlers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ArchivosAdjunto, ArchivosAdjuntoDto>().MaxDepth(3).ReverseMap().MaxDepth(3);
            CreateMap<CatalogoVacuna, CatalogoVacunaDto>().MaxDepth(3).ReverseMap().MaxDepth(3);
            CreateMap<CategoriasProducto, CategoriasProductoDto>().MaxDepth(3).ReverseMap().MaxDepth(3);
            CreateMap<CierresCaja, CierresCajaDto>().MaxDepth(3).ReverseMap().MaxDepth(3);
            CreateMap<Cita, CitaDto>().MaxDepth(3).ReverseMap().MaxDepth(3);
            CreateMap<ConfiguracionClinica, ConfiguracionClinicaDto>().MaxDepth(3).ReverseMap().MaxDepth(3);
            CreateMap<DetallesRecetum, DetallesRecetumDto>().MaxDepth(3).ReverseMap().MaxDepth(3);
            CreateMap<DetallesTransaccion, DetallesTransaccionDto>().MaxDepth(3).ReverseMap().MaxDepth(3);
            CreateMap<Especy, EspecyDto>().MaxDepth(3).ReverseMap().MaxDepth(3);
            CreateMap<ExpedienteClinico, ExpedienteClinicoDto>().MaxDepth(3).ReverseMap().MaxDepth(3);
            CreateMap<FechasBloqueada, FechasBloqueadaDto>().MaxDepth(3).ReverseMap().MaxDepth(3);
            CreateMap<HistorialClinico, HistorialClinicoDto>().MaxDepth(3).ReverseMap().MaxDepth(3);
            CreateMap<HorariosAtencion, HorariosAtencionDto>().MaxDepth(3).ReverseMap().MaxDepth(3);
            CreateMap<Hospitalizacione, HospitalizacioneDto>().MaxDepth(3).ReverseMap().MaxDepth(3);
            CreateMap<HospitalizacionInsumo, HospitalizacionInsumoDto>().MaxDepth(3).ReverseMap().MaxDepth(3);
            CreateMap<InteraccionesBot, InteraccionesBotDto>().MaxDepth(3).ReverseMap().MaxDepth(3);
            CreateMap<KardexInventario, KardexInventarioDto>().MaxDepth(3).ReverseMap().MaxDepth(3);
            CreateMap<LogsSistema, LogsSistemaDto>().MaxDepth(3).ReverseMap().MaxDepth(3);
            CreateMap<LotesCaducidad, LotesCaducidadDto>().MaxDepth(3).ReverseMap().MaxDepth(3);
            CreateMap<Mascota, MascotaDto>().MaxDepth(3).ReverseMap().MaxDepth(3);
            CreateMap<MonitoreoDiario, MonitoreoDiarioDto>().MaxDepth(3).ReverseMap().MaxDepth(3);
            CreateMap<Producto, ProductoDto>().MaxDepth(3).ReverseMap().MaxDepth(3);
            CreateMap<Raza, RazaDto>().MaxDepth(3).ReverseMap().MaxDepth(3);
            CreateMap<Receta, RecetaDto>().MaxDepth(3).ReverseMap().MaxDepth(3);
            CreateMap<RegistroEscaneosQr, RegistroEscaneosQrDto>().MaxDepth(3).ReverseMap().MaxDepth(3);
            CreateMap<RegistroNotificacione, RegistroNotificacioneDto>().MaxDepth(3).ReverseMap().MaxDepth(3);
            CreateMap<Role, RoleDto>().MaxDepth(3).ReverseMap().MaxDepth(3);
            CreateMap<Servicio, ServicioDto>().MaxDepth(3).ReverseMap().MaxDepth(3);
            CreateMap<TransaccionesCaja, TransaccionesCajaDto>().MaxDepth(3).ReverseMap().MaxDepth(3);
            CreateMap<Usuario, UsuarioDto>().MaxDepth(3).ReverseMap().MaxDepth(3);
            CreateMap<Usuario, UsuarioRelacionadoDto>().MaxDepth(2);
            CreateMap<VacunasAplicada, VacunasAplicadaDto>().MaxDepth(3).ReverseMap().MaxDepth(3);
        }
    }
}
