using huellitas_api.Dtos;

namespace huellitas_api.Services.Interfaces
{
    public interface IHospitalizacionInsumoService
    {
        Task<List<HospitalizacionInsumoDto>> GetAll();
        Task<HospitalizacionInsumoDto?> GetById(Guid id);
        Task<bool> Create(HospitalizacionInsumoDto dto);
        Task<bool> Update(Guid id, HospitalizacionInsumoDto dto);
        Task<bool> Delete(Guid id);
    }
}