namespace huellitas_api.Dtos
{
    public class RegistroEscaneosQrDto
    {
        public Guid Id { get; set; }
        public Guid MascotaId { get; set; }
        public double Latitud { get; set; }
        public double Longitud { get; set; }
        public string? UserAgent { get; set; }
        public DateTime? CreatedAt { get; set; }

        public MascotaDto Mascota { get; set; } = null!;
    }
}