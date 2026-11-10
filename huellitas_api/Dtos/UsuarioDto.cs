using System.Text.Json.Serialization;

namespace huellitas_api.Dtos
{
    public class UsuarioDto
    {
        public Guid Id { get; set; }
        public int RolId { get; set; }
        public string Nombres { get; set; } = null!;
        public string Apellidos { get; set; } = null!;
        public string Email { get; set; } = null!;
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWriting)]
        public string PasswordHash { get; set; } = null!;
        public string? Telefono { get; set; }
        public int? IntentosFallidos { get; set; }
        public DateTime? BloqueadoHasta { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public List<CierresCajaDto> CierresCajas { get; set; } = new();
        public List<CitaDto> Cita { get; set; } = new();
        public List<FechasBloqueadaDto> FechasBloqueada { get; set; } = new();
        public List<HistorialClinicoDto> HistorialClinicos { get; set; } = new();
        public List<HorariosAtencionDto> HorariosAtencions { get; set; } = new();
        public List<HospitalizacioneDto> Hospitalizaciones { get; set; } = new();
        public List<LogsSistemaDto> LogsSistemas { get; set; } = new();
        public List<MascotaDto> Mascota { get; set; } = new();
        public List<MonitoreoDiarioDto> MonitoreoDiarios { get; set; } = new();
        public List<RecetaDto> Receta { get; set; } = new();
        public List<RegistroNotificacioneDto> RegistroNotificaciones { get; set; } = new();
        public RoleDto Rol { get; set; } = null!;
        public List<TransaccionesCajaDto> TransaccionesCajas { get; set; } = new();
    }
}