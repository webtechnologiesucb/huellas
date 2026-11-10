using AutoMapper;
using huellitas_api.Dtos;
using huellitas_api.Models;
using huellitas_api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace huellitas_api.Repositories
{
    public class EspecyRepository : IEspecyRepository
    {
        private readonly HuellitasDigitalesContext _context;
        private readonly IMapper _mapper;

        public EspecyRepository(HuellitasDigitalesContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<EspecyDto>> GetAll()
        {
            var entities = await _context.Especies
                .Include(x => x.CatalogoVacunas)
                .Include(x => x.Razas)
                .Include(x => x.CatalogoVacunas).ThenInclude(x => x.Producto)
                .AsSplitQuery()
                .AsNoTracking()
                .ToListAsync();
            return _mapper.Map<List<EspecyDto>>(entities);
        }

        public async Task<EspecyDto?> GetById(int id)
        {
            var entity = await _context.Especies
                .Include(x => x.CatalogoVacunas)
                .Include(x => x.Razas)
                .Include(x => x.CatalogoVacunas).ThenInclude(x => x.Producto)
                .AsSplitQuery()
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
            return entity is null ? null : _mapper.Map<EspecyDto>(entity);
        }

        public async Task<bool> Create(EspecyDto dto)
        {
            var entity = new Especy
            {
                Id = dto.Id,
                Nombre = dto.Nombre,
                Descripcion = dto.Descripcion,
                CreatedAt = dto.CreatedAt,
                UpdatedAt = dto.UpdatedAt,
                DeletedAt = dto.DeletedAt
            };
            _context.Especies.Add(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Update(int id, EspecyDto dto)
        {
            var entity = await _context.Especies.FindAsync(id);
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
            var entity = await _context.Especies.FindAsync(id);
            if (entity == null) return false;

            _context.Especies.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}