using System;
using System.Collections.Generic;

namespace huellitas_api.Models;

public partial class ExpedienteClinico
{
    public Guid Id { get; set; }

    public Guid MascotaId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual ICollection<HistorialClinico> HistorialClinicos { get; set; } = new List<HistorialClinico>();

    public virtual Mascota Mascota { get; set; } = null!;
}
