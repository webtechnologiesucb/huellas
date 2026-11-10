using AutoMapper;
using huellitas_api.Dtos;
using huellitas_api.Models;
using huellitas_api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace huellitas_api.Repositories
{
    public class RazaRepository : IRazaRepository
    {
        private readonly HuellitasDigitalesContext _context;
        private readonly IMapper _mapper;

        public RazaRepository(HuellitasDigitalesContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<RazaDto>> GetAll()
        {
            var entities = await _context.Razas
                .Include(x => x.Especie)
                .Include(x => x.Mascota)
                .Include(x => x.Mascota).ThenInclude(x => x.Dueño)
                .Include(x => x.Mascota).ThenInclude(x => x.ExpedienteClinico)
                .AsSplitQuery()
                .AsNoTracking()
                .ToListAsync();
            return _mapper.Map<List<RazaDto>>(entities);
        }

        public async Task<RazaDto?> GetById(int id)
        {
            var entity = await _context.Razas
                .Include(x => x.Especie)
                .Include(x => x.Mascota)
                .Include(x => x.Mascota).ThenInclude(x => x.Dueño)
                .Include(x => x.Mascota).ThenInclude(x => x.ExpedienteClinico)
                .AsSplitQuery()
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
            return entity is null ? null : _mapper.Map<RazaDto>(entity);
        }

        public async Task<bool> Create(RazaDto dto)
        {
            var entity = new Raza
            {
                Id = dto.Id,
                EspecieId = dto.EspecieId,
                Nombre = dto.Nombre,
                CreatedAt = dto.CreatedAt,
                UpdatedAt = dto.UpdatedAt,
                DeletedAt = dto.DeletedAt
            };
            _context.Razas.Add(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Update(int id, RazaDto dto)
        {
            var entity = await _context.Razas.FindAsync(id);
            if (entity == null) return false;

            entity.EspecieId = dto.EspecieId;
            entity.Nombre = dto.Nombre;
            entity.CreatedAt = dto.CreatedAt;
            entity.UpdatedAt = dto.UpdatedAt;
            entity.DeletedAt = dto.DeletedAt;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            var entity = await _context.Razas.FindAsync(id);
            if (entity == null) return false;

            _context.Razas.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}