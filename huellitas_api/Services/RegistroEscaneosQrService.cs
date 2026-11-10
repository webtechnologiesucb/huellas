using huellitas_api.Dtos;
using huellitas_api.Repositories.Interfaces;
using huellitas_api.Services.Interfaces;

namespace huellitas_api.Services
{
    public class RegistroEscaneosQrService : IRegistroEscaneosQrService
    {
        private readonly IRegistroEscaneosQrRepository _repository;

        public RegistroEscaneosQrService(IRegistroEscaneosQrRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<RegistroEscaneosQrDto>> GetAll() => await _repository.GetAll();
        public async Task<RegistroEscaneosQrDto?> GetById(Guid id) => await _repository.GetById(id);
        public async Task<bool> Create(RegistroEscaneosQrDto dto) => await _repository.Create(dto);
        public async Task<bool> Update(Guid id, RegistroEscaneosQrDto dto) => await _repository.Update(id, dto);
        public async Task<bool> Delete(Guid id) => await _repository.Delete(id);
    }
}