using System;
using System.Collections.Generic;

namespace huellitas_api.Models;

public partial class Hospitalizacione
{
    public Guid Id { get; set; }

    public Guid HistorialId { get; set; }

    public Guid MascotaId { get; set; }

    public Guid VeterinarioId { get; set; }

    public DateTime FechaIngreso { get; set; }

    public DateTime? FechaEgreso { get; set; }

    public string Estado { get; set; } = null!;

    public string? Observaciones { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<ArchivosAdjunto> ArchivosAdjuntos { get; set; } = new List<ArchivosAdjunto>();

    public virtual HistorialClinico Historial { get; set; } = null!;

    public virtual ICollection<HospitalizacionInsumo> HospitalizacionInsumos { get; set; } = new List<HospitalizacionInsumo>();

    public virtual Mascota Mascota { get; set; } = null!;

    public virtual ICollection<MonitoreoDiario> MonitoreoDiarios { get; set; } = new List<MonitoreoDiario>();

    public virtual ICollection<TransaccionesCaja> TransaccionesCajas { get; set; } = new List<TransaccionesCaja>();

    public virtual ICollection<VacunasAplicada> VacunasAplicada { get; set; } = new List<VacunasAplicada>();

    public virtual Usuario Veterinario { get; set; } = null!;
}
