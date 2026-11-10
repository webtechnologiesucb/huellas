using AutoMapper;
using huellitas_api.Dtos;
using huellitas_api.Models;
using huellitas_api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace huellitas_api.Repositories
{
    public class CitaRepository : ICitaRepository
    {
        private readonly HuellitasDigitalesContext _context;
        private readonly IMapper _mapper;

        public CitaRepository(HuellitasDigitalesContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<CitaDto>> GetAll()
        {
            var entities = await _context.Citas
                .Include(x => x.HistorialClinicos)
                .Include(x => x.Mascota)
                .Include(x => x.Veterinario)
                .Include(x => x.HistorialClinicos).ThenInclude(x => x.Expediente)
                .Include(x => x.HistorialClinicos).ThenInclude(x => x.Veterinario)
                .Include(x => x.Mascota).ThenInclude(x => x.Dueño)
                .Include(x => x.Mascota).ThenInclude(x => x.ExpedienteClinico)
                .Include(x => x.Mascota).ThenInclude(x => x.Raza)
                .Include(x => x.Veterinario).ThenInclude(x => x.Rol)
                .AsSplitQuery()
                .AsNoTracking()
                .ToListAsync();
            return _mapper.Map<List<CitaDto>>(entities);
        }

        public async Task<CitaDto?> GetById(Guid id)
        {
            var entity = await _context.Citas
                .Include(x => x.HistorialClinicos)
                .Include(x => x.Mascota)
                .Include(x => x.Veterinario)
                .Include(x => x.HistorialClinicos).ThenInclude(x => x.Expediente)
                .Include(x => x.HistorialClinicos).ThenInclude(x => x.Veterinario)
                .Include(x => x.Mascota).ThenInclude(x => x.Dueño)
                .Include(x => x.Mascota).ThenInclude(x => x.ExpedienteClinico)
                .Include(x => x.Mascota).ThenInclude(x => x.Raza)
                .Include(x => x.Veterinario).ThenInclude(x => x.Rol)
                .AsSplitQuery()
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
            return entity is null ? null : _mapper.Map<CitaDto>(entity);
        }

        public async Task<bool> Create(CitaDto dto)
        {
            var entity = new Cita
            {
                Id = dto.Id,
                MascotaId = dto.MascotaId,
                VeterinarioId = dto.VeterinarioId,
                FechaHora = dto.FechaHora,
                Origen = dto.Origen,
                Prioridad = dto.Prioridad,
                Estado = dto.Estado,
                MotivoCancelacion = dto.MotivoCancelacion,
                CreatedAt = dto.CreatedAt,
                UpdatedAt = dto.UpdatedAt,
                DeletedAt = dto.DeletedAt
            };
            _context.Citas.Add(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Update(Guid id, CitaDto dto)
        {
            var entity = await _context.Citas.FindAsync(id);
            if (entity == null) return false;

            entity.MascotaId = dto.MascotaId;
            entity.VeterinarioId = dto.VeterinarioId;
            entity.FechaHora = dto.FechaHora;
            entity.Origen = dto.Origen;
            entity.Prioridad = dto.Prioridad;
            entity.Estado = dto.Estado;
            entity.MotivoCancelacion = dto.MotivoCancelacion;
            entity.CreatedAt = dto.CreatedAt;
            entity.UpdatedAt = dto.UpdatedAt;
            entity.DeletedAt = dto.DeletedAt;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(Guid id)
        {
            var entity = await _context.Citas.FindAsync(id);
            if (entity == null) return false;

            _context.Citas.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}