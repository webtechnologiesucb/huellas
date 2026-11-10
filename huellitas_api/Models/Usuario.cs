using System;
using System.Collections.Generic;

namespace huellitas_api.Models;

public partial class Usuario
{
    public Guid Id { get; set; }

    public int RolId { get; set; }

    public string Nombres { get; set; } = null!;

    public string Apellidos { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public string? Telefono { get; set; }

    public int? IntentosFallidos { get; set; }

    public DateTime? BloqueadoHasta { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual ICollection<CierresCaja> CierresCajas { get; set; } = new List<CierresCaja>();

    public virtual ICollection<Cita> Cita { get; set; } = new List<Cita>();

    public virtual ICollection<FechasBloqueada> FechasBloqueada { get; set; } = new List<FechasBloqueada>();

    public virtual ICollection<HistorialClinico> HistorialClinicos { get; set; } = new List<HistorialClinico>();

    public virtual ICollection<HorariosAtencion> HorariosAtencions { get; set; } = new List<HorariosAtencion>();

    public virtual ICollection<Hospitalizacione> Hospitalizaciones { get; set; } = new List<Hospitalizacione>();

    public virtual ICollection<LogsSistema> LogsSistemas { get; set; } = new List<LogsSistema>();

    public virtual ICollection<Mascota> Mascota { get; set; } = new List<Mascota>();

    public virtual ICollection<MonitoreoDiario> MonitoreoDiarios { get; set; } = new List<MonitoreoDiario>();

    public virtual ICollection<Receta> Receta { get; set; } = new List<Receta>();

    public virtual ICollection<RegistroNotificacione> RegistroNotificaciones { get; set; } = new List<RegistroNotificacione>();

    public virtual Role Rol { get; set; } = null!;

    public virtual ICollection<TransaccionesCaja> TransaccionesCajas { get; set; } = new List<TransaccionesCaja>();
}
