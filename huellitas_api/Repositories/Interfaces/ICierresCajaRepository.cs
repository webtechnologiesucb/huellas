using huellitas_api.Dtos;

namespace huellitas_api.Repositories.Interfaces
{
    public interface ICierresCajaRepository
    {
        Task<List<CierresCajaDto>> GetAll();
        Task<CierresCajaDto?> GetById(Guid id);
        Task<bool> Create(CierresCajaDto dto);
        Task<bool> Update(Guid id, CierresCajaDto dto);
        Task<bool> Delete(Guid id);
    }
}