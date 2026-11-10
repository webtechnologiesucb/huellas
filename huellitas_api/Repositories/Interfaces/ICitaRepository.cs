using huellitas_api.Dtos;

namespace huellitas_api.Repositories.Interfaces
{
    public interface ICitaRepository
    {
        Task<List<CitaDto>> GetAll();
        Task<CitaDto?> GetById(Guid id);
        Task<bool> Create(CitaDto dto);
        Task<bool> Update(Guid id, CitaDto dto);
        Task<bool> Delete(Guid id);
    }
}