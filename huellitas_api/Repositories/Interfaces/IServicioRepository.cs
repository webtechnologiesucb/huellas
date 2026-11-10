using huellitas_api.Dtos;

namespace huellitas_api.Repositories.Interfaces
{
    public interface IServicioRepository
    {
        Task<List<ServicioDto>> GetAll();
        Task<ServicioDto?> GetById(int id);
        Task<bool> Create(ServicioDto dto);
        Task<bool> Update(int id, ServicioDto dto);
        Task<bool> Delete(int id);
    }
}