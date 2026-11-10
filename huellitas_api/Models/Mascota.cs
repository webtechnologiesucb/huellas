using System;
using System.Collections.Generic;

namespace huellitas_api.Models;

public partial class Mascota
{
    public Guid Id { get; set; }

    public Guid DueñoId { get; set; }

    public int RazaId { get; set; }

    public string Nombre { get; set; } = null!;

    public string Genero { get; set; } = null!;

    public DateOnly? FechaNacimiento { get; set; }

    public decimal? PesoActual { get; set; }

    public string HashQrIdentidad { get; set; } = null!;

    public bool? Perdida { get; set; }

    public double? LatitudPerdida { get; set; }

    public double? LongitudPerdida { get; set; }

    public string? PuntoEntrega { get; set; }

    public decimal? Recompensa { get; set; }

    public string? MensajeEncontrado { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual ICollection<Cita> Cita { get; set; } = new List<Cita>();

    public virtual Usuario Dueño { get; set; } = null!;

    public virtual ExpedienteClinico? ExpedienteClinico { get; set; }

    public virtual ICollection<Hospitalizacione> Hospitalizaciones { get; set; } = new List<Hospitalizacione>();

    public virtual ICollection<InteraccionesBot> InteraccionesBots { get; set; } = new List<InteraccionesBot>();

    public virtual Raza Raza { get; set; } = null!;

    public virtual ICollection<RegistroEscaneosQr> RegistroEscaneosQrs { get; set; } = new List<RegistroEscaneosQr>();
}
