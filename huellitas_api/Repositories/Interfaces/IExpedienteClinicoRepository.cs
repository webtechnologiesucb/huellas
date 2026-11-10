using huellitas_api.Dtos;

namespace huellitas_api.Repositories.Interfaces
{
    public interface IExpedienteClinicoRepository
    {
        Task<List<ExpedienteClinicoDto>> GetAll();
        Task<ExpedienteClinicoDto?> GetById(Guid id);
        Task<bool> Create(ExpedienteClinicoDto dto);
        Task<bool> Update(Guid id, ExpedienteClinicoDto dto);
        Task<bool> Delete(Guid id);
    }
}