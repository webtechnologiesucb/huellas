using AutoMapper;
using huellitas_api.Dtos;
using huellitas_api.Models;
using huellitas_api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace huellitas_api.Repositories
{
    public class HistorialClinicoRepository : IHistorialClinicoRepository
    {
        private readonly HuellitasDigitalesContext _context;
        private readonly IMapper _mapper;

        public HistorialClinicoRepository(HuellitasDigitalesContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<HistorialClinicoDto>> GetAll()
        {
            var entities = await _context.HistorialClinicos
                .Include(x => x.ArchivosAdjuntos)
                .Include(x => x.Cita)
                .Include(x => x.Expediente)
                .Include(x => x.Hospitalizaciones)
                .Include(x => x.Receta)
                .Include(x => x.TransaccionesCajas)
                .Include(x => x.VacunasAplicada)
                .Include(x => x.Veterinario)
                .Include(x => x.ArchivosAdjuntos).ThenInclude(x => x.Hospitalizacion)
                .Include(x => x.Cita).ThenInclude(x => x!.Mascota)
                .Include(x => x.Cita).ThenInclude(x => x!.Veterinario)
                .Include(x => x.Expediente).ThenInclude(x => x.Mascota)
                .Include(x => x.Hospitalizaciones).ThenInclude(x => x.Mascota)
                .Include(x => x.Hospitalizaciones).ThenInclude(x => x.Veterinario)
                .Include(x => x.Receta).ThenInclude(x => x.Veterinario)
                .Include(x => x.TransaccionesCajas).ThenInclude(x => x.Cajero)
                .Include(x => x.TransaccionesCajas).ThenInclude(x => x.Hospitalizacion)
                .Include(x => x.VacunasAplicada).ThenInclude(x => x.CatalogoVacuna)
                .Include(x => x.VacunasAplicada).ThenInclude(x => x.Hospitalizacion)
                .Include(x => x.VacunasAplicada).ThenInclude(x => x.Lote)
                .Include(x => x.Veterinario).ThenInclude(x => x.Rol)
                .AsSplitQuery()
                .AsNoTracking()
                .ToListAsync();
            return _mapper.Map<List<HistorialClinicoDto>>(entities);
        }

        public async Task<HistorialClinicoDto?> GetById(Guid id)
        {
            var entity = await _context.HistorialClinicos
                .Include(x => x.ArchivosAdjuntos)
                .Include(x => x.Cita)
                .Include(x => x.Expediente)
                .Include(x => x.Hospitalizaciones)
                .Include(x => x.Receta)
                .Include(x => x.TransaccionesCajas)
                .Include(x => x.VacunasAplicada)
                .Include(x => x.Veterinario)
                .Include(x => x.ArchivosAdjuntos).ThenInclude(x => x.Hospitalizacion)
                .Include(x => x.Cita).ThenInclude(x => x!.Mascota)
                .Include(x => x.Cita).ThenInclude(x => x!.Veterinario)
                .Include(x => x.Expediente).ThenInclude(x => x.Mascota)
                .Include(x => x.Hospitalizaciones).ThenInclude(x => x.Mascota)
                .Include(x => x.Hospitalizaciones).ThenInclude(x => x.Veterinario)
                .Include(x => x.Receta).ThenInclude(x => x.Veterinario)
                .Include(x => x.TransaccionesCajas).ThenInclude(x => x.Cajero)
                .Include(x => x.TransaccionesCajas).ThenInclude(x => x.Hospitalizacion)
                .Include(x => x.VacunasAplicada).ThenInclude(x => x.CatalogoVacuna)
                .Include(x => x.VacunasAplicada).ThenInclude(x => x.Hospitalizacion)
                .Include(x => x.VacunasAplicada).ThenInclude(x => x.Lote)
                .Include(x => x.Veterinario).ThenInclude(x => x.Rol)
                .AsSplitQuery()
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
            return entity is null ? null : _mapper.Map<HistorialClinicoDto>(entity);
        }

        public async Task<bool> Create(HistorialClinicoDto dto)
        {
            var entity = new HistorialClinico
            {
                Id = dto.Id,
                ExpedienteId = dto.ExpedienteId,
                CitaId = dto.CitaId,
                VeterinarioId = dto.VeterinarioId,
                Peso = dto.Peso,
                Temperatura = dto.Temperatura,
                FrecuenciaCardiaca = dto.FrecuenciaCardiaca,
                FrecuenciaRespiratoria = dto.FrecuenciaRespiratoria,
                MotivoConsulta = dto.MotivoConsulta,
                Diagnostico = dto.Diagnostico,
                NotasInternas = dto.NotasInternas,
                Estado = dto.Estado,
                CreatedAt = dto.CreatedAt,
                UpdatedAt = dto.UpdatedAt,
                DeletedAt = dto.DeletedAt
            };
            _context.HistorialClinicos.Add(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Update(Guid id, HistorialClinicoDto dto)
        {
            var entity = await _context.HistorialClinicos.FindAsync(id);
            if (entity == null) return false;

            entity.ExpedienteId = dto.ExpedienteId;
            entity.CitaId = dto.CitaId;
            entity.VeterinarioId = dto.VeterinarioId;
            entity.Peso = dto.Peso;
            entity.Temperatura = dto.Temperatura;
            entity.FrecuenciaCardiaca = dto.FrecuenciaCardiaca;
            entity.FrecuenciaRespiratoria = dto.FrecuenciaRespiratoria;
            entity.MotivoConsulta = dto.MotivoConsulta;
            entity.Diagnostico = dto.Diagnostico;
            entity.NotasInternas = dto.NotasInternas;
            entity.Estado = dto.Estado;
            entity.CreatedAt = dto.CreatedAt;
            entity.UpdatedAt = dto.UpdatedAt;
            entity.DeletedAt = dto.DeletedAt;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(Guid id)
        {
            var entity = await _context.HistorialClinicos.FindAsync(id);
            if (entity == null) return false;

            _context.HistorialClinicos.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}