using AutoMapper;
using huellitas_api.Dtos;
using huellitas_api.Models;
using huellitas_api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace huellitas_api.Repositories
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly HuellitasDigitalesContext _context;
        private readonly IMapper _mapper;

        public ProductoRepository(HuellitasDigitalesContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<ProductoDto>> GetAll()
        {
            var entities = await _context.Productos
                .Include(x => x.CatalogoVacunas)
                .Include(x => x.Categoria)
                .Include(x => x.DetallesReceta)
                .Include(x => x.DetallesTransaccions)
                .Include(x => x.HospitalizacionInsumos)
                .Include(x => x.KardexInventarios)
                .Include(x => x.LotesCaducidads)
                .Include(x => x.CatalogoVacunas).ThenInclude(x => x.Especie)
                .Include(x => x.DetallesReceta).ThenInclude(x => x.Receta)
                .Include(x => x.DetallesTransaccions).ThenInclude(x => x.Servicio)
                .Include(x => x.DetallesTransaccions).ThenInclude(x => x.Transaccion)
                .Include(x => x.HospitalizacionInsumos).ThenInclude(x => x.Hospitalizacion)
                .Include(x => x.HospitalizacionInsumos).ThenInclude(x => x.Servicio)
                .AsSplitQuery()
                .AsNoTracking()
                .ToListAsync();
            return _mapper.Map<List<ProductoDto>>(entities);
        }

        public async Task<ProductoDto?> GetById(Guid id)
        {
            var entity = await _context.Productos
                .Include(x => x.CatalogoVacunas)
                .Include(x => x.Categoria)
                .Include(x => x.DetallesReceta)
                .Include(x => x.DetallesTransaccions)
                .Include(x => x.HospitalizacionInsumos)
                .Include(x => x.KardexInventarios)
                .Include(x => x.LotesCaducidads)
                .Include(x => x.CatalogoVacunas).ThenInclude(x => x.Especie)
                .Include(x => x.DetallesReceta).ThenInclude(x => x.Receta)
                .Include(x => x.DetallesTransaccions).ThenInclude(x => x.Servicio)
                .Include(x => x.DetallesTransaccions).ThenInclude(x => x.Transaccion)
                .Include(x => x.HospitalizacionInsumos).ThenInclude(x => x.Hospitalizacion)
                .Include(x => x.HospitalizacionInsumos).ThenInclude(x => x.Servicio)
                .AsSplitQuery()
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
            return entity is null ? null : _mapper.Map<ProductoDto>(entity);
        }

        public async Task<bool> Create(ProductoDto dto)
        {
            var entity = new Producto
            {
                Id = dto.Id,
                CategoriaId = dto.CategoriaId,
                Nombre = dto.Nombre,
                Descripcion = dto.Descripcion,
                PrecioVenta = dto.PrecioVenta,
                StockActual = dto.StockActual,
                StockMinimo = dto.StockMinimo,
                RequiereReceta = dto.RequiereReceta,
                EsServicio = dto.EsServicio,
                CreatedAt = dto.CreatedAt,
                UpdatedAt = dto.UpdatedAt,
                DeletedAt = dto.DeletedAt
            };
            _context.Productos.Add(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Update(Guid id, ProductoDto dto)
        {
            var entity = await _context.Productos.FindAsync(id);
            if (entity == null) return false;

            entity.CategoriaId = dto.CategoriaId;
            entity.Nombre = dto.Nombre;
            entity.Descripcion = dto.Descripcion;
            entity.PrecioVenta = dto.PrecioVenta;
            entity.StockActual = dto.StockActual;
            entity.StockMinimo = dto.StockMinimo;
            entity.RequiereReceta = dto.RequiereReceta;
            entity.EsServicio = dto.EsServicio;
            entity.CreatedAt = dto.CreatedAt;
            entity.UpdatedAt = dto.UpdatedAt;
            entity.DeletedAt = dto.DeletedAt;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(Guid id)
        {
            var entity = await _context.Productos.FindAsync(id);
            if (entity == null) return false;

            _context.Productos.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}