namespace huellitas_api.Dtos
{
    public class RecetaDto
    {
        public Guid Id { get; set; }
        public Guid HistorialId { get; set; }
        public Guid VeterinarioId { get; set; }
        public string? IndicacionesGenerales { get; set; }
        public DateTime? CreatedAt { get; set; }

        public List<DetallesRecetumDto> DetallesReceta { get; set; } = new();
        public HistorialClinicoDto Historial { get; set; } = null!;
        public UsuarioRelacionadoDto Veterinario { get; set; } = null!;
    }
}