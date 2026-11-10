using huellitas_api.Dtos;

namespace huellitas_api.Repositories.Interfaces
{
    public interface IHospitalizacionInsumoRepository
    {
        Task<List<HospitalizacionInsumoDto>> GetAll();
        Task<HospitalizacionInsumoDto?> GetById(Guid id);
        Task<bool> Create(HospitalizacionInsumoDto dto);
        Task<bool> Update(Guid id, HospitalizacionInsumoDto dto);
        Task<bool> Delete(Guid id);
    }
}