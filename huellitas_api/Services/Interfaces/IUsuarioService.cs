using huellitas_api.Dtos;

namespace huellitas_api.Services.Interfaces
{
    public interface IUsuarioService
    {
        Task<List<UsuarioDto>> GetAll();
        Task<UsuarioDto?> GetById(Guid id);
        Task<bool> Create(UsuarioDto dto);
        Task<bool> Update(Guid id, UsuarioDto dto);
        Task<bool> Delete(Guid id);
    }
}