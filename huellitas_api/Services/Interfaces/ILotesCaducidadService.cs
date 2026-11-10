using huellitas_api.Dtos;

namespace huellitas_api.Services.Interfaces
{
    public interface ILotesCaducidadService
    {
        Task<List<LotesCaducidadDto>> GetAll();
        Task<LotesCaducidadDto?> GetById(Guid id);
        Task<bool> Create(LotesCaducidadDto dto);
        Task<bool> Update(Guid id, LotesCaducidadDto dto);
        Task<bool> Delete(Guid id);
    }
}