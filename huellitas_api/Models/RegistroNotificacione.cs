using System;
using System.Collections.Generic;

namespace huellitas_api.Models;

public partial class RegistroNotificacione
{
    public Guid Id { get; set; }

    public Guid UsuarioId { get; set; }

    public string Canal { get; set; } = null!;

    public string Mensaje { get; set; } = null!;

    public string Estado { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public virtual Usuario Usuario { get; set; } = null!;
}
