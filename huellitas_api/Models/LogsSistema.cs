using System;
using System.Collections.Generic;

namespace huellitas_api.Models;

public partial class LogsSistema
{
    public Guid Id { get; set; }

    public Guid? UsuarioId { get; set; }

    public string Categoria { get; set; } = null!;

    public string Accion { get; set; } = null!;

    public string? Detalles { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual Usuario? Usuario { get; set; }
}
