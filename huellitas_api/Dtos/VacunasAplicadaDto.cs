namespace huellitas_api.Dtos
{
    public class VacunasAplicadaDto
    {
        public Guid Id { get; set; }
        public Guid? HistorialId { get; set; }
        public Guid? HospitalizacionId { get; set; }
        public int CatalogoVacunaId { get; set; }
        public Guid LoteId { get; set; }
        public DateTime FechaAplicacion { get; set; }
        public DateOnly FechaProximaDosis { get; set; }

        public CatalogoVacunaDto CatalogoVacuna { get; set; } = null!;
        public HistorialClinicoDto? Historial { get; set; }
        public HospitalizacioneDto? Hospitalizacion { get; set; }
        public LotesCaducidadDto Lote { get; set; } = null!;
    }
}