using huellitas_api.Dtos;

namespace huellitas_api.Services.Interfaces
{
    public interface IArchivosAdjuntoService
    {
        Task<List<ArchivosAdjuntoDto>> GetAll();
        Task<ArchivosAdjuntoDto?> GetById(Guid id);
        Task<bool> Create(ArchivosAdjuntoDto dto);
        Task<bool> Update(Guid id, ArchivosAdjuntoDto dto);
        Task<bool> Delete(Guid id);
    }
}