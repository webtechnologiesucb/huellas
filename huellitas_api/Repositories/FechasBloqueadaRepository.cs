using AutoMapper;
using huellitas_api.Dtos;
using huellitas_api.Models;
using huellitas_api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace huellitas_api.Repositories
{
    public class FechasBloqueadaRepository : IFechasBloqueadaRepository
    {
        private readonly HuellitasDigitalesContext _context;
        private readonly IMapper _mapper;

        public FechasBloqueadaRepository(HuellitasDigitalesContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<FechasBloqueadaDto>> GetAll()
        {
            var entities = await _context.FechasBloqueadas
                .Include(x => x.Veterinario)
                .Include(x => x.Veterinario).ThenInclude(x => x.Rol)
                .AsSplitQuery()
                .AsNoTracking()
                .ToListAsync();
            return _mapper.Map<List<FechasBloqueadaDto>>(entities);
        }

        public async Task<FechasBloqueadaDto?> GetById(Guid id)
        {
            var entity = await _context.FechasBloqueadas
                .Include(x => x.Veterinario)
                .Include(x => x.Veterinario).ThenInclude(x => x.Rol)
                .AsSplitQuery()
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
            return entity is null ? null : _mapper.Map<FechasBloqueadaDto>(entity);
        }

        public async Task<bool> Create(FechasBloqueadaDto dto)
        {
            var entity = new FechasBloqueada
            {
                Id = dto.Id,
                VeterinarioId = dto.VeterinarioId,
                Fecha = dto.Fecha,
                Motivo = dto.Motivo
            };
            _context.FechasBloqueadas.Add(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Update(Guid id, FechasBloqueadaDto dto)
        {
            var entity = await _context.FechasBloqueadas.FindAsync(id);
            if (entity == null) return false;

            entity.VeterinarioId = dto.VeterinarioId;
            entity.Fecha = dto.Fecha;
            entity.Motivo = dto.Motivo;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(Guid id)
        {
            var entity = await _context.FechasBloqueadas.FindAsync(id);
            if (entity == null) return false;

            _context.FechasBloqueadas.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}