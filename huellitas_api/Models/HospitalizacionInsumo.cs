using System;
using System.Collections.Generic;

namespace huellitas_api.Models;

public partial class HospitalizacionInsumo
{
    public Guid Id { get; set; }

    public Guid HospitalizacionId { get; set; }

    public Guid? ProductoId { get; set; }

    public int? ServicioId { get; set; }

    public int Cantidad { get; set; }

    public decimal Subtotal { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual Hospitalizacione Hospitalizacion { get; set; } = null!;

    public virtual Producto? Producto { get; set; }

    public virtual Servicio? Servicio { get; set; }
}
