using huellitas_api.Dtos;
using huellitas_api.Repositories.Interfaces;
using huellitas_api.Services.Interfaces;

namespace huellitas_api.Services
{
    public class MonitoreoDiarioService : IMonitoreoDiarioService
    {
        private readonly IMonitoreoDiarioRepository _repository;

        public MonitoreoDiarioService(IMonitoreoDiarioRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<MonitoreoDiarioDto>> GetAll() => await _repository.GetAll();
        public async Task<MonitoreoDiarioDto?> GetById(Guid id) => await _repository.GetById(id);
        public async Task<bool> Create(MonitoreoDiarioDto dto) => await _repository.Create(dto);
        public async Task<bool> Update(Guid id, MonitoreoDiarioDto dto) => await _repository.Update(id, dto);
        public async Task<bool> Delete(Guid id) => await _repository.Delete(id);
    }
}