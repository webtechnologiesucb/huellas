using huellitas_api.Dtos;

namespace huellitas_api.Services.Interfaces
{
    public interface IHistorialClinicoService
    {
        Task<List<HistorialClinicoDto>> GetAll();
        Task<HistorialClinicoDto?> GetById(Guid id);
        Task<bool> Create(HistorialClinicoDto dto);
        Task<bool> Update(Guid id, HistorialClinicoDto dto);
        Task<bool> Delete(Guid id);
    }
}