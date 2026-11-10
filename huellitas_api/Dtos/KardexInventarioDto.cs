namespace huellitas_api.Dtos
{
    public class KardexInventarioDto
    {
        public Guid Id { get; set; }
        public Guid ProductoId { get; set; }
        public string TipoMovimiento { get; set; } = null!;
        public int Cantidad { get; set; }
        public int SaldoResultante { get; set; }
        public string? Motivo { get; set; }
        public DateTime? CreatedAt { get; set; }

        public ProductoDto Producto { get; set; } = null!;
    }
}