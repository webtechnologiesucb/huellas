namespace huellitas_api.Dtos
{
    public class CatalogoVacunaDto
    {
        public int Id { get; set; }
        public int EspecieId { get; set; }
        public Guid? ProductoId { get; set; }
        public string Nombre { get; set; } = null!;
        public int DiasParaRefuerzo { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public EspecyDto Especie { get; set; } = null!;
        public ProductoDto? Producto { get; set; }
        public List<VacunasAplicadaDto> VacunasAplicada { get; set; } = new();
    }
}