using huellitas_api.Dtos;

namespace huellitas_api.Services.Interfaces
{
    public interface IEspecyService
    {
        Task<List<EspecyDto>> GetAll();
        Task<EspecyDto?> GetById(int id);
        Task<bool> Create(EspecyDto dto);
        Task<bool> Update(int id, EspecyDto dto);
        Task<bool> Delete(int id);
    }
}