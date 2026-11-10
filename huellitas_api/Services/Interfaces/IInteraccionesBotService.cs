using huellitas_api.Dtos;

namespace huellitas_api.Services.Interfaces
{
    public interface IInteraccionesBotService
    {
        Task<List<InteraccionesBotDto>> GetAll();
        Task<InteraccionesBotDto?> GetById(Guid id);
        Task<bool> Create(InteraccionesBotDto dto);
        Task<bool> Update(Guid id, InteraccionesBotDto dto);
        Task<bool> Delete(Guid id);
    }
}