using AutoMapper;
using huellitas_api.Dtos;
using huellitas_api.Models;
using huellitas_api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace huellitas_api.Repositories
{
    public class ExpedienteClinicoRepository : IExpedienteClinicoRepository
    {
        private readonly HuellitasDigitalesContext _context;
        private readonly IMapper _mapper;

        public ExpedienteClinicoRepository(HuellitasDigitalesContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<ExpedienteClinicoDto>> GetAll()
        {
            var entities = await _context.ExpedienteClinicos
                .Include(x => x.HistorialClinicos)
                .Include(x => x.Mascota)
                .Include(x => x.HistorialClinicos).ThenInclude(x => x.Cita)
                .Include(x => x.HistorialClinicos).ThenInclude(x => x.Veterinario)
                .Include(x => x.Mascota).ThenInclude(x => x.Dueño)
                .Include(x => x.Mascota).ThenInclude(x => x.Raza)
                .AsSplitQuery()
                .AsNoTracking()
                .ToListAsync();
            return _mapper.Map<List<ExpedienteClinicoDto>>(entities);
        }

        public async Task<ExpedienteClinicoDto?> GetById(Guid id)
        {
            var entity = await _context.ExpedienteClinicos
                .Include(x => x.HistorialClinicos)
                .Include(x => x.Mascota)
                .Include(x => x.HistorialClinicos).ThenInclude(x => x.Cita)
                .Include(x => x.HistorialClinicos).ThenInclude(x => x.Veterinario)
                .Include(x => x.Mascota).ThenInclude(x => x.Dueño)
                .Include(x => x.Mascota).ThenInclude(x => x.Raza)
                .AsSplitQuery()
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
            return entity is null ? null : _mapper.Map<ExpedienteClinicoDto>(entity);
        }

        public async Task<bool> Create(ExpedienteClinicoDto dto)
        {
            var entity = new ExpedienteClinico
            {
                Id = dto.Id,
                MascotaId = dto.MascotaId,
                CreatedAt = dto.CreatedAt,
                UpdatedAt = dto.UpdatedAt,
                DeletedAt = dto.DeletedAt
            };
            _context.ExpedienteClinicos.Add(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Update(Guid id, ExpedienteClinicoDto dto)
        {
            var entity = await _context.ExpedienteClinicos.FindAsync(id);
            if (entity == null) return false;

            entity.MascotaId = dto.MascotaId;
            entity.CreatedAt = dto.CreatedAt;
            entity.UpdatedAt = dto.UpdatedAt;
            entity.DeletedAt = dto.DeletedAt;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(Guid id)
        {
            var entity = await _context.ExpedienteClinicos.FindAsync(id);
            if (entity == null) return false;

            _context.ExpedienteClinicos.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}