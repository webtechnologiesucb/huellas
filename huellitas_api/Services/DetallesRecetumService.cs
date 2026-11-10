using huellitas_api.Dtos;
using huellitas_api.Repositories.Interfaces;
using huellitas_api.Services.Interfaces;

namespace huellitas_api.Services
{
    public class DetallesRecetumService : IDetallesRecetumService
    {
        private readonly IDetallesRecetumRepository _repository;

        public DetallesRecetumService(IDetallesRecetumRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<DetallesRecetumDto>> GetAll() => await _repository.GetAll();
        public async Task<DetallesRecetumDto?> GetById(Guid id) => await _repository.GetById(id);
        public async Task<bool> Create(DetallesRecetumDto dto) => await _repository.Create(dto);
        public async Task<bool> Update(Guid id, DetallesRecetumDto dto) => await _repository.Update(id, dto);
        public async Task<bool> Delete(Guid id) => await _repository.Delete(id);
    }
}