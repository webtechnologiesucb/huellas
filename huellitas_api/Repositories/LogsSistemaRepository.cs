using AutoMapper;
using huellitas_api.Dtos;
using huellitas_api.Models;
using huellitas_api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace huellitas_api.Repositories
{
    public class LogsSistemaRepository : ILogsSistemaRepository
    {
        private readonly HuellitasDigitalesContext _context;
        private readonly IMapper _mapper;

        public LogsSistemaRepository(HuellitasDigitalesContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<LogsSistemaDto>> GetAll()
        {
            var entities = await _context.LogsSistemas
                .Include(x => x.Usuario)
                .Include(x => x.Usuario).ThenInclude(x => x!.Rol)
                .AsSplitQuery()
                .AsNoTracking()
                .ToListAsync();
            return _mapper.Map<List<LogsSistemaDto>>(entities);
        }

        public async Task<LogsSistemaDto?> GetById(Guid id)
        {
            var entity = await _context.LogsSistemas
                .Include(x => x.Usuario)
                .Include(x => x.Usuario).ThenInclude(x => x!.Rol)
                .AsSplitQuery()
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
            return entity is null ? null : _mapper.Map<LogsSistemaDto>(entity);
        }

        public async Task<bool> Create(LogsSistemaDto dto)
        {
            var entity = new LogsSistema
            {
                Id = dto.Id,
                UsuarioId = dto.UsuarioId,
                Categoria = dto.Categoria,
                Accion = dto.Accion,
                Detalles = dto.Detalles,
                CreatedAt = dto.CreatedAt
            };
            _context.LogsSistemas.Add(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Update(Guid id, LogsSistemaDto dto)
        {
            var entity = await _context.LogsSistemas.FindAsync(id);
            if (entity == null) return false;

            entity.UsuarioId = dto.UsuarioId;
            entity.Categoria = dto.Categoria;
            entity.Accion = dto.Accion;
            entity.Detalles = dto.Detalles;
            entity.CreatedAt = dto.CreatedAt;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(Guid id)
        {
            var entity = await _context.LogsSistemas.FindAsync(id);
            if (entity == null) return false;

            _context.LogsSistemas.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}