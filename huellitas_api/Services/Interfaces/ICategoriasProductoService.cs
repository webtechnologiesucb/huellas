using huellitas_api.Dtos;

namespace huellitas_api.Services.Interfaces
{
    public interface ICategoriasProductoService
    {
        Task<List<CategoriasProductoDto>> GetAll();
        Task<CategoriasProductoDto?> GetById(int id);
        Task<bool> Create(CategoriasProductoDto dto);
        Task<bool> Update(int id, CategoriasProductoDto dto);
        Task<bool> Delete(int id);
    }
}