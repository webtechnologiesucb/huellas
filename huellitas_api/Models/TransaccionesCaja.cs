using System;
using System.Collections.Generic;

namespace huellitas_api.Models;

public partial class TransaccionesCaja
{
    public Guid Id { get; set; }

    public Guid CajeroId { get; set; }

    public Guid? HistorialId { get; set; }

    public Guid? HospitalizacionId { get; set; }

    public decimal Subtotal { get; set; }

    public decimal? Descuento { get; set; }

    public decimal Total { get; set; }

    public string MetodoPago { get; set; } = null!;

    public string Estado { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Usuario Cajero { get; set; } = null!;

    public virtual ICollection<DetallesTransaccion> DetallesTransaccions { get; set; } = new List<DetallesTransaccion>();

    public virtual HistorialClinico? Historial { get; set; }

    public virtual Hospitalizacione? Hospitalizacion { get; set; }
}
