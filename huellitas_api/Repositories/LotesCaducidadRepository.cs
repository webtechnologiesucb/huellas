using AutoMapper;
using huellitas_api.Dtos;
using huellitas_api.Models;
using huellitas_api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace huellitas_api.Repositories
{
    public class LotesCaducidadRepository : ILotesCaducidadRepository
    {
        private readonly HuellitasDigitalesContext _context;
        private readonly IMapper _mapper;

        public LotesCaducidadRepository(HuellitasDigitalesContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<LotesCaducidadDto>> GetAll()
        {
            var entities = await _context.LotesCaducidads
                .Include(x => x.Producto)
                .Include(x => x.VacunasAplicada)
                .Include(x => x.Producto).ThenInclude(x => x.Categoria)
                .Include(x => x.VacunasAplicada).ThenInclude(x => x.CatalogoVacuna)
                .Include(x => x.VacunasAplicada).ThenInclude(x => x.Historial)
                .Include(x => x.VacunasAplicada).ThenInclude(x => x.Hospitalizacion)
                .AsSplitQuery()
                .AsNoTracking()
                .ToListAsync();
            return _mapper.Map<List<LotesCaducidadDto>>(entities);
        }

        public async Task<LotesCaducidadDto?> GetById(Guid id)
        {
            var entity = await _context.LotesCaducidads
                .Include(x => x.Producto)
                .Include(x => x.VacunasAplicada)
                .Include(x => x.Producto).ThenInclude(x => x.Categoria)
                .Include(x => x.VacunasAplicada).ThenInclude(x => x.CatalogoVacuna)
                .Include(x => x.VacunasAplicada).ThenInclude(x => x.Historial)
                .Include(x => x.VacunasAplicada).ThenInclude(x => x.Hospitalizacion)
                .AsSplitQuery()
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
            return entity is null ? null : _mapper.Map<LotesCaducidadDto>(entity);
        }

        public async Task<bool> Create(LotesCaducidadDto dto)
        {
            var entity = new LotesCaducidad
            {
                Id = dto.Id,
                ProductoId = dto.ProductoId,
                NumeroLote = dto.NumeroLote,
                FechaVencimiento = dto.FechaVencimiento,
                CantidadInicial = dto.CantidadInicial,
                CantidadActual = dto.CantidadActual,
                CreatedAt = dto.CreatedAt
            };
            _context.LotesCaducidads.Add(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Update(Guid id, LotesCaducidadDto dto)
        {
            var entity = await _context.LotesCaducidads.FindAsync(id);
            if (entity == null) return false;

            entity.ProductoId = dto.ProductoId;
            entity.NumeroLote = dto.NumeroLote;
            entity.FechaVencimiento = dto.FechaVencimiento;
            entity.CantidadInicial = dto.CantidadInicial;
            entity.CantidadActual = dto.CantidadActual;
            entity.CreatedAt = dto.CreatedAt;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(Guid id)
        {
            var entity = await _context.LotesCaducidads.FindAsync(id);
            if (entity == null) return false;

            _context.LotesCaducidads.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}