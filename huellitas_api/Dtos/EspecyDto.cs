namespace huellitas_api.Dtos
{
    public class EspecyDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string? Descripcion { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public List<CatalogoVacunaDto> CatalogoVacunas { get; set; } = new();
        public List<RazaDto> Razas { get; set; } = new();
    }
}