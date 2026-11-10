using huellitas_api.Dtos;
using huellitas_api.Repositories.Interfaces;
using huellitas_api.Services.Interfaces;

namespace huellitas_api.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _repository;

        public RoleService(IRoleRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<RoleDto>> GetAll() => await _repository.GetAll();
        public async Task<RoleDto?> GetById(int id) => await _repository.GetById(id);
        public async Task<bool> Create(RoleDto dto) => await _repository.Create(dto);
        public async Task<bool> Update(int id, RoleDto dto) => await _repository.Update(id, dto);
        public async Task<bool> Delete(int id) => await _repository.Delete(id);
    }
}