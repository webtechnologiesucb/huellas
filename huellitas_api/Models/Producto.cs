using System;
using System.Collections.Generic;

namespace huellitas_api.Models;

public partial class Producto
{
    public Guid Id { get; set; }

    public int CategoriaId { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public decimal PrecioVenta { get; set; }

    public int StockActual { get; set; }

    public int StockMinimo { get; set; }

    public bool? RequiereReceta { get; set; }

    public bool? EsServicio { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual ICollection<CatalogoVacuna> CatalogoVacunas { get; set; } = new List<CatalogoVacuna>();

    public virtual CategoriasProducto Categoria { get; set; } = null!;

    public virtual ICollection<DetallesRecetum> DetallesReceta { get; set; } = new List<DetallesRecetum>();

    public virtual ICollection<DetallesTransaccion> DetallesTransaccions { get; set; } = new List<DetallesTransaccion>();

    public virtual ICollection<HospitalizacionInsumo> HospitalizacionInsumos { get; set; } = new List<HospitalizacionInsumo>();

    public virtual ICollection<KardexInventario> KardexInventarios { get; set; } = new List<KardexInventario>();

    public virtual ICollection<LotesCaducidad> LotesCaducidads { get; set; } = new List<LotesCaducidad>();
}
