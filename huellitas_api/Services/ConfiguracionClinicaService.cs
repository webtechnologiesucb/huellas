using huellitas_api.Dtos;
using huellitas_api.Repositories.Interfaces;
using huellitas_api.Services.Interfaces;

namespace huellitas_api.Services
{
    public class ConfiguracionClinicaService : IConfiguracionClinicaService
    {
        private readonly IConfiguracionClinicaRepository _repository;

        public ConfiguracionClinicaService(IConfiguracionClinicaRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<ConfiguracionClinicaDto>> GetAll() => await _repository.GetAll();
        public async Task<ConfiguracionClinicaDto?> GetById(int id) => await _repository.GetById(id);
        public async Task<bool> Create(ConfiguracionClinicaDto dto) => await _repository.Create(dto);
        public async Task<bool> Update(int id, ConfiguracionClinicaDto dto) => await _repository.Update(id, dto);
        public async Task<bool> Delete(int id) => await _repository.Delete(id);
    }
}