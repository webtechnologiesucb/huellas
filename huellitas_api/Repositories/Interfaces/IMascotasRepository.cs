using huellitas_api.Dtos;

namespace huellitas_api.Repositories.Interfaces
{
    public interface IMascotasRepository
    {
        Task<List<MascotaDto>> GetAll();
        Task<MascotaDto?> GetById(Guid id);
        Task<bool> Create(MascotaDto dto);
        Task<bool> Update(Guid id, MascotaDto dto);
        Task<bool> Delete(Guid id);
    }
}