using AutoMapper;
using huellitas_api.Dtos;
using huellitas_api.Models;
using huellitas_api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace huellitas_api.Repositories
{
    public class TransaccionesCajaRepository : ITransaccionesCajaRepository
    {
        private readonly HuellitasDigitalesContext _context;
        private readonly IMapper _mapper;

        public TransaccionesCajaRepository(HuellitasDigitalesContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<TransaccionesCajaDto>> GetAll()
        {
            var entities = await _context.TransaccionesCajas
                .Include(x => x.Cajero)
                .Include(x => x.DetallesTransaccions)
                .Include(x => x.Historial)
                .Include(x => x.Hospitalizacion)
                .Include(x => x.Cajero).ThenInclude(x => x.Rol)
                .Include(x => x.DetallesTransaccions).ThenInclude(x => x.Producto)
                .Include(x => x.DetallesTransaccions).ThenInclude(x => x.Servicio)
                .Include(x => x.Historial).ThenInclude(x => x!.Cita)
                .Include(x => x.Historial).ThenInclude(x => x!.Expediente)
                .Include(x => x.Historial).ThenInclude(x => x!.Veterinario)
                .Include(x => x.Hospitalizacion).ThenInclude(x => x!.Historial)
                .Include(x => x.Hospitalizacion).ThenInclude(x => x!.Mascota)
                .Include(x => x.Hospitalizacion).ThenInclude(x => x!.Veterinario)
                .AsSplitQuery()
                .AsNoTracking()
                .ToListAsync();
            return _mapper.Map<List<TransaccionesCajaDto>>(entities);
        }

        public async Task<TransaccionesCajaDto?> GetById(Guid id)
        {
            var entity = await _context.TransaccionesCajas
                .Include(x => x.Cajero)
                .Include(x => x.DetallesTransaccions)
                .Include(x => x.Historial)
                .Include(x => x.Hospitalizacion)
                .Include(x => x.Cajero).ThenInclude(x => x.Rol)
                .Include(x => x.DetallesTransaccions).ThenInclude(x => x.Producto)
                .Include(x => x.DetallesTransaccions).ThenInclude(x => x.Servicio)
                .Include(x => x.Historial).ThenInclude(x => x!.Cita)
                .Include(x => x.Historial).ThenInclude(x => x!.Expediente)
                .Include(x => x.Historial).ThenInclude(x => x!.Veterinario)
                .Include(x => x.Hospitalizacion).ThenInclude(x => x!.Historial)
                .Include(x => x.Hospitalizacion).ThenInclude(x => x!.Mascota)
                .Include(x => x.Hospitalizacion).ThenInclude(x => x!.Veterinario)
                .AsSplitQuery()
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
            return entity is null ? null : _mapper.Map<TransaccionesCajaDto>(entity);
        }

        public async Task<bool> Create(TransaccionesCajaDto dto)
        {
            var entity = new TransaccionesCaja
            {
                Id = dto.Id,
                CajeroId = dto.CajeroId,
                HistorialId = dto.HistorialId,
                HospitalizacionId = dto.HospitalizacionId,
                Subtotal = dto.Subtotal,
                Descuento = dto.Descuento,
                Total = dto.Total,
                MetodoPago = dto.MetodoPago,
                Estado = dto.Estado,
                CreatedAt = dto.CreatedAt,
                UpdatedAt = dto.UpdatedAt
            };
            _context.TransaccionesCajas.Add(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Update(Guid id, TransaccionesCajaDto dto)
        {
            var entity = await _context.TransaccionesCajas.FindAsync(id);
            if (entity == null) return false;

            entity.CajeroId = dto.CajeroId;
            entity.HistorialId = dto.HistorialId;
            entity.HospitalizacionId = dto.HospitalizacionId;
            entity.Subtotal = dto.Subtotal;
            entity.Descuento = dto.Descuento;
            entity.Total = dto.Total;
            entity.MetodoPago = dto.MetodoPago;
            entity.Estado = dto.Estado;
            entity.CreatedAt = dto.CreatedAt;
            entity.UpdatedAt = dto.UpdatedAt;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(Guid id)
        {
            var entity = await _context.TransaccionesCajas.FindAsync(id);
            if (entity == null) return false;

            _context.TransaccionesCajas.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}