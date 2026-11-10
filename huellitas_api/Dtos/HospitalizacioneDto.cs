namespace huellitas_api.Dtos
{
    public class HospitalizacioneDto
    {
        public Guid Id { get; set; }
        public Guid HistorialId { get; set; }
        public Guid MascotaId { get; set; }
        public Guid VeterinarioId { get; set; }
        public DateTime FechaIngreso { get; set; }
        public DateTime? FechaEgreso { get; set; }
        public string Estado { get; set; } = null!;
        public string? Observaciones { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public List<ArchivosAdjuntoDto> ArchivosAdjuntos { get; set; } = new();
        public HistorialClinicoDto Historial { get; set; } = null!;
        public List<HospitalizacionInsumoDto> HospitalizacionInsumos { get; set; } = new();
        public MascotaDto Mascota { get; set; } = null!;
        public List<MonitoreoDiarioDto> MonitoreoDiarios { get; set; } = new();
        public List<TransaccionesCajaDto> TransaccionesCajas { get; set; } = new();
        public List<VacunasAplicadaDto> VacunasAplicada { get; set; } = new();
        public UsuarioRelacionadoDto Veterinario { get; set; } = null!;
    }
}