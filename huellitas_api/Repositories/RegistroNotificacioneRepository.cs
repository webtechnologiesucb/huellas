using AutoMapper;
using huellitas_api.Dtos;
using huellitas_api.Models;
using huellitas_api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace huellitas_api.Repositories
{
    public class RegistroNotificacioneRepository : IRegistroNotificacioneRepository
    {
        private readonly HuellitasDigitalesContext _context;
        private readonly IMapper _mapper;

        public RegistroNotificacioneRepository(HuellitasDigitalesContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<RegistroNotificacioneDto>> GetAll()
        {
            var entities = await _context.RegistroNotificaciones
                .Include(x => x.Usuario)
                .Include(x => x.Usuario).ThenInclude(x => x.Rol)
                .AsSplitQuery()
                .AsNoTracking()
                .ToListAsync();
            return _mapper.Map<List<RegistroNotificacioneDto>>(entities);
        }

        public async Task<RegistroNotificacioneDto?> GetById(Guid id)
        {
            var entity = await _context.RegistroNotificaciones
                .Include(x => x.Usuario)
                .Include(x => x.Usuario).ThenInclude(x => x.Rol)
                .AsSplitQuery()
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
            return entity is null ? null : _mapper.Map<RegistroNotificacioneDto>(entity);
        }

        public async Task<bool> Create(RegistroNotificacioneDto dto)
        {
            var entity = new RegistroNotificacione
            {
                Id = dto.Id,
                UsuarioId = dto.UsuarioId,
                Canal = dto.Canal,
                Mensaje = dto.Mensaje,
                Estado = dto.Estado,
                CreatedAt = dto.CreatedAt
            };
            _context.RegistroNotificaciones.Add(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Update(Guid id, RegistroNotificacioneDto dto)
        {
            var entity = await _context.RegistroNotificaciones.FindAsync(id);
            if (entity == null) return false;

            entity.UsuarioId = dto.UsuarioId;
            entity.Canal = dto.Canal;
            entity.Mensaje = dto.Mensaje;
            entity.Estado = dto.Estado;
            entity.CreatedAt = dto.CreatedAt;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(Guid id)
        {
            var entity = await _context.RegistroNotificaciones.FindAsync(id);
            if (entity == null) return false;

            _context.RegistroNotificaciones.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}