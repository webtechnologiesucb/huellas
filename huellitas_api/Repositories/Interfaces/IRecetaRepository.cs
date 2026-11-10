using huellitas_api.Dtos;

namespace huellitas_api.Repositories.Interfaces
{
    public interface IRecetaRepository
    {
        Task<List<RecetaDto>> GetAll();
        Task<RecetaDto?> GetById(Guid id);
        Task<bool> Create(RecetaDto dto);
        Task<bool> Update(Guid id, RecetaDto dto);
        Task<bool> Delete(Guid id);
    }
}