using huellitas_api.Dtos;

namespace huellitas_api.Repositories.Interfaces
{
    public interface IRegistroNotificacioneRepository
    {
        Task<List<RegistroNotificacioneDto>> GetAll();
        Task<RegistroNotificacioneDto?> GetById(Guid id);
        Task<bool> Create(RegistroNotificacioneDto dto);
        Task<bool> Update(Guid id, RegistroNotificacioneDto dto);
        Task<bool> Delete(Guid id);
    }
}