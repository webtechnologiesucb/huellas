namespace huellitas_api.Dtos
{
    public class LotesCaducidadDto
    {
        public Guid Id { get; set; }
        public Guid ProductoId { get; set; }
        public string NumeroLote { get; set; } = null!;
        public DateOnly FechaVencimiento { get; set; }
        public int CantidadInicial { get; set; }
        public int CantidadActual { get; set; }
        public DateTime? CreatedAt { get; set; }

        public ProductoDto Producto { get; set; } = null!;
        public List<VacunasAplicadaDto> VacunasAplicada { get; set; } = new();
    }
}