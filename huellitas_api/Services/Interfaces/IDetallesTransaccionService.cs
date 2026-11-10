using huellitas_api.Dtos;

namespace huellitas_api.Services.Interfaces
{
    public interface IDetallesTransaccionService
    {
        Task<List<DetallesTransaccionDto>> GetAll();
        Task<DetallesTransaccionDto?> GetById(Guid id);
        Task<bool> Create(DetallesTransaccionDto dto);
        Task<bool> Update(Guid id, DetallesTransaccionDto dto);
        Task<bool> Delete(Guid id);
    }
}