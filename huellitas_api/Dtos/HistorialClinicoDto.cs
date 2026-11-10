namespace huellitas_api.Dtos
{
    public class HistorialClinicoDto
    {
        public Guid Id { get; set; }
        public Guid ExpedienteId { get; set; }
        public Guid? CitaId { get; set; }
        public Guid VeterinarioId { get; set; }
        public decimal Peso { get; set; }
        public decimal Temperatura { get; set; }
        public int FrecuenciaCardiaca { get; set; }
        public int FrecuenciaRespiratoria { get; set; }
        public string MotivoConsulta { get; set; } = null!;
        public string Diagnostico { get; set; } = null!;
        public string? NotasInternas { get; set; }
        public string Estado { get; set; } = null!;
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public List<ArchivosAdjuntoDto> ArchivosAdjuntos { get; set; } = new();
        public CitaDto? Cita { get; set; }
        public ExpedienteClinicoDto Expediente { get; set; } = null!;
        public List<HospitalizacioneDto> Hospitalizaciones { get; set; } = new();
        public List<RecetaDto> Receta { get; set; } = new();
        public List<TransaccionesCajaDto> TransaccionesCajas { get; set; } = new();
        public List<VacunasAplicadaDto> VacunasAplicada { get; set; } = new();
        public UsuarioRelacionadoDto Veterinario { get; set; } = null!;
    }
}