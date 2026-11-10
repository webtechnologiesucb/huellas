using huellitas_api.Dtos;

namespace huellitas_api.Repositories.Interfaces
{
    public interface IRazaRepository
    {
        Task<List<RazaDto>> GetAll();
        Task<RazaDto?> GetById(int id);
        Task<bool> Create(RazaDto dto);
        Task<bool> Update(int id, RazaDto dto);
        Task<bool> Delete(int id);
    }
}