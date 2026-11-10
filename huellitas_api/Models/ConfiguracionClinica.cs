using System;
using System.Collections.Generic;

namespace huellitas_api.Models;

public partial class ConfiguracionClinica
{
    public int Id { get; set; }

    public string Clave { get; set; } = null!;

    public string Valor { get; set; } = null!;

    public string? Descripcion { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
