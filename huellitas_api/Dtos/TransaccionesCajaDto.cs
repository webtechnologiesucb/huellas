namespace huellitas_api.Dtos
{
    public class TransaccionesCajaDto
    {
        public Guid Id { get; set; }
        public Guid CajeroId { get; set; }
        public Guid? HistorialId { get; set; }
        public Guid? HospitalizacionId { get; set; }
        public decimal Subtotal { get; set; }
        public decimal? Descuento { get; set; }
        public decimal Total { get; set; }
        public string MetodoPago { get; set; } = null!;
        public string Estado { get; set; } = null!;
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public UsuarioRelacionadoDto Cajero { get; set; } = null!;
        public List<DetallesTransaccionDto> DetallesTransaccions { get; set; } = new();
        public HistorialClinicoDto? Historial { get; set; }
        public HospitalizacioneDto? Hospitalizacion { get; set; }
    }
}