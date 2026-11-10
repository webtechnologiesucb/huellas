namespace huellitas_api.Dtos
{
    public class ConfiguracionClinicaDto
    {
        public int Id { get; set; }
        public string Clave { get; set; } = null!;
        public string Valor { get; set; } = null!;
        public string? Descripcion { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}