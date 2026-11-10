using huellitas_api.Dtos;

namespace huellitas_api.Services.Interfaces
{
    public interface IConfiguracionClinicaService
    {
        Task<List<ConfiguracionClinicaDto>> GetAll();
        Task<ConfiguracionClinicaDto?> GetById(int id);
        Task<bool> Create(ConfiguracionClinicaDto dto);
        Task<bool> Update(int id, ConfiguracionClinicaDto dto);
        Task<bool> Delete(int id);
    }
}