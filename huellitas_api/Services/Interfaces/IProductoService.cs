using huellitas_api.Dtos;

namespace huellitas_api.Services.Interfaces
{
    public interface IProductoService
    {
        Task<List<ProductoDto>> GetAll();
        Task<ProductoDto?> GetById(Guid id);
        Task<bool> Create(ProductoDto dto);
        Task<bool> Update(Guid id, ProductoDto dto);
        Task<bool> Delete(Guid id);
    }
}