using huellitas_api.Dtos;
using huellitas_api.Repositories.Interfaces;
using huellitas_api.Services.Interfaces;

namespace huellitas_api.Services
{
    public class RegistroNotificacioneService : IRegistroNotificacioneService
    {
        private readonly IRegistroNotificacioneRepository _repository;

        public RegistroNotificacioneService(IRegistroNotificacioneRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<RegistroNotificacioneDto>> GetAll() => await _repository.GetAll();
        public async Task<RegistroNotificacioneDto?> GetById(Guid id) => await _repository.GetById(id);
        public async Task<bool> Create(RegistroNotificacioneDto dto) => await _repository.Create(dto);
        public async Task<bool> Update(Guid id, RegistroNotificacioneDto dto) => await _repository.Update(id, dto);
        public async Task<bool> Delete(Guid id) => await _repository.Delete(id);
    }
}