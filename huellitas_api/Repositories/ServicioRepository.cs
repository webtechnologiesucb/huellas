using AutoMapper;
using huellitas_api.Dtos;
using huellitas_api.Models;
using huellitas_api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace huellitas_api.Repositories
{
    public class ServicioRepository : IServicioRepository
    {
        private readonly HuellitasDigitalesContext _context;
        private readonly IMapper _mapper;

        public ServicioRepository(HuellitasDigitalesContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<ServicioDto>> GetAll()
        {
            var entities = await _context.Servicios
                .Include(x => x.DetallesTransaccions)
                .Include(x => x.HospitalizacionInsumos)
                .Include(x => x.DetallesTransaccions).ThenInclude(x => x.Producto)
                .Include(x => x.DetallesTransaccions).ThenInclude(x => x.Transaccion)
                .Include(x => x.HospitalizacionInsumos).ThenInclude(x => x.Hospitalizacion)
                .Include(x => x.HospitalizacionInsumos).ThenInclude(x => x.Producto)
                .AsSplitQuery()
                .AsNoTracking()
                .ToListAsync();
            return _mapper.Map<List<ServicioDto>>(entities);
        }

        public async Task<ServicioDto?> GetById(int id)
        {
            var entity = await _context.Servicios
                .Include(x => x.DetallesTransaccions)
                .Include(x => x.HospitalizacionInsumos)
                .Include(x => x.DetallesTransaccions).ThenInclude(x => x.Producto)
                .Include(x => x.DetallesTransaccions).ThenInclude(x => x.Transaccion)
                .Include(x => x.HospitalizacionInsumos).ThenInclude(x => x.Hospitalizacion)
                .Include(x => x.HospitalizacionInsumos).ThenInclude(x => x.Producto)
                .AsSplitQuery()
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
            return entity is null ? null : _mapper.Map<ServicioDto>(entity);
        }

        public async Task<bool> Create(ServicioDto dto)
        {
            var entity = new Servicio
            {
                Id = dto.Id,
                Nombre = dto.Nombre,
                Descripcion = dto.Descripcion,
                Precio = dto.Precio,
                DuracionMinutos = dto.DuracionMinutos,
                RequiereVeterinario = dto.RequiereVeterinario,
                CreatedAt = dto.CreatedAt,
                UpdatedAt = dto.UpdatedAt,
                DeletedAt = dto.DeletedAt
            };
            _context.Servicios.Add(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Update(int id, ServicioDto dto)
        {
            var entity = await _context.Servicios.FindAsync(id);
            if (entity == null) return false;

            entity.Nombre = dto.Nombre;
            entity.Descripcion = dto.Descripcion;
            entity.Precio = dto.Precio;
            entity.DuracionMinutos = dto.DuracionMinutos;
            entity.RequiereVeterinario = dto.RequiereVeterinario;
            entity.CreatedAt = dto.CreatedAt;
            entity.UpdatedAt = dto.UpdatedAt;
            entity.DeletedAt = dto.DeletedAt;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            var entity = await _context.Servicios.FindAsync(id);
            if (entity == null) return false;

            _context.Servicios.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}