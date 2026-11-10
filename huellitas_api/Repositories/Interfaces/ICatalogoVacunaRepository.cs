using huellitas_api.Dtos;

namespace huellitas_api.Repositories.Interfaces
{
    public interface ICatalogoVacunaRepository
    {
        Task<List<CatalogoVacunaDto>> GetAll();
        Task<CatalogoVacunaDto?> GetById(int id);
        Task<bool> Create(CatalogoVacunaDto dto);
        Task<bool> Update(int id, CatalogoVacunaDto dto);
        Task<bool> Delete(int id);
    }
}