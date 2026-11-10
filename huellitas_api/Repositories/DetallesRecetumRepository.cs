using AutoMapper;
using huellitas_api.Dtos;
using huellitas_api.Models;
using huellitas_api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace huellitas_api.Repositories
{
    public class DetallesRecetumRepository : IDetallesRecetumRepository
    {
        private readonly HuellitasDigitalesContext _context;
        private readonly IMapper _mapper;

        public DetallesRecetumRepository(HuellitasDigitalesContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<DetallesRecetumDto>> GetAll()
        {
            var entities = await _context.DetallesReceta
                .Include(x => x.Producto)
                .Include(x => x.Receta)
                .Include(x => x.Producto).ThenInclude(x => x!.Categoria)
                .Include(x => x.Receta).ThenInclude(x => x.Historial)
                .Include(x => x.Receta).ThenInclude(x => x.Veterinario)
                .AsSplitQuery()
                .AsNoTracking()
                .ToListAsync();
            return _mapper.Map<List<DetallesRecetumDto>>(entities);
        }

        public async Task<DetallesRecetumDto?> GetById(Guid id)
        {
            var entity = await _context.DetallesReceta
                .Include(x => x.Producto)
                .Include(x => x.Receta)
                .Include(x => x.Producto).ThenInclude(x => x!.Categoria)
                .Include(x => x.Receta).ThenInclude(x => x.Historial)
                .Include(x => x.Receta).ThenInclude(x => x.Veterinario)
                .AsSplitQuery()
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
            return entity is null ? null : _mapper.Map<DetallesRecetumDto>(entity);
        }

        public async Task<bool> Create(DetallesRecetumDto dto)
        {
            var entity = new DetallesRecetum
            {
                Id = dto.Id,
                RecetaId = dto.RecetaId,
                ProductoId = dto.ProductoId,
                MedicamentoTextoLibre = dto.MedicamentoTextoLibre,
                Dosis = dto.Dosis,
                Frecuencia = dto.Frecuencia,
                Duracion = dto.Duracion
            };
            _context.DetallesReceta.Add(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Update(Guid id, DetallesRecetumDto dto)
        {
            var entity = await _context.DetallesReceta.FindAsync(id);
            if (entity == null) return false;

            entity.RecetaId = dto.RecetaId;
            entity.ProductoId = dto.ProductoId;
            entity.MedicamentoTextoLibre = dto.MedicamentoTextoLibre;
            entity.Dosis = dto.Dosis;
            entity.Frecuencia = dto.Frecuencia;
            entity.Duracion = dto.Duracion;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(Guid id)
        {
            var entity = await _context.DetallesReceta.FindAsync(id);
            if (entity == null) return false;

            _context.DetallesReceta.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}