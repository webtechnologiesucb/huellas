namespace huellitas_api.Dtos
{
    public class ProductoDto
    {
        public Guid Id { get; set; }
        public int CategoriaId { get; set; }
        public string Nombre { get; set; } = null!;
        public string? Descripcion { get; set; }
        public decimal PrecioVenta { get; set; }
        public int StockActual { get; set; }
        public int StockMinimo { get; set; }
        public bool? RequiereReceta { get; set; }
        public bool? EsServicio { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public List<CatalogoVacunaDto> CatalogoVacunas { get; set; } = new();
        public CategoriasProductoDto Categoria { get; set; } = null!;
        public List<DetallesRecetumDto> DetallesReceta { get; set; } = new();
        public List<DetallesTransaccionDto> DetallesTransaccions { get; set; } = new();
        public List<HospitalizacionInsumoDto> HospitalizacionInsumos { get; set; } = new();
        public List<KardexInventarioDto> KardexInventarios { get; set; } = new();
        public List<LotesCaducidadDto> LotesCaducidads { get; set; } = new();
    }
}