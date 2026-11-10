using System;
using System.Collections.Generic;

namespace huellitas_api.Models;

public partial class CierresCaja
{
    public Guid Id { get; set; }

    public Guid CajeroId { get; set; }

    public DateOnly Fecha { get; set; }

    public string Turno { get; set; } = null!;

    public decimal TotalEfectivo { get; set; }

    public decimal TotalQrTransferencia { get; set; }

    public decimal TotalTarjeta { get; set; }

    public decimal MontoTotalRecaudado { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual Usuario Cajero { get; set; } = null!;
}
