using System;
using System.Collections.Generic;

namespace huellitas_api.Models;

public partial class CatalogoVacuna
{
    public int Id { get; set; }

    public int EspecieId { get; set; }

    public Guid? ProductoId { get; set; }

    public string Nombre { get; set; } = null!;

    public int DiasParaRefuerzo { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual Especy Especie { get; set; } = null!;

    public virtual Producto? Producto { get; set; }

    public virtual ICollection<VacunasAplicada> VacunasAplicada { get; set; } = new List<VacunasAplicada>();
}
