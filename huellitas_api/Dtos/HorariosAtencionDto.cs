namespace huellitas_api.Dtos
{
    public class HorariosAtencionDto
    {
        public Guid Id { get; set; }
        public Guid VeterinarioId { get; set; }
        public int DiaSemana { get; set; }
        public TimeOnly HoraInicio { get; set; }
        public TimeOnly HoraFin { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public UsuarioRelacionadoDto Veterinario { get; set; } = null!;
    }
}