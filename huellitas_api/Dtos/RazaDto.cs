namespace huellitas_api.Dtos
{
    public class RazaDto
    {
        public int Id { get; set; }
        public int EspecieId { get; set; }
        public string Nombre { get; set; } = null!;
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public EspecyDto Especie { get; set; } = null!;
        public List<MascotaDto> Mascota { get; set; } = new();
    }
}