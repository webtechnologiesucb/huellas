namespace huellitas_api.Dtos
{
    public class ServicioDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string? Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int DuracionMinutos { get; set; }
        public bool? RequiereVeterinario { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public List<DetallesTransaccionDto> DetallesTransaccions { get; set; } = new();
        public List<HospitalizacionInsumoDto> HospitalizacionInsumos { get; set; } = new();
    }
}