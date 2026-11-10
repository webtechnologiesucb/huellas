using huellitas_api.Dtos;

namespace huellitas_api.Services.Interfaces
{
    public interface IDetallesRecetumService
    {
        Task<List<DetallesRecetumDto>> GetAll();
        Task<DetallesRecetumDto?> GetById(Guid id);
        Task<bool> Create(DetallesRecetumDto dto);
        Task<bool> Update(Guid id, DetallesRecetumDto dto);
        Task<bool> Delete(Guid id);
    }
}