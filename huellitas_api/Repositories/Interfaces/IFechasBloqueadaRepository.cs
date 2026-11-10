using huellitas_api.Dtos;

namespace huellitas_api.Repositories.Interfaces
{
    public interface IFechasBloqueadaRepository
    {
        Task<List<FechasBloqueadaDto>> GetAll();
        Task<FechasBloqueadaDto?> GetById(Guid id);
        Task<bool> Create(FechasBloqueadaDto dto);
        Task<bool> Update(Guid id, FechasBloqueadaDto dto);
        Task<bool> Delete(Guid id);
    }
}