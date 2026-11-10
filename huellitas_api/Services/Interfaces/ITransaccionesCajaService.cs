using huellitas_api.Dtos;

namespace huellitas_api.Services.Interfaces
{
    public interface ITransaccionesCajaService
    {
        Task<List<TransaccionesCajaDto>> GetAll();
        Task<TransaccionesCajaDto?> GetById(Guid id);
        Task<bool> Create(TransaccionesCajaDto dto);
        Task<bool> Update(Guid id, TransaccionesCajaDto dto);
        Task<bool> Delete(Guid id);
    }
}