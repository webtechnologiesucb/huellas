using System;
using System.Collections.Generic;

namespace huellitas_api.Models;

public partial class Raza
{
    public int Id { get; set; }

    public int EspecieId { get; set; }

    public string Nombre { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual Especy Especie { get; set; } = null!;

    public virtual ICollection<Mascota> Mascota { get; set; } = new List<Mascota>();
}
