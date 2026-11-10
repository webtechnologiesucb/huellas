using System;
using System.Collections.Generic;

namespace huellitas_api.Models;

public partial class HorariosAtencion
{
    public Guid Id { get; set; }

    public Guid VeterinarioId { get; set; }

    public int DiaSemana { get; set; }

    public TimeOnly HoraInicio { get; set; }

    public TimeOnly HoraFin { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Usuario Veterinario { get; set; } = null!;
}
