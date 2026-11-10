using System;
using System.Collections.Generic;

namespace huellitas_api.Models;

public partial class Especy
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual ICollection<CatalogoVacuna> CatalogoVacunas { get; set; } = new List<CatalogoVacuna>();

    public virtual ICollection<Raza> Razas { get; set; } = new List<Raza>();
}
