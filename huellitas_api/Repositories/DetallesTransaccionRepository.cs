using AutoMapper;
using huellitas_api.Dtos;
using huellitas_api.Models;
using huellitas_api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace huellitas_api.Repositories
{
    public class DetallesTransaccionRepository : IDetallesTransaccionRepository
    {
        private readonly HuellitasDigitalesContext _context;
        private readonly IMapper _mapper;

        public DetallesTransaccionRepository(HuellitasDigitalesContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<DetallesTransaccionDto>> GetAll()
        {
            var entities = await _context.DetallesTransaccions
                .Include(x => x.Producto)
                .Include(x => x.Servicio)
                .Include(x => x.Transaccion)
                .Include(x => x.Producto).ThenInclude(x => x!.Categoria)
                .Include(x => x.Transaccion).ThenInclude(x => x.Cajero)
                .Include(x => x.Transaccion).ThenInclude(x => x.Historial)
                .Include(x => x.Transaccion).ThenInclude(x => x.Hospitalizacion)
                .AsSplitQuery()
                .AsNoTracking()
                .ToListAsync();
            return _mapper.Map<List<DetallesTransaccionDto>>(entities);
        }

        public async Task<DetallesTransaccionDto?> GetById(Guid id)
        {
            var entity = await _context.DetallesTransaccions
                .Include(x => x.Producto)
                .Include(x => x.Servicio)
                .Include(x => x.Transaccion)
                .Include(x => x.Producto).ThenInclude(x => x!.Categoria)
                .Include(x => x.Transaccion).ThenInclude(x => x.Cajero)
                .Include(x => x.Transaccion).ThenInclude(x => x.Historial)
                .Include(x => x.Transaccion).ThenInclude(x => x.Hospitalizacion)
                .AsSplitQuery()
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
            return entity is null ? null : _mapper.Map<DetallesTransaccionDto>(entity);
        }

        public async Task<bool> Create(DetallesTransaccionDto dto)
        {
            var entity = new DetallesTransaccion
            {
                Id = dto.Id,
                TransaccionId = dto.TransaccionId,
                ProductoId = dto.ProductoId,
                ServicioId = dto.ServicioId,
                Cantidad = dto.Cantidad,
                PrecioUnitario = dto.PrecioUnitario,
                Subtotal = dto.Subtotal,
                TipoCobro = dto.TipoCobro
            };
            _context.DetallesTransaccions.Add(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Update(Guid id, DetallesTransaccionDto dto)
        {
            var entity = await _context.DetallesTransaccions.FindAsync(id);
            if (entity == null) return false;

            entity.TransaccionId = dto.TransaccionId;
            entity.ProductoId = dto.ProductoId;
            entity.ServicioId = dto.ServicioId;
            entity.Cantidad = dto.Cantidad;
            entity.PrecioUnitario = dto.PrecioUnitario;
            entity.Subtotal = dto.Subtotal;
            entity.TipoCobro = dto.TipoCobro;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(Guid id)
        {
            var entity = await _context.DetallesTransaccions.FindAsync(id);
            if (entity == null) return false;

            _context.DetallesTransaccions.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}