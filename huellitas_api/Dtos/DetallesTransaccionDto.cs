namespace huellitas_api.Dtos
{
    public class DetallesTransaccionDto
    {
        public Guid Id { get; set; }
        public Guid TransaccionId { get; set; }
        public Guid? ProductoId { get; set; }
        public int? ServicioId { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Subtotal { get; set; }
        public string TipoCobro { get; set; } = null!;

        public ProductoDto? Producto { get; set; }
        public ServicioDto? Servicio { get; set; }
        public TransaccionesCajaDto Transaccion { get; set; } = null!;
    }
}