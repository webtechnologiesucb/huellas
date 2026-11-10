using huellitas_api.Dtos;
using huellitas_api.Repositories.Interfaces;
using huellitas_api.Services.Interfaces;

namespace huellitas_api.Services
{
    public class KardexInventarioService : IKardexInventarioService
    {
        private readonly IKardexInventarioRepository _repository;

        public KardexInventarioService(IKardexInventarioRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<KardexInventarioDto>> GetAll() => await _repository.GetAll();
        public async Task<KardexInventarioDto?> GetById(Guid id) => await _repository.GetById(id);
        public async Task<bool> Create(KardexInventarioDto dto) => await _repository.Create(dto);
        public async Task<bool> Update(Guid id, KardexInventarioDto dto) => await _repository.Update(id, dto);
        public async Task<bool> Delete(Guid id) => await _repository.Delete(id);
    }
}