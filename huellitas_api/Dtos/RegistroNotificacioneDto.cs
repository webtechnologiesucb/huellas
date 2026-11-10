namespace huellitas_api.Dtos
{
    public class RegistroNotificacioneDto
    {
        public Guid Id { get; set; }
        public Guid UsuarioId { get; set; }
        public string Canal { get; set; } = null!;
        public string Mensaje { get; set; } = null!;
        public string Estado { get; set; } = null!;
        public DateTime? CreatedAt { get; set; }

        public UsuarioRelacionadoDto Usuario { get; set; } = null!;
    }
}