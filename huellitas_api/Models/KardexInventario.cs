using System;
using System.Collections.Generic;

namespace huellitas_api.Models;

public partial class KardexInventario
{
    public Guid Id { get; set; }

    public Guid ProductoId { get; set; }

    public string TipoMovimiento { get; set; } = null!;

    public int Cantidad { get; set; }

    public int SaldoResultante { get; set; }

    public string? Motivo { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual Producto Producto { get; set; } = null!;
}
