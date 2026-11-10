using AutoMapper;
using huellitas_api.Dtos;
using huellitas_api.Models;
using huellitas_api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace huellitas_api.Repositories
{
    public class RecetaRepository : IRecetaRepository
    {
        private readonly HuellitasDigitalesContext _context;
        private readonly IMapper _mapper;

        public RecetaRepository(HuellitasDigitalesContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<RecetaDto>> GetAll()
        {
            var entities = await _context.Recetas
                .Include(x => x.DetallesReceta)
                .Include(x => x.Historial)
                .Include(x => x.Veterinario)
                .Include(x => x.DetallesReceta).ThenInclude(x => x.Producto)
                .Include(x => x.Historial).ThenInclude(x => x.Cita)
                .Include(x => x.Historial).ThenInclude(x => x.Expediente)
                .Include(x => x.Historial).ThenInclude(x => x.Veterinario)
                .Include(x => x.Veterinario).ThenInclude(x => x.Rol)
                .AsSplitQuery()
                .AsNoTracking()
                .ToListAsync();
            return _mapper.Map<List<RecetaDto>>(entities);
        }

        public async Task<RecetaDto?> GetById(Guid id)
        {
            var entity = await _context.Recetas
                .Include(x => x.DetallesReceta)
                .Include(x => x.Historial)
                .Include(x => x.Veterinario)
                .Include(x => x.DetallesReceta).ThenInclude(x => x.Producto)
                .Include(x => x.Historial).ThenInclude(x => x.Cita)
                .Include(x => x.Historial).ThenInclude(x => x.Expediente)
                .Include(x => x.Historial).ThenInclude(x => x.Veterinario)
                .Include(x => x.Veterinario).ThenInclude(x => x.Rol)
                .AsSplitQuery()
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
            return entity is null ? null : _mapper.Map<RecetaDto>(entity);
        }

        public async Task<bool> Create(RecetaDto dto)
        {
            var entity = new Receta
            {
                Id = dto.Id,
                HistorialId = dto.HistorialId,
                VeterinarioId = dto.VeterinarioId,
                IndicacionesGenerales = dto.IndicacionesGenerales,
                CreatedAt = dto.CreatedAt
            };
            _context.Recetas.Add(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Update(Guid id, RecetaDto dto)
        {
            var entity = await _context.Recetas.FindAsync(id);
            if (entity == null) return false;

            entity.HistorialId = dto.HistorialId;
            entity.VeterinarioId = dto.VeterinarioId;
            entity.IndicacionesGenerales = dto.IndicacionesGenerales;
            entity.CreatedAt = dto.CreatedAt;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(Guid id)
        {
            var entity = await _context.Recetas.FindAsync(id);
            if (entity == null) return false;

            _context.Recetas.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}