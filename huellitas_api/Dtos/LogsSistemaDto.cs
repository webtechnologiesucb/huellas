namespace huellitas_api.Dtos
{
    public class LogsSistemaDto
    {
        public Guid Id { get; set; }
        public Guid? UsuarioId { get; set; }
        public string Categoria { get; set; } = null!;
        public string Accion { get; set; } = null!;
        public string? Detalles { get; set; }
        public DateTime? CreatedAt { get; set; }

        public UsuarioRelacionadoDto? Usuario { get; set; }
    }
}