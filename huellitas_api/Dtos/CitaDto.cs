namespace huellitas_api.Dtos
{
    public class CitaDto
    {
        public Guid Id { get; set; }
        public Guid MascotaId { get; set; }
        public Guid VeterinarioId { get; set; }
        public DateTime FechaHora { get; set; }
        public string Origen { get; set; } = null!;
        public string Prioridad { get; set; } = null!;
        public string Estado { get; set; } = null!;
        public string? MotivoCancelacion { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public List<HistorialClinicoDto> HistorialClinicos { get; set; } = new();
        public MascotaDto Mascota { get; set; } = null!;
        public UsuarioRelacionadoDto Veterinario { get; set; } = null!;
    }
}