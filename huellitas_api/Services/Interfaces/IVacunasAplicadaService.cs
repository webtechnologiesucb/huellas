using huellitas_api.Dtos;

namespace huellitas_api.Services.Interfaces
{
    public interface IVacunasAplicadaService
    {
        Task<List<VacunasAplicadaDto>> GetAll();
        Task<VacunasAplicadaDto?> GetById(Guid id);
        Task<bool> Create(VacunasAplicadaDto dto);
        Task<bool> Update(Guid id, VacunasAplicadaDto dto);
        Task<bool> Delete(Guid id);
    }
}