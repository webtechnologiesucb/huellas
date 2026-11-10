using System;
using System.Collections.Generic;

namespace huellitas_api.Models;

public partial class Cita
{
    public Guid Id { get; set; }

    public Guid MascotaId { get; set; }

    public Guid VeterinarioId { get; set; }

    public DateTime FechaHora { get; set; }

    public string Origen { get; set; } = null!;

    public string Prioridad { get; set; } = null!;

    public string Estado { get; set; } = null!;

    public string? MotivoCancelacion { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual ICollection<HistorialClinico> HistorialClinicos { get; set; } = new List<HistorialClinico>();

    public virtual Mascota Mascota { get; set; } = null!;

    public virtual Usuario Veterinario { get; set; } = null!;
}
