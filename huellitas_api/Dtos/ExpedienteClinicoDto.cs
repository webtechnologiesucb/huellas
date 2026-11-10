namespace huellitas_api.Dtos
{
    public class ExpedienteClinicoDto
    {
        public Guid Id { get; set; }
        public Guid MascotaId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public List<HistorialClinicoDto> HistorialClinicos { get; set; } = new();
        public MascotaDto Mascota { get; set; } = null!;
    }
}