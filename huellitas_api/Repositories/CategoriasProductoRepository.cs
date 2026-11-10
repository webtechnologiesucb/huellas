using AutoMapper;
using huellitas_api.Dtos;
using huellitas_api.Models;
using huellitas_api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace huellitas_api.Repositories
{
    public class CategoriasProductoRepository : ICategoriasProductoRepository
    {
        private readonly HuellitasDigitalesContext _context;
        private readonly IMapper _mapper;

        public CategoriasProductoRepository(HuellitasDigitalesContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<CategoriasProductoDto>> GetAll()
        {
            var entities = await _context.CategoriasProductos
                .Include(x => x.Productos)
                .AsSplitQuery()
                .AsNoTracking()
                .ToListAsync();
            return _mapper.Map<List<CategoriasProductoDto>>(entities);
        }

        public async Task<CategoriasProductoDto?> GetById(int id)
        {
            var entity = await _context.CategoriasProductos
                .Include(x => x.Productos)
                .AsSplitQuery()
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
            return entity is null ? null : _mapper.Map<CategoriasProductoDto>(entity);
        }

        public async Task<bool> Create(CategoriasProductoDto dto)
        {
            var entity = new CategoriasProducto
            {
                Id = dto.Id,
                Nombre = dto.Nombre,
                Descripcion = dto.Descripcion,
                CreatedAt = dto.CreatedAt,
                UpdatedAt = dto.UpdatedAt,
                DeletedAt = dto.DeletedAt
            };
            _context.CategoriasProductos.Add(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Update(int id, CategoriasProductoDto dto)
        {
            var entity = await _context.CategoriasProductos.FindAsync(id);
            if (entity == null) return false;

            entity.Nombre = dto.Nombre;
            entity.Descripcion = dto.Descripcion;
            entity.CreatedAt = dto.CreatedAt;
            entity.UpdatedAt = dto.UpdatedAt;
            entity.DeletedAt = dto.DeletedAt;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            var entity = await _context.CategoriasProductos.FindAsync(id);
            if (entity == null) return false;

            _context.CategoriasProductos.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}