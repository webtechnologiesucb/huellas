using AutoMapper;
using huellitas_api.Dtos;
using huellitas_api.Models;
using huellitas_api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace huellitas_api.Repositories
{
    public class MascotasRepository : IMascotasRepository
    {
        private readonly HuellitasDigitalesContext _context;
        private readonly IMapper _mapper;

        public MascotasRepository(HuellitasDigitalesContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<MascotaDto>> GetAll()
        {
            var entities = await _context.Mascotas
                .Include(x => x.Cita)
                .Include(x => x.Dueño)
                .Include(x => x.ExpedienteClinico)
                .Include(x => x.Hospitalizaciones)
                .Include(x => x.InteraccionesBots)
                .Include(x => x.Raza)
                .Include(x => x.RegistroEscaneosQrs)
                .Include(x => x.Cita).ThenInclude(x => x.Veterinario)
                .Include(x => x.Dueño).ThenInclude(x => x.Rol)
                .Include(x => x.Hospitalizaciones).ThenInclude(x => x.Historial)
                .Include(x => x.Hospitalizaciones).ThenInclude(x => x.Veterinario)
                .Include(x => x.Raza).ThenInclude(x => x.Especie)
                .AsSplitQuery()
                .AsNoTracking()
                .ToListAsync();
            return _mapper.Map<List<MascotaDto>>(entities);
        }

        public async Task<MascotaDto?> GetById(Guid id)
        {
            var entity = await _context.Mascotas
                .Include(x => x.Cita)
                .Include(x => x.Dueño)
                .Include(x => x.ExpedienteClinico)
                .Include(x => x.Hospitalizaciones)
                .Include(x => x.InteraccionesBots)
                .Include(x => x.Raza)
                .Include(x => x.RegistroEscaneosQrs)
                .Include(x => x.Cita).ThenInclude(x => x.Veterinario)
                .Include(x => x.Dueño).ThenInclude(x => x.Rol)
                .Include(x => x.Hospitalizaciones).ThenInclude(x => x.Historial)
                .Include(x => x.Hospitalizaciones).ThenInclude(x => x.Veterinario)
                .Include(x => x.Raza).ThenInclude(x => x.Especie)
                .AsSplitQuery()
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
            return entity is null ? null : _mapper.Map<MascotaDto>(entity);
        }

        public async Task<bool> Create(MascotaDto dto)
        {
            var entity = new Mascota
            {
                Id = dto.Id,
                DueñoId = dto.DueñoId,
                RazaId = dto.RazaId,
                Nombre = dto.Nombre,
                Genero = dto.Genero,
                FechaNacimiento = dto.FechaNacimiento,
                PesoActual = dto.PesoActual,
                HashQrIdentidad = dto.HashQrIdentidad,
                Perdida = dto.Perdida,
                LatitudPerdida = dto.LatitudPerdida,
                LongitudPerdida = dto.LongitudPerdida,
                PuntoEntrega = dto.PuntoEntrega,
                Recompensa = dto.Recompensa,
                MensajeEncontrado = dto.MensajeEncontrado,
                CreatedAt = dto.CreatedAt,
                UpdatedAt = dto.UpdatedAt,
                DeletedAt = dto.DeletedAt
            };
            _context.Mascotas.Add(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Update(Guid id, MascotaDto dto)
        {
            var entity = await _context.Mascotas.FindAsync(id);
            if (entity == null) return false;

            entity.DueñoId = dto.DueñoId;
            entity.RazaId = dto.RazaId;
            entity.Nombre = dto.Nombre;
            entity.Genero = dto.Genero;
            entity.FechaNacimiento = dto.FechaNacimiento;
            entity.PesoActual = dto.PesoActual;
            entity.HashQrIdentidad = dto.HashQrIdentidad;
            entity.Perdida = dto.Perdida;
            entity.LatitudPerdida = dto.LatitudPerdida;
            entity.LongitudPerdida = dto.LongitudPerdida;
            entity.PuntoEntrega = dto.PuntoEntrega;
            entity.Recompensa = dto.Recompensa;
            entity.MensajeEncontrado = dto.MensajeEncontrado;
            entity.CreatedAt = dto.CreatedAt;
            entity.UpdatedAt = dto.UpdatedAt;
            entity.DeletedAt = dto.DeletedAt;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(Guid id)
        {
            var entity = await _context.Mascotas.FindAsync(id);
            if (entity == null) return false;

            _context.Mascotas.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}