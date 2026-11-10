using AutoMapper;
using huellitas_api.Dtos;
using huellitas_api.Models;
using huellitas_api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace huellitas_api.Repositories
{
    public class HospitalizacionInsumoRepository : IHospitalizacionInsumoRepository
    {
        private readonly HuellitasDigitalesContext _context;
        private readonly IMapper _mapper;

        public HospitalizacionInsumoRepository(HuellitasDigitalesContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<HospitalizacionInsumoDto>> GetAll()
        {
            var entities = await _context.HospitalizacionInsumos
                .Include(x => x.Hospitalizacion)
                .Include(x => x.Producto)
                .Include(x => x.Servicio)
                .Include(x => x.Hospitalizacion).ThenInclude(x => x.Historial)
                .Include(x => x.Hospitalizacion).ThenInclude(x => x.Mascota)
                .Include(x => x.Hospitalizacion).ThenInclude(x => x.Veterinario)
                .Include(x => x.Producto).ThenInclude(x => x!.Categoria)
                .AsSplitQuery()
                .AsNoTracking()
                .ToListAsync();
            return _mapper.Map<List<HospitalizacionInsumoDto>>(entities);
        }

        public async Task<HospitalizacionInsumoDto?> GetById(Guid id)
        {
            var entity = await _context.HospitalizacionInsumos
                .Include(x => x.Hospitalizacion)
                .Include(x => x.Producto)
                .Include(x => x.Servicio)
                .Include(x => x.Hospitalizacion).ThenInclude(x => x.Historial)
                .Include(x => x.Hospitalizacion).ThenInclude(x => x.Mascota)
                .Include(x => x.Hospitalizacion).ThenInclude(x => x.Veterinario)
                .Include(x => x.Producto).ThenInclude(x => x!.Categoria)
                .AsSplitQuery()
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
            return entity is null ? null : _mapper.Map<HospitalizacionInsumoDto>(entity);
        }

        public async Task<bool> Create(HospitalizacionInsumoDto dto)
        {
            var entity = new HospitalizacionInsumo
            {
                Id = dto.Id,
                HospitalizacionId = dto.HospitalizacionId,
                ProductoId = dto.ProductoId,
                ServicioId = dto.ServicioId,
                Cantidad = dto.Cantidad,
                Subtotal = dto.Subtotal,
                CreatedAt = dto.CreatedAt
            };
            _context.HospitalizacionInsumos.Add(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Update(Guid id, HospitalizacionInsumoDto dto)
        {
            var entity = await _context.HospitalizacionInsumos.FindAsync(id);
            if (entity == null) return false;

            entity.HospitalizacionId = dto.HospitalizacionId;
            entity.ProductoId = dto.ProductoId;
            entity.ServicioId = dto.ServicioId;
            entity.Cantidad = dto.Cantidad;
            entity.Subtotal = dto.Subtotal;
            entity.CreatedAt = dto.CreatedAt;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(Guid id)
        {
            var entity = await _context.HospitalizacionInsumos.FindAsync(id);
            if (entity == null) return false;

            _context.HospitalizacionInsumos.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}