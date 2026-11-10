using huellitas_api.Dtos;

namespace huellitas_api.Services.Interfaces
{
    public interface ILogsSistemaService
    {
        Task<List<LogsSistemaDto>> GetAll();
        Task<LogsSistemaDto?> GetById(Guid id);
        Task<bool> Create(LogsSistemaDto dto);
        Task<bool> Update(Guid id, LogsSistemaDto dto);
        Task<bool> Delete(Guid id);
    }
}