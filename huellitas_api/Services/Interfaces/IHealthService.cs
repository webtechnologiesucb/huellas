using huellitas_api.Dtos;

namespace huellitas_api.Services.Interfaces
{
    public interface IHealthService
    {
        Task<HealthDto> CheckHealthAsync();
    }
}