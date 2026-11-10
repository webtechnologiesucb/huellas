using System;
using System.Collections.Generic;

namespace huellitas_api.Models;

public partial class LotesCaducidad
{
    public Guid Id { get; set; }

    public Guid ProductoId { get; set; }

    public string NumeroLote { get; set; } = null!;

    public DateOnly FechaVencimiento { get; set; }

    public int CantidadInicial { get; set; }

    public int CantidadActual { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual Producto Producto { get; set; } = null!;

    public virtual ICollection<VacunasAplicada> VacunasAplicada { get; set; } = new List<VacunasAplicada>();
}
