using AutoMapper;
using huellitas_api.Dtos;
using huellitas_api.Models;
using huellitas_api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace huellitas_api.Repositories
{
    public class HorariosAtencionRepository : IHorariosAtencionRepository
    {
        private readonly HuellitasDigitalesContext _context;
        private readonly IMapper _mapper;

        public HorariosAtencionRepository(HuellitasDigitalesContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<HorariosAtencionDto>> GetAll()
        {
            var entities = await _context.HorariosAtencions
                .Include(x => x.Veterinario)
                .Include(x => x.Veterinario).ThenInclude(x => x.Rol)
                .AsSplitQuery()
                .AsNoTracking()
                .ToListAsync();
            return _mapper.Map<List<HorariosAtencionDto>>(entities);
        }

        public async Task<HorariosAtencionDto?> GetById(Guid id)
        {
            var entity = await _context.HorariosAtencions
                .Include(x => x.Veterinario)
                .Include(x => x.Veterinario).ThenInclude(x => x.Rol)
                .AsSplitQuery()
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
            return entity is null ? null : _mapper.Map<HorariosAtencionDto>(entity);
        }

        public async Task<bool> Create(HorariosAtencionDto dto)
        {
            var entity = new HorariosAtencion
            {
                Id = dto.Id,
                VeterinarioId = dto.VeterinarioId,
                DiaSemana = dto.DiaSemana,
                HoraInicio = dto.HoraInicio,
                HoraFin = dto.HoraFin,
                CreatedAt = dto.CreatedAt,
                UpdatedAt = dto.UpdatedAt
            };
            _context.HorariosAtencions.Add(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Update(Guid id, HorariosAtencionDto dto)
        {
            var entity = await _context.HorariosAtencions.FindAsync(id);
            if (entity == null) return false;

            entity.VeterinarioId = dto.VeterinarioId;
            entity.DiaSemana = dto.DiaSemana;
            entity.HoraInicio = dto.HoraInicio;
            entity.HoraFin = dto.HoraFin;
            entity.CreatedAt = dto.CreatedAt;
            entity.UpdatedAt = dto.UpdatedAt;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(Guid id)
        {
            var entity = await _context.HorariosAtencions.FindAsync(id);
            if (entity == null) return false;

            _context.HorariosAtencions.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}