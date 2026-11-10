using System;
using System.Collections.Generic;

namespace huellitas_api.Models;

public partial class Servicio
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public decimal Precio { get; set; }

    public int DuracionMinutos { get; set; }

    public bool? RequiereVeterinario { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual ICollection<DetallesTransaccion> DetallesTransaccions { get; set; } = new List<DetallesTransaccion>();

    public virtual ICollection<HospitalizacionInsumo> HospitalizacionInsumos { get; set; } = new List<HospitalizacionInsumo>();
}
