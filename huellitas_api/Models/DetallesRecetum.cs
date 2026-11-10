using System;
using System.Collections.Generic;

namespace huellitas_api.Models;

public partial class DetallesRecetum
{
    public Guid Id { get; set; }

    public Guid RecetaId { get; set; }

    public Guid? ProductoId { get; set; }

    public string? MedicamentoTextoLibre { get; set; }

    public string Dosis { get; set; } = null!;

    public string Frecuencia { get; set; } = null!;

    public string Duracion { get; set; } = null!;

    public virtual Producto? Producto { get; set; }

    public virtual Receta Receta { get; set; } = null!;
}
