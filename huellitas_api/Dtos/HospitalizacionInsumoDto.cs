namespace huellitas_api.Dtos
{
    public class HospitalizacionInsumoDto
    {
        public Guid Id { get; set; }
        public Guid HospitalizacionId { get; set; }
        public Guid? ProductoId { get; set; }
        public int? ServicioId { get; set; }
        public int Cantidad { get; set; }
        public decimal Subtotal { get; set; }
        public DateTime? CreatedAt { get; set; }

        public HospitalizacioneDto Hospitalizacion { get; set; } = null!;
        public ProductoDto? Producto { get; set; }
        public ServicioDto? Servicio { get; set; }
    }
}