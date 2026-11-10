namespace huellitas_api.Dtos
{
    public class InteraccionesBotDto
    {
        public Guid Id { get; set; }
        public Guid? MascotaId { get; set; }
        public string MensajeUsuario { get; set; } = null!;
        public string? IntencionDetectada { get; set; }
        public string RespuestaIa { get; set; } = null!;
        public DateTime? CreatedAt { get; set; }

        public MascotaDto? Mascota { get; set; }
    }
}