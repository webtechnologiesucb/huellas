using huellitas_api.Dtos;

namespace huellitas_api.Repositories.Interfaces
{
    public interface ILotesCaducidadRepository
    {
        Task<List<LotesCaducidadDto>> GetAll();
        Task<LotesCaducidadDto?> GetById(Guid id);
        Task<bool> Create(LotesCaducidadDto dto);
        Task<bool> Update(Guid id, LotesCaducidadDto dto);
        Task<bool> Delete(Guid id);
    }
}