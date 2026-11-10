using System;
using System.Collections.Generic;

namespace huellitas_api.Models;

public partial class Receta
{
    public Guid Id { get; set; }

    public Guid HistorialId { get; set; }

    public Guid VeterinarioId { get; set; }

    public string? IndicacionesGenerales { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<DetallesRecetum> DetallesReceta { get; set; } = new List<DetallesRecetum>();

    public virtual HistorialClinico Historial { get; set; } = null!;

    public virtual Usuario Veterinario { get; set; } = null!;
}
