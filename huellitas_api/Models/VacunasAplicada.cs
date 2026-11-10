using System;
using System.Collections.Generic;

namespace huellitas_api.Models;

public partial class VacunasAplicada
{
    public Guid Id { get; set; }

    public Guid? HistorialId { get; set; }

    public Guid? HospitalizacionId { get; set; }

    public int CatalogoVacunaId { get; set; }

    public Guid LoteId { get; set; }

    public DateTime FechaAplicacion { get; set; }

    public DateOnly FechaProximaDosis { get; set; }

    public virtual CatalogoVacuna CatalogoVacuna { get; set; } = null!;

    public virtual HistorialClinico? Historial { get; set; }

    public virtual Hospitalizacione? Hospitalizacion { get; set; }

    public virtual LotesCaducidad Lote { get; set; } = null!;
}
