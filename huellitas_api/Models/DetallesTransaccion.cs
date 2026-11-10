using System;
using System.Collections.Generic;

namespace huellitas_api.Models;

public partial class DetallesTransaccion
{
    public Guid Id { get; set; }

    public Guid TransaccionId { get; set; }

    public Guid? ProductoId { get; set; }

    public int? ServicioId { get; set; }

    public int Cantidad { get; set; }

    public decimal PrecioUnitario { get; set; }

    public decimal Subtotal { get; set; }

    public string TipoCobro { get; set; } = null!;

    public virtual Producto? Producto { get; set; }

    public virtual Servicio? Servicio { get; set; }

    public virtual TransaccionesCaja Transaccion { get; set; } = null!;
}
