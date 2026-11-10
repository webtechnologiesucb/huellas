using AutoMapper;
using huellitas_api.Dtos;
using huellitas_api.Models;
using huellitas_api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace huellitas_api.Repositories
{
    public class MonitoreoDiarioRepository : IMonitoreoDiarioRepository
    {
        private readonly HuellitasDigitalesContext _context;
        private readonly IMapper _mapper;

        public MonitoreoDiarioRepository(HuellitasDigitalesContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<MonitoreoDiarioDto>> GetAll()
        {
            var entities = await _context.MonitoreoDiarios
                .Include(x => x.Hospitalizacion)
                .Include(x => x.Responsable)
                .Include(x => x.Hospitalizacion).ThenInclude(x => x.Historial)
                .Include(x => x.Hospitalizacion).ThenInclude(x => x.Mascota)
                .Include(x => x.Hospitalizacion).ThenInclude(x => x.Veterinario)
                .Include(x => x.Responsable).ThenInclude(x => x.Rol)
                .AsSplitQuery()
                .AsNoTracking()
                .ToListAsync();
            return _mapper.Map<List<MonitoreoDiarioDto>>(entities);
        }

        public async Task<MonitoreoDiarioDto?> GetById(Guid id)
        {
            var entity = await _context.MonitoreoDiarios
                .Include(x => x.Hospitalizacion)
                .Include(x => x.Responsable)
                .Include(x => x.Hospitalizacion).ThenInclude(x => x.Historial)
                .Include(x => x.Hospitalizacion).ThenInclude(x => x.Mascota)
                .Include(x => x.Hospitalizacion).ThenInclude(x => x.Veterinario)
                .Include(x => x.Responsable).ThenInclude(x => x.Rol)
                .AsSplitQuery()
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
            return entity is null ? null : _mapper.Map<MonitoreoDiarioDto>(entity);
        }

        public async Task<bool> Create(MonitoreoDiarioDto dto)
        {
            var entity = new MonitoreoDiario
            {
                Id = dto.Id,
                HospitalizacionId = dto.HospitalizacionId,
                ResponsableId = dto.ResponsableId,
                Turno = dto.Turno,
                Peso = dto.Peso,
                Temperatura = dto.Temperatura,
                FrecuenciaCardiaca = dto.FrecuenciaCardiaca,
                Observaciones = dto.Observaciones,
                CreatedAt = dto.CreatedAt
            };
            _context.MonitoreoDiarios.Add(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Update(Guid id, MonitoreoDiarioDto dto)
        {
            var entity = await _context.MonitoreoDiarios.FindAsync(id);
            if (entity == null) return false;

            entity.HospitalizacionId = dto.HospitalizacionId;
            entity.ResponsableId = dto.ResponsableId;
            entity.Turno = dto.Turno;
            entity.Peso = dto.Peso;
            entity.Temperatura = dto.Temperatura;
            entity.FrecuenciaCardiaca = dto.FrecuenciaCardiaca;
            entity.Observaciones = dto.Observaciones;
            entity.CreatedAt = dto.CreatedAt;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(Guid id)
        {
            var entity = await _context.MonitoreoDiarios.FindAsync(id);
            if (entity == null) return false;

            _context.MonitoreoDiarios.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}