using AutoMapper;
using huellitas_api.Dtos;
using huellitas_api.Models;
using huellitas_api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace huellitas_api.Repositories
{
    public class RegistroEscaneosQrRepository : IRegistroEscaneosQrRepository
    {
        private readonly HuellitasDigitalesContext _context;
        private readonly IMapper _mapper;

        public RegistroEscaneosQrRepository(HuellitasDigitalesContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<RegistroEscaneosQrDto>> GetAll()
        {
            var entities = await _context.RegistroEscaneosQrs
                .Include(x => x.Mascota)
                .Include(x => x.Mascota).ThenInclude(x => x.Dueño)
                .Include(x => x.Mascota).ThenInclude(x => x.ExpedienteClinico)
                .Include(x => x.Mascota).ThenInclude(x => x.Raza)
                .AsSplitQuery()
                .AsNoTracking()
                .ToListAsync();
            return _mapper.Map<List<RegistroEscaneosQrDto>>(entities);
        }

        public async Task<RegistroEscaneosQrDto?> GetById(Guid id)
        {
            var entity = await _context.RegistroEscaneosQrs
                .Include(x => x.Mascota)
                .Include(x => x.Mascota).ThenInclude(x => x.Dueño)
                .Include(x => x.Mascota).ThenInclude(x => x.ExpedienteClinico)
                .Include(x => x.Mascota).ThenInclude(x => x.Raza)
                .AsSplitQuery()
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
            return entity is null ? null : _mapper.Map<RegistroEscaneosQrDto>(entity);
        }

        public async Task<bool> Create(RegistroEscaneosQrDto dto)
        {
            var entity = new RegistroEscaneosQr
            {
                Id = dto.Id,
                MascotaId = dto.MascotaId,
                Latitud = dto.Latitud,
                Longitud = dto.Longitud,
                UserAgent = dto.UserAgent,
                CreatedAt = dto.CreatedAt
            };
            _context.RegistroEscaneosQrs.Add(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Update(Guid id, RegistroEscaneosQrDto dto)
        {
            var entity = await _context.RegistroEscaneosQrs.FindAsync(id);
            if (entity == null) return false;

            entity.MascotaId = dto.MascotaId;
            entity.Latitud = dto.Latitud;
            entity.Longitud = dto.Longitud;
            entity.UserAgent = dto.UserAgent;
            entity.CreatedAt = dto.CreatedAt;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(Guid id)
        {
            var entity = await _context.RegistroEscaneosQrs.FindAsync(id);
            if (entity == null) return false;

            _context.RegistroEscaneosQrs.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}