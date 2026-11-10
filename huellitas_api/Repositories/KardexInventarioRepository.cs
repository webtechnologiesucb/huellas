using AutoMapper;
using huellitas_api.Dtos;
using huellitas_api.Models;
using huellitas_api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace huellitas_api.Repositories
{
    public class KardexInventarioRepository : IKardexInventarioRepository
    {
        private readonly HuellitasDigitalesContext _context;
        private readonly IMapper _mapper;

        public KardexInventarioRepository(HuellitasDigitalesContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<KardexInventarioDto>> GetAll()
        {
            var entities = await _context.KardexInventarios
                .Include(x => x.Producto)
                .Include(x => x.Producto).ThenInclude(x => x.Categoria)
                .AsSplitQuery()
                .AsNoTracking()
                .ToListAsync();
            return _mapper.Map<List<KardexInventarioDto>>(entities);
        }

        public async Task<KardexInventarioDto?> GetById(Guid id)
        {
            var entity = await _context.KardexInventarios
                .Include(x => x.Producto)
                .Include(x => x.Producto).ThenInclude(x => x.Categoria)
                .AsSplitQuery()
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
            return entity is null ? null : _mapper.Map<KardexInventarioDto>(entity);
        }

        public async Task<bool> Create(KardexInventarioDto dto)
        {
            var entity = new KardexInventario
            {
                Id = dto.Id,
                ProductoId = dto.ProductoId,
                TipoMovimiento = dto.TipoMovimiento,
                Cantidad = dto.Cantidad,
                SaldoResultante = dto.SaldoResultante,
                Motivo = dto.Motivo,
                CreatedAt = dto.CreatedAt
            };
            _context.KardexInventarios.Add(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Update(Guid id, KardexInventarioDto dto)
        {
            var entity = await _context.KardexInventarios.FindAsync(id);
            if (entity == null) return false;

            entity.ProductoId = dto.ProductoId;
            entity.TipoMovimiento = dto.TipoMovimiento;
            entity.Cantidad = dto.Cantidad;
            entity.SaldoResultante = dto.SaldoResultante;
            entity.Motivo = dto.Motivo;
            entity.CreatedAt = dto.CreatedAt;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(Guid id)
        {
            var entity = await _context.KardexInventarios.FindAsync(id);
            if (entity == null) return false;

            _context.KardexInventarios.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}