using huellitas_api.Dtos;
using huellitas_api.Repositories.Interfaces;
using huellitas_api.Services.Interfaces;

namespace huellitas_api.Services
{
    public class ServicioService : IServicioService
    {
        private readonly IServicioRepository _repository;

        public ServicioService(IServicioRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<ServicioDto>> GetAll() => await _repository.GetAll();
        public async Task<ServicioDto?> GetById(int id) => await _repository.GetById(id);
        public async Task<bool> Create(ServicioDto dto) => await _repository.Create(dto);
        public async Task<bool> Update(int id, ServicioDto dto) => await _repository.Update(id, dto);
        public async Task<bool> Delete(int id) => await _repository.Delete(id);
    }
}