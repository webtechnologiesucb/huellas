using System;
using System.Collections.Generic;

namespace huellitas_api.Models;

public partial class FechasBloqueada
{
    public Guid Id { get; set; }

    public Guid VeterinarioId { get; set; }

    public DateOnly Fecha { get; set; }

    public string? Motivo { get; set; }

    public virtual Usuario Veterinario { get; set; } = null!;
}
