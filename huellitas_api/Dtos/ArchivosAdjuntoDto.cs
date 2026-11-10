namespace huellitas_api.Dtos
{
    public class ArchivosAdjuntoDto
    {
        public Guid Id { get; set; }
        public Guid? HistorialId { get; set; }
        public Guid? HospitalizacionId { get; set; }
        public string UrlArchivo { get; set; } = null!;
        public string TipoArchivo { get; set; } = null!;
        public string NombreArchivo { get; set; } = null!;
        public DateTime? CreatedAt { get; set; }

        public HistorialClinicoDto? Historial { get; set; }
        public HospitalizacioneDto? Hospitalizacion { get; set; }
    }
}