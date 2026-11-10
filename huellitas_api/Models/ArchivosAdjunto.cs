using System;
using System.Collections.Generic;

namespace huellitas_api.Models;

public partial class ArchivosAdjunto
{
    public Guid Id { get; set; }

    public Guid? HistorialId { get; set; }

    public Guid? HospitalizacionId { get; set; }

    public string UrlArchivo { get; set; } = null!;

    public string TipoArchivo { get; set; } = null!;

    public string NombreArchivo { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public virtual HistorialClinico? Historial { get; set; }

    public virtual Hospitalizacione? Hospitalizacion { get; set; }
}
