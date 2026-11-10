using System;
using System.Collections.Generic;

namespace huellitas_api.Models;

public partial class HistorialClinico
{
    public Guid Id { get; set; }

    public Guid ExpedienteId { get; set; }

    public Guid? CitaId { get; set; }

    public Guid VeterinarioId { get; set; }

    public decimal Peso { get; set; }

    public decimal Temperatura { get; set; }

    public int FrecuenciaCardiaca { get; set; }

    public int FrecuenciaRespiratoria { get; set; }

    public string MotivoConsulta { get; set; } = null!;

    public string Diagnostico { get; set; } = null!;

    public string? NotasInternas { get; set; }

    public string Estado { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual ICollection<ArchivosAdjunto> ArchivosAdjuntos { get; set; } = new List<ArchivosAdjunto>();

    public virtual Cita? Cita { get; set; }

    public virtual ExpedienteClinico Expediente { get; set; } = null!;

    public virtual ICollection<Hospitalizacione> Hospitalizaciones { get; set; } = new List<Hospitalizacione>();

    public virtual ICollection<Receta> Receta { get; set; } = new List<Receta>();

    public virtual ICollection<TransaccionesCaja> TransaccionesCajas { get; set; } = new List<TransaccionesCaja>();

    public virtual ICollection<VacunasAplicada> VacunasAplicada { get; set; } = new List<VacunasAplicada>();

    public virtual Usuario Veterinario { get; set; } = null!;
}
