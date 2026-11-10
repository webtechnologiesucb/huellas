using System;
using System.Collections.Generic;

namespace huellitas_api.Models;

public partial class MonitoreoDiario
{
    public Guid Id { get; set; }

    public Guid HospitalizacionId { get; set; }

    public Guid ResponsableId { get; set; }

    public string Turno { get; set; } = null!;

    public decimal Peso { get; set; }

    public decimal Temperatura { get; set; }

    public int FrecuenciaCardiaca { get; set; }

    public string? Observaciones { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual Hospitalizacione Hospitalizacion { get; set; } = null!;

    public virtual Usuario Responsable { get; set; } = null!;
}
