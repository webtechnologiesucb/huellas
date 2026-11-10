using System;
using System.Collections.Generic;

namespace huellitas_api.Models;

public partial class InteraccionesBot
{
    public Guid Id { get; set; }

    public Guid? MascotaId { get; set; }

    public string MensajeUsuario { get; set; } = null!;

    public string? IntencionDetectada { get; set; }

    public string RespuestaIa { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public virtual Mascota? Mascota { get; set; }
}
