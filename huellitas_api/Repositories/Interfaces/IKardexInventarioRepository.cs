using huellitas_api.Dtos;

namespace huellitas_api.Repositories.Interfaces
{
    public interface IKardexInventarioRepository
    {
        Task<List<KardexInventarioDto>> GetAll();
        Task<KardexInventarioDto?> GetById(Guid id);
        Task<bool> Create(KardexInventarioDto dto);
        Task<bool> Update(Guid id, KardexInventarioDto dto);
        Task<bool> Delete(Guid id);
    }
}