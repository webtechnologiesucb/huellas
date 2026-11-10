using huellitas_api.Dtos;

namespace huellitas_api.Repositories.Interfaces
{
    public interface IMonitoreoDiarioRepository
    {
        Task<List<MonitoreoDiarioDto>> GetAll();
        Task<MonitoreoDiarioDto?> GetById(Guid id);
        Task<bool> Create(MonitoreoDiarioDto dto);
        Task<bool> Update(Guid id, MonitoreoDiarioDto dto);
        Task<bool> Delete(Guid id);
    }
}