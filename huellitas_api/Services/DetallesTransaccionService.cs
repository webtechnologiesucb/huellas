using huellitas_api.Dtos;
using huellitas_api.Repositories.Interfaces;
using huellitas_api.Services.Interfaces;

namespace huellitas_api.Services
{
    public class DetallesTransaccionService : IDetallesTransaccionService
    {
        private readonly IDetallesTransaccionRepository _repository;

        public DetallesTransaccionService(IDetallesTransaccionRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<DetallesTransaccionDto>> GetAll() => await _repository.GetAll();
        public async Task<DetallesTransaccionDto?> GetById(Guid id) => await _repository.GetById(id);
        public async Task<bool> Create(DetallesTransaccionDto dto) => await _repository.Create(dto);
        public async Task<bool> Update(Guid id, DetallesTransaccionDto dto) => await _repository.Update(id, dto);
        public async Task<bool> Delete(Guid id) => await _repository.Delete(id);
    }
}