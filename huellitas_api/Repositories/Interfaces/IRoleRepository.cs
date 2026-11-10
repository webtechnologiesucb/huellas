using huellitas_api.Dtos;

namespace huellitas_api.Repositories.Interfaces
{
    public interface IRoleRepository
    {
        Task<List<RoleDto>> GetAll();
        Task<RoleDto?> GetById(int id);
        Task<bool> Create(RoleDto dto);
        Task<bool> Update(int id, RoleDto dto);
        Task<bool> Delete(int id);
    }
}