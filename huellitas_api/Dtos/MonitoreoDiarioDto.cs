namespace huellitas_api.Dtos
{
    public class MonitoreoDiarioDto
    {
        public Guid Id { get; set; }
        public Guid HospitalizacionId { get; set; }
        public Guid ResponsableId { get; set; }
        public string Turno { get; set; } = null!;
        public decimal Peso { get; set; }
        public decimal Temperatura { get; set; }
        public int FrecuenciaCardiaca { get; set; }
        public string? Observaciones { get; set; }
        public DateTime? CreatedAt { get; set; }

        public HospitalizacioneDto Hospitalizacion { get; set; } = null!;
        public UsuarioRelacionadoDto Responsable { get; set; } = null!;
    }
}