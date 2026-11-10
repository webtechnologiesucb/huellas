using AutoMapper;
using huellitas_api.Dtos;
using huellitas_api.Models;
using huellitas_api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace huellitas_api.Repositories
{
    public class ConfiguracionClinicaRepository : IConfiguracionClinicaRepository
    {
        private readonly HuellitasDigitalesContext _context;
        private readonly IMapper _mapper;

        public ConfiguracionClinicaRepository(HuellitasDigitalesContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<ConfiguracionClinicaDto>> GetAll()
        {
            var entities = await _context.ConfiguracionClinicas
                .AsSplitQuery()
                .AsNoTracking()
                .ToListAsync();
            return _mapper.Map<List<ConfiguracionClinicaDto>>(entities);
        }

        public async Task<ConfiguracionClinicaDto?> GetById(int id)
        {
            var entity = await _context.ConfiguracionClinicas
                .AsSplitQuery()
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
            return entity is null ? null : _mapper.Map<ConfiguracionClinicaDto>(entity);
        }

        public async Task<bool> Create(ConfiguracionClinicaDto dto)
        {
            var entity = new ConfiguracionClinica
            {
                Id = dto.Id,
                Clave = dto.Clave,
                Valor = dto.Valor,
                Descripcion = dto.Descripcion,
                UpdatedAt = dto.UpdatedAt
            };
            _context.ConfiguracionClinicas.Add(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Update(int id, ConfiguracionClinicaDto dto)
        {
            var entity = await _context.ConfiguracionClinicas.FindAsync(id);
            if (entity == null) return false;

            entity.Clave = dto.Clave;
            entity.Valor = dto.Valor;
            entity.Descripcion = dto.Descripcion;
            entity.UpdatedAt = dto.UpdatedAt;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            var entity = await _context.ConfiguracionClinicas.FindAsync(id);
            if (entity == null) return false;

            _context.ConfiguracionClinicas.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}