namespace huellitas_api.Dtos
{
    public class DetallesRecetumDto
    {
        public Guid Id { get; set; }
        public Guid RecetaId { get; set; }
        public Guid? ProductoId { get; set; }
        public string? MedicamentoTextoLibre { get; set; }
        public string Dosis { get; set; } = null!;
        public string Frecuencia { get; set; } = null!;
        public string Duracion { get; set; } = null!;

        public ProductoDto? Producto { get; set; }
        public RecetaDto Receta { get; set; } = null!;
    }
}