namespace huellitas_api.Dtos
{
    public class FechasBloqueadaDto
    {
        public Guid Id { get; set; }
        public Guid VeterinarioId { get; set; }
        public DateOnly Fecha { get; set; }
        public string? Motivo { get; set; }

        public UsuarioRelacionadoDto Veterinario { get; set; } = null!;
    }
}