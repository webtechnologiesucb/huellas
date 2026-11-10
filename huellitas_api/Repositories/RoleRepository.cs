using AutoMapper;
using huellitas_api.Dtos;
using huellitas_api.Models;
using huellitas_api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace huellitas_api.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly HuellitasDigitalesContext _context;
        private readonly IMapper _mapper;

        public RoleRepository(HuellitasDigitalesContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<RoleDto>> GetAll()
        {
            var entities = await _context.Roles
                .Include(x => x.Usuarios)
                .AsSplitQuery()
                .AsNoTracking()
                .ToListAsync();
            return _mapper.Map<List<RoleDto>>(entities);
        }

        public async Task<RoleDto?> GetById(int id)
        {
            var entity = await _context.Roles
                .Include(x => x.Usuarios)
                .AsSplitQuery()
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
            return entity is null ? null : _mapper.Map<RoleDto>(entity);
        }

        public async Task<bool> Create(RoleDto dto)
        {
            var entity = new Role
            {
                Id = dto.Id,
                Nombre = dto.Nombre,
                Descripcion = dto.Descripcion,
                CreatedAt = dto.CreatedAt,
                UpdatedAt = dto.UpdatedAt,
                DeletedAt = dto.DeletedAt
            };
            _context.Roles.Add(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Update(int id, RoleDto dto)
        {
            var entity = await _context.Roles.FindAsync(id);
            if (entity == null) return false;

            entity.Nombre = dto.Nombre;
            entity.Descripcion = dto.Descripcion;
            entity.CreatedAt = dto.CreatedAt;
            entity.UpdatedAt = dto.UpdatedAt;
            entity.DeletedAt = dto.DeletedAt;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            var entity = await _context.Roles.FindAsync(id);
            if (entity == null) return false;

            _context.Roles.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}