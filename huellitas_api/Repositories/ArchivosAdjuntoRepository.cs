using AutoMapper;
using huellitas_api.Dtos;
using huellitas_api.Models;
using huellitas_api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace huellitas_api.Repositories
{
    public class ArchivosAdjuntoRepository : IArchivosAdjuntoRepository
    {
        private readonly HuellitasDigitalesContext _context;
        private readonly IMapper _mapper;

        public ArchivosAdjuntoRepository(HuellitasDigitalesContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<ArchivosAdjuntoDto>> GetAll()
        {
            var entities = await _context.ArchivosAdjuntos
                .Include(x => x.Historial)
                .Include(x => x.Hospitalizacion)
                .Include(x => x.Historial).ThenInclude(x => x!.Cita)
                .Include(x => x.Historial).ThenInclude(x => x!.Expediente)
                .Include(x => x.Historial).ThenInclude(x => x!.Veterinario)
                .Include(x => x.Hospitalizacion).ThenInclude(x => x!.Historial)
                .Include(x => x.Hospitalizacion).ThenInclude(x => x!.Mascota)
                .Include(x => x.Hospitalizacion).ThenInclude(x => x!.Veterinario)
                .AsSplitQuery()
                .AsNoTracking()
                .ToListAsync();
            return _mapper.Map<List<ArchivosAdjuntoDto>>(entities);
        }

        public async Task<ArchivosAdjuntoDto?> GetById(Guid id)
        {
            var entity = await _context.ArchivosAdjuntos
                .Include(x => x.Historial)
                .Include(x => x.Hospitalizacion)
                .Include(x => x.Historial).ThenInclude(x => x!.Cita)
                .Include(x => x.Historial).ThenInclude(x => x!.Expediente)
                .Include(x => x.Historial).ThenInclude(x => x!.Veterinario)
                .Include(x => x.Hospitalizacion).ThenInclude(x => x!.Historial)
                .Include(x => x.Hospitalizacion).ThenInclude(x => x!.Mascota)
                .Include(x => x.Hospitalizacion).ThenInclude(x => x!.Veterinario)
                .AsSplitQuery()
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
            return entity is null ? null : _mapper.Map<ArchivosAdjuntoDto>(entity);
        }

        public async Task<bool> Create(ArchivosAdjuntoDto dto)
        {
            var entity = new ArchivosAdjunto
            {
                Id = dto.Id,
                HistorialId = dto.HistorialId,
                HospitalizacionId = dto.HospitalizacionId,
                UrlArchivo = dto.UrlArchivo,
                TipoArchivo = dto.TipoArchivo,
                NombreArchivo = dto.NombreArchivo,
                CreatedAt = dto.CreatedAt
            };
            _context.ArchivosAdjuntos.Add(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Update(Guid id, ArchivosAdjuntoDto dto)
        {
            var entity = await _context.ArchivosAdjuntos.FindAsync(id);
            if (entity == null) return false;

            entity.HistorialId = dto.HistorialId;
            entity.HospitalizacionId = dto.HospitalizacionId;
            entity.UrlArchivo = dto.UrlArchivo;
            entity.TipoArchivo = dto.TipoArchivo;
            entity.NombreArchivo = dto.NombreArchivo;
            entity.CreatedAt = dto.CreatedAt;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(Guid id)
        {
            var entity = await _context.ArchivosAdjuntos.FindAsync(id);
            if (entity == null) return false;

            _context.ArchivosAdjuntos.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}