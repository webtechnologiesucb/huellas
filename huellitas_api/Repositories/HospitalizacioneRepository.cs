using AutoMapper;
using huellitas_api.Dtos;
using huellitas_api.Models;
using huellitas_api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace huellitas_api.Repositories
{
    public class HospitalizacioneRepository : IHospitalizacioneRepository
    {
        private readonly HuellitasDigitalesContext _context;
        private readonly IMapper _mapper;

        public HospitalizacioneRepository(HuellitasDigitalesContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<HospitalizacioneDto>> GetAll()
        {
            var entities = await _context.Hospitalizaciones
                .Include(x => x.ArchivosAdjuntos)
                .Include(x => x.Historial)
                .Include(x => x.HospitalizacionInsumos)
                .Include(x => x.Mascota)
                .Include(x => x.MonitoreoDiarios)
                .Include(x => x.TransaccionesCajas)
                .Include(x => x.VacunasAplicada)
                .Include(x => x.Veterinario)
                .Include(x => x.ArchivosAdjuntos).ThenInclude(x => x.Historial)
                .Include(x => x.Historial).ThenInclude(x => x.Cita)
                .Include(x => x.Historial).ThenInclude(x => x.Expediente)
                .Include(x => x.Historial).ThenInclude(x => x.Veterinario)
                .Include(x => x.HospitalizacionInsumos).ThenInclude(x => x.Producto)
                .Include(x => x.HospitalizacionInsumos).ThenInclude(x => x.Servicio)
                .Include(x => x.Mascota).ThenInclude(x => x.Dueño)
                .Include(x => x.Mascota).ThenInclude(x => x.ExpedienteClinico)
                .Include(x => x.Mascota).ThenInclude(x => x.Raza)
                .Include(x => x.MonitoreoDiarios).ThenInclude(x => x.Responsable)
                .Include(x => x.TransaccionesCajas).ThenInclude(x => x.Cajero)
                .Include(x => x.TransaccionesCajas).ThenInclude(x => x.Historial)
                .Include(x => x.VacunasAplicada).ThenInclude(x => x.CatalogoVacuna)
                .Include(x => x.VacunasAplicada).ThenInclude(x => x.Historial)
                .Include(x => x.VacunasAplicada).ThenInclude(x => x.Lote)
                .Include(x => x.Veterinario).ThenInclude(x => x.Rol)
                .AsSplitQuery()
                .AsNoTracking()
                .ToListAsync();
            return _mapper.Map<List<HospitalizacioneDto>>(entities);
        }

        public async Task<HospitalizacioneDto?> GetById(Guid id)
        {
            var entity = await _context.Hospitalizaciones
                .Include(x => x.ArchivosAdjuntos)
                .Include(x => x.Historial)
                .Include(x => x.HospitalizacionInsumos)
                .Include(x => x.Mascota)
                .Include(x => x.MonitoreoDiarios)
                .Include(x => x.TransaccionesCajas)
                .Include(x => x.VacunasAplicada)
                .Include(x => x.Veterinario)
                .Include(x => x.ArchivosAdjuntos).ThenInclude(x => x.Historial)
                .Include(x => x.Historial).ThenInclude(x => x.Cita)
                .Include(x => x.Historial).ThenInclude(x => x.Expediente)
                .Include(x => x.Historial).ThenInclude(x => x.Veterinario)
                .Include(x => x.HospitalizacionInsumos).ThenInclude(x => x.Producto)
                .Include(x => x.HospitalizacionInsumos).ThenInclude(x => x.Servicio)
                .Include(x => x.Mascota).ThenInclude(x => x.Dueño)
                .Include(x => x.Mascota).ThenInclude(x => x.ExpedienteClinico)
                .Include(x => x.Mascota).ThenInclude(x => x.Raza)
                .Include(x => x.MonitoreoDiarios).ThenInclude(x => x.Responsable)
                .Include(x => x.TransaccionesCajas).ThenInclude(x => x.Cajero)
                .Include(x => x.TransaccionesCajas).ThenInclude(x => x.Historial)
                .Include(x => x.VacunasAplicada).ThenInclude(x => x.CatalogoVacuna)
                .Include(x => x.VacunasAplicada).ThenInclude(x => x.Historial)
                .Include(x => x.VacunasAplicada).ThenInclude(x => x.Lote)
                .Include(x => x.Veterinario).ThenInclude(x => x.Rol)
                .AsSplitQuery()
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
            return entity is null ? null : _mapper.Map<HospitalizacioneDto>(entity);
        }

        public async Task<bool> Create(HospitalizacioneDto dto)
        {
            var entity = new Hospitalizacione
            {
                Id = dto.Id,
                HistorialId = dto.HistorialId,
                MascotaId = dto.MascotaId,
                VeterinarioId = dto.VeterinarioId,
                FechaIngreso = dto.FechaIngreso,
                FechaEgreso = dto.FechaEgreso,
                Estado = dto.Estado,
                Observaciones = dto.Observaciones,
                CreatedAt = dto.CreatedAt,
                UpdatedAt = dto.UpdatedAt
            };
            _context.Hospitalizaciones.Add(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Update(Guid id, HospitalizacioneDto dto)
        {
            var entity = await _context.Hospitalizaciones.FindAsync(id);
            if (entity == null) return false;

            entity.HistorialId = dto.HistorialId;
            entity.MascotaId = dto.MascotaId;
            entity.VeterinarioId = dto.VeterinarioId;
            entity.FechaIngreso = dto.FechaIngreso;
            entity.FechaEgreso = dto.FechaEgreso;
            entity.Estado = dto.Estado;
            entity.Observaciones = dto.Observaciones;
            entity.CreatedAt = dto.CreatedAt;
            entity.UpdatedAt = dto.UpdatedAt;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(Guid id)
        {
            var entity = await _context.Hospitalizaciones.FindAsync(id);
            if (entity == null) return false;

            _context.Hospitalizaciones.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}