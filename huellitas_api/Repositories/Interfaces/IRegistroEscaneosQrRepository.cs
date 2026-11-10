using huellitas_api.Dtos;

namespace huellitas_api.Repositories.Interfaces
{
    public interface IRegistroEscaneosQrRepository
    {
        Task<List<RegistroEscaneosQrDto>> GetAll();
        Task<RegistroEscaneosQrDto?> GetById(Guid id);
        Task<bool> Create(RegistroEscaneosQrDto dto);
        Task<bool> Update(Guid id, RegistroEscaneosQrDto dto);
        Task<bool> Delete(Guid id);
    }
}