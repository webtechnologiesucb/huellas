using AutoMapper;
using huellitas_api.Dtos;
using huellitas_api.Models;
using huellitas_api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace huellitas_api.Repositories
{
    public class InteraccionesBotRepository : IInteraccionesBotRepository
    {
        private readonly HuellitasDigitalesContext _context;
        private readonly IMapper _mapper;

        public InteraccionesBotRepository(HuellitasDigitalesContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<InteraccionesBotDto>> GetAll()
        {
            var entities = await _context.InteraccionesBots
                .Include(x => x.Mascota)
                .Include(x => x.Mascota).ThenInclude(x => x!.Dueño)
                .Include(x => x.Mascota).ThenInclude(x => x!.ExpedienteClinico)
                .Include(x => x.Mascota).ThenInclude(x => x!.Raza)
                .AsSplitQuery()
                .AsNoTracking()
                .ToListAsync();
            return _mapper.Map<List<InteraccionesBotDto>>(entities);
        }

        public async Task<InteraccionesBotDto?> GetById(Guid id)
        {
            var entity = await _context.InteraccionesBots
                .Include(x => x.Mascota)
                .Include(x => x.Mascota).ThenInclude(x => x!.Dueño)
                .Include(x => x.Mascota).ThenInclude(x => x!.ExpedienteClinico)
                .Include(x => x.Mascota).ThenInclude(x => x!.Raza)
                .AsSplitQuery()
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
            return entity is null ? null : _mapper.Map<InteraccionesBotDto>(entity);
        }

        public async Task<bool> Create(InteraccionesBotDto dto)
        {
            var entity = new InteraccionesBot
            {
                Id = dto.Id,
                MascotaId = dto.MascotaId,
                MensajeUsuario = dto.MensajeUsuario,
                IntencionDetectada = dto.IntencionDetectada,
                RespuestaIa = dto.RespuestaIa,
                CreatedAt = dto.CreatedAt
            };
            _context.InteraccionesBots.Add(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Update(Guid id, InteraccionesBotDto dto)
        {
            var entity = await _context.InteraccionesBots.FindAsync(id);
            if (entity == null) return false;

            entity.MascotaId = dto.MascotaId;
            entity.MensajeUsuario = dto.MensajeUsuario;
            entity.IntencionDetectada = dto.IntencionDetectada;
            entity.RespuestaIa = dto.RespuestaIa;
            entity.CreatedAt = dto.CreatedAt;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(Guid id)
        {
            var entity = await _context.InteraccionesBots.FindAsync(id);
            if (entity == null) return false;

            _context.InteraccionesBots.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}