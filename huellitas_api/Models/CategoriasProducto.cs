using System;
using System.Collections.Generic;

namespace huellitas_api.Models;

public partial class CategoriasProducto
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
