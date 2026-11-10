using AutoMapper;
using huellitas_api.Dtos;
using huellitas_api.Models;
using huellitas_api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace huellitas_api.Repositories
{
    public class VacunasAplicadaRepository : IVacunasAplicadaRepository
    {
        private readonly HuellitasDigitalesContext _context;
        private readonly IMapper _mapper;

        public VacunasAplicadaRepository(HuellitasDigitalesContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<VacunasAplicadaDto>> GetAll()
        {
            var entities = await _context.VacunasAplicadas
                .Include(x => x.CatalogoVacuna)
                .Include(x => x.Historial)
                .Include(x => x.Hospitalizacion)
                .Include(x => x.Lote)
                .Include(x => x.CatalogoVacuna).ThenInclude(x => x.Especie)
                .Include(x => x.CatalogoVacuna).ThenInclude(x => x.Producto)
                .Include(x => x.Historial).ThenInclude(x => x!.Cita)
                .Include(x => x.Historial).ThenInclude(x => x!.Expediente)
                .Include(x => x.Historial).ThenInclude(x => x!.Veterinario)
                .Include(x => x.Hospitalizacion).ThenInclude(x => x!.Historial)
                .Include(x => x.Hospitalizacion).ThenInclude(x => x!.Mascota)
                .Include(x => x.Hospitalizacion).ThenInclude(x => x!.Veterinario)
                .Include(x => x.Lote).ThenInclude(x => x.Producto)
                .AsSplitQuery()
                .AsNoTracking()
                .ToListAsync();
            return _mapper.Map<List<VacunasAplicadaDto>>(entities);
        }

        public async Task<VacunasAplicadaDto?> GetById(Guid id)
        {
            var entity = await _context.VacunasAplicadas
                .Include(x => x.CatalogoVacuna)
                .Include(x => x.Historial)
                .Include(x => x.Hospitalizacion)
                .Include(x => x.Lote)
                .Include(x => x.CatalogoVacuna).ThenInclude(x => x.Especie)
                .Include(x => x.CatalogoVacuna).ThenInclude(x => x.Producto)
                .Include(x => x.Historial).ThenInclude(x => x!.Cita)
                .Include(x => x.Historial).ThenInclude(x => x!.Expediente)
                .Include(x => x.Historial).ThenInclude(x => x!.Veterinario)
                .Include(x => x.Hospitalizacion).ThenInclude(x => x!.Historial)
                .Include(x => x.Hospitalizacion).ThenInclude(x => x!.Mascota)
                .Include(x => x.Hospitalizacion).ThenInclude(x => x!.Veterinario)
                .Include(x => x.Lote).ThenInclude(x => x.Producto)
                .AsSplitQuery()
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
            return entity is null ? null : _mapper.Map<VacunasAplicadaDto>(entity);
        }

        public async Task<bool> Create(VacunasAplicadaDto dto)
        {
            var entity = new VacunasAplicada
            {
                Id = dto.Id,
                HistorialId = dto.HistorialId,
                HospitalizacionId = dto.HospitalizacionId,
                CatalogoVacunaId = dto.CatalogoVacunaId,
                LoteId = dto.LoteId,
                FechaAplicacion = dto.FechaAplicacion,
                FechaProximaDosis = dto.FechaProximaDosis
            };
            _context.VacunasAplicadas.Add(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Update(Guid id, VacunasAplicadaDto dto)
        {
            var entity = await _context.VacunasAplicadas.FindAsync(id);
            if (entity == null) return false;

            entity.HistorialId = dto.HistorialId;
            entity.HospitalizacionId = dto.HospitalizacionId;
            entity.CatalogoVacunaId = dto.CatalogoVacunaId;
            entity.LoteId = dto.LoteId;
            entity.FechaAplicacion = dto.FechaAplicacion;
            entity.FechaProximaDosis = dto.FechaProximaDosis;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(Guid id)
        {
            var entity = await _context.VacunasAplicadas.FindAsync(id);
            if (entity == null) return false;

            _context.VacunasAplicadas.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}