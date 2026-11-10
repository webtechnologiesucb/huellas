namespace huellitas_api.Dtos
{
    public class MascotaDto
    {
        public Guid Id { get; set; }
        public Guid DueñoId { get; set; }
        public int RazaId { get; set; }
        public string Nombre { get; set; } = null!;
        public string Genero { get; set; } = null!;
        public DateOnly? FechaNacimiento { get; set; }
        public decimal? PesoActual { get; set; }
        public string HashQrIdentidad { get; set; } = null!;
        public bool? Perdida { get; set; }
        public double? LatitudPerdida { get; set; }
        public double? LongitudPerdida { get; set; }
        public string? PuntoEntrega { get; set; }
        public decimal? Recompensa { get; set; }
        public string? MensajeEncontrado { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public List<CitaDto> Cita { get; set; } = new();
        public UsuarioRelacionadoDto Dueño { get; set; } = null!;
        public ExpedienteClinicoDto? ExpedienteClinico { get; set; }
        public List<HospitalizacioneDto> Hospitalizaciones { get; set; } = new();
        public List<InteraccionesBotDto> InteraccionesBots { get; set; } = new();
        public RazaDto Raza { get; set; } = null!;
        public List<RegistroEscaneosQrDto> RegistroEscaneosQrs { get; set; } = new();
    }
}