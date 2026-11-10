using huellitas_api.Dtos;

namespace huellitas_api.Repositories.Interfaces
{
    public interface IHorariosAtencionRepository
    {
        Task<List<HorariosAtencionDto>> GetAll();
        Task<HorariosAtencionDto?> GetById(Guid id);
        Task<bool> Create(HorariosAtencionDto dto);
        Task<bool> Update(Guid id, HorariosAtencionDto dto);
        Task<bool> Delete(Guid id);
    }
}