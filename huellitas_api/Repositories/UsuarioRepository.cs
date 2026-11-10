using AutoMapper;
using huellitas_api.Dtos;
using huellitas_api.Models;
using huellitas_api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace huellitas_api.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly HuellitasDigitalesContext _context;
        private readonly IMapper _mapper;

        public UsuarioRepository(HuellitasDigitalesContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<UsuarioDto>> GetAll()
        {
            var entities = await _context.Usuarios
                .Include(x => x.CierresCajas)
                .Include(x => x.Cita)
                .Include(x => x.FechasBloqueada)
                .Include(x => x.HistorialClinicos)
                .Include(x => x.HorariosAtencions)
                .Include(x => x.Hospitalizaciones)
                .Include(x => x.LogsSistemas)
                .Include(x => x.Mascota)
                .Include(x => x.MonitoreoDiarios)
                .Include(x => x.Receta)
                .Include(x => x.RegistroNotificaciones)
                .Include(x => x.Rol)
                .Include(x => x.TransaccionesCajas)
                .Include(x => x.Cita).ThenInclude(x => x.Mascota)
                .Include(x => x.HistorialClinicos).ThenInclude(x => x.Cita)
                .Include(x => x.HistorialClinicos).ThenInclude(x => x.Expediente)
                .Include(x => x.Hospitalizaciones).ThenInclude(x => x.Historial)
                .Include(x => x.Hospitalizaciones).ThenInclude(x => x.Mascota)
                .Include(x => x.Mascota).ThenInclude(x => x.ExpedienteClinico)
                .Include(x => x.Mascota).ThenInclude(x => x.Raza)
                .Include(x => x.MonitoreoDiarios).ThenInclude(x => x.Hospitalizacion)
                .Include(x => x.Receta).ThenInclude(x => x.Historial)
                .Include(x => x.TransaccionesCajas).ThenInclude(x => x.Historial)
                .Include(x => x.TransaccionesCajas).ThenInclude(x => x.Hospitalizacion)
                .AsSplitQuery()
                .AsNoTracking()
                .ToListAsync();
            return _mapper.Map<List<UsuarioDto>>(entities);
        }

        public async Task<UsuarioDto?> GetById(Guid id)
        {
            var entity = await _context.Usuarios
                .Include(x => x.CierresCajas)
                .Include(x => x.Cita)
                .Include(x => x.FechasBloqueada)
                .Include(x => x.HistorialClinicos)
                .Include(x => x.HorariosAtencions)
                .Include(x => x.Hospitalizaciones)
                .Include(x => x.LogsSistemas)
                .Include(x => x.Mascota)
                .Include(x => x.MonitoreoDiarios)
                .Include(x => x.Receta)
                .Include(x => x.RegistroNotificaciones)
                .Include(x => x.Rol)
                .Include(x => x.TransaccionesCajas)
                .Include(x => x.Cita).ThenInclude(x => x.Mascota)
                .Include(x => x.HistorialClinicos).ThenInclude(x => x.Cita)
                .Include(x => x.HistorialClinicos).ThenInclude(x => x.Expediente)
                .Include(x => x.Hospitalizaciones).ThenInclude(x => x.Historial)
                .Include(x => x.Hospitalizaciones).ThenInclude(x => x.Mascota)
                .Include(x => x.Mascota).ThenInclude(x => x.ExpedienteClinico)
                .Include(x => x.Mascota).ThenInclude(x => x.Raza)
                .Include(x => x.MonitoreoDiarios).ThenInclude(x => x.Hospitalizacion)
                .Include(x => x.Receta).ThenInclude(x => x.Historial)
                .Include(x => x.TransaccionesCajas).ThenInclude(x => x.Historial)
                .Include(x => x.TransaccionesCajas).ThenInclude(x => x.Hospitalizacion)
                .AsSplitQuery()
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
            return entity is null ? null : _mapper.Map<UsuarioDto>(entity);
        }

        public async Task<bool> Create(UsuarioDto dto)
        {
            var entity = new Usuario
            {
                Id = dto.Id,
                RolId = dto.RolId,
                Nombres = dto.Nombres,
                Apellidos = dto.Apellidos,
                Email = dto.Email,
                PasswordHash = dto.PasswordHash,
                Telefono = dto.Telefono,
                IntentosFallidos = dto.IntentosFallidos,
                BloqueadoHasta = dto.BloqueadoHasta,
                CreatedAt = dto.CreatedAt,
                UpdatedAt = dto.UpdatedAt,
                DeletedAt = dto.DeletedAt
            };
            _context.Usuarios.Add(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Update(Guid id, UsuarioDto dto)
        {
            var entity = await _context.Usuarios.FindAsync(id);
            if (entity == null) return false;

            entity.RolId = dto.RolId;
            entity.Nombres = dto.Nombres;
            entity.Apellidos = dto.Apellidos;
            entity.Email = dto.Email;
            entity.PasswordHash = dto.PasswordHash;
            entity.Telefono = dto.Telefono;
            entity.IntentosFallidos = dto.IntentosFallidos;
            entity.BloqueadoHasta = dto.BloqueadoHasta;
            entity.CreatedAt = dto.CreatedAt;
            entity.UpdatedAt = dto.UpdatedAt;
            entity.DeletedAt = dto.DeletedAt;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(Guid id)
        {
            var entity = await _context.Usuarios.FindAsync(id);
            if (entity == null) return false;

            _context.Usuarios.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}