using System;
using System.Collections.Generic;

namespace huellitas_api.Models;

public partial class RegistroEscaneosQr
{
    public Guid Id { get; set; }

    public Guid MascotaId { get; set; }

    public double Latitud { get; set; }

    public double Longitud { get; set; }

    public string? UserAgent { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual Mascota Mascota { get; set; } = null!;
}
