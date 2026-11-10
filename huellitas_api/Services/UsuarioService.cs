using huellitas_api.Dtos;
using huellitas_api.Repositories.Interfaces;
using huellitas_api.Services.Interfaces;

namespace huellitas_api.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _repository;

        public UsuarioService(IUsuarioRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<UsuarioDto>> GetAll() => await _repository.GetAll();
        public async Task<UsuarioDto?> GetById(Guid id) => await _repository.GetById(id);
        public async Task<bool> Create(UsuarioDto dto) => await _repository.Create(dto);
        public async Task<bool> Update(Guid id, UsuarioDto dto) => await _repository.Update(id, dto);
        public async Task<bool> Delete(Guid id) => await _repository.Delete(id);
    }
}