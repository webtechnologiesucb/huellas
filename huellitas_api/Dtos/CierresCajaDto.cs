namespace huellitas_api.Dtos
{
    public class CierresCajaDto
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

        public UsuarioRelacionadoDto Cajero { get; set; } = null!;
    }
}