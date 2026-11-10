using AutoMapper;
using huellitas_api.Dtos;
using huellitas_api.Models;
using huellitas_api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace huellitas_api.Repositories
{
    public class CatalogoVacunaRepository : ICatalogoVacunaRepository
    {
        private readonly HuellitasDigitalesContext _context;
        private readonly IMapper _mapper;

        public CatalogoVacunaRepository(HuellitasDigitalesContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<CatalogoVacunaDto>> GetAll()
        {
            var entities = await _context.CatalogoVacunas
                .Include(x => x.Especie)
                .Include(x => x.Producto)
                .Include(x => x.VacunasAplicada)
                .Include(x => x.Producto).ThenInclude(x => x!.Categoria)
                .Include(x => x.VacunasAplicada).ThenInclude(x => x.Historial)
                .Include(x => x.VacunasAplicada).ThenInclude(x => x.Hospitalizacion)
                .Include(x => x.VacunasAplicada).ThenInclude(x => x.Lote)
                .AsSplitQuery()
                .AsNoTracking()
                .ToListAsync();
            return _mapper.Map<List<CatalogoVacunaDto>>(entities);
        }

        public async Task<CatalogoVacunaDto?> GetById(int id)
        {
            var entity = await _context.CatalogoVacunas
                .Include(x => x.Especie)
                .Include(x => x.Producto)
                .Include(x => x.VacunasAplicada)
                .Include(x => x.Producto).ThenInclude(x => x!.Categoria)
                .Include(x => x.VacunasAplicada).ThenInclude(x => x.Historial)
                .Include(x => x.VacunasAplicada).ThenInclude(x => x.Hospitalizacion)
                .Include(x => x.VacunasAplicada).ThenInclude(x => x.Lote)
                .AsSplitQuery()
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
            return entity is null ? null : _mapper.Map<CatalogoVacunaDto>(entity);
        }

        public async Task<bool> Create(CatalogoVacunaDto dto)
        {
            var entity = new CatalogoVacuna
            {
                Id = dto.Id,
                EspecieId = dto.EspecieId,
                ProductoId = dto.ProductoId,
                Nombre = dto.Nombre,
                DiasParaRefuerzo = dto.DiasParaRefuerzo,
                CreatedAt = dto.CreatedAt,
                UpdatedAt = dto.UpdatedAt,
                DeletedAt = dto.DeletedAt
            };
            _context.CatalogoVacunas.Add(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Update(int id, CatalogoVacunaDto dto)
        {
            var entity = await _context.CatalogoVacunas.FindAsync(id);
            if (entity == null) return false;

            entity.EspecieId = dto.EspecieId;
            entity.ProductoId = dto.ProductoId;
            entity.Nombre = dto.Nombre;
            entity.DiasParaRefuerzo = dto.DiasParaRefuerzo;
            entity.CreatedAt = dto.CreatedAt;
            entity.UpdatedAt = dto.UpdatedAt;
            entity.DeletedAt = dto.DeletedAt;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            var entity = await _context.CatalogoVacunas.FindAsync(id);
            if (entity == null) return false;

            _context.CatalogoVacunas.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}