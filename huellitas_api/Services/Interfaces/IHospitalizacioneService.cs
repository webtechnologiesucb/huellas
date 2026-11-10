using huellitas_api.Dtos;

namespace huellitas_api.Services.Interfaces
{
    public interface IHospitalizacioneService
    {
        Task<List<HospitalizacioneDto>> GetAll();
        Task<HospitalizacioneDto?> GetById(Guid id);
        Task<bool> Create(HospitalizacioneDto dto);
        Task<bool> Update(Guid id, HospitalizacioneDto dto);
        Task<bool> Delete(Guid id);
    }
}