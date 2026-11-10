using huellitas_api.Dtos;
using huellitas_api.Repositories.Interfaces;
using huellitas_api.Services.Interfaces;

namespace huellitas_api.Services
{
    public class HealthService : IHealthService
    {
        private readonly IHealthRepository _repository;

        public HealthService(IHealthRepository repository)
        {
            _repository = repository;
        }

        public async Task<HealthDto> CheckHealthAsync()
        {
            var isConnected = await _repository.CheckDatabaseAsync();
            return new HealthDto { DatabaseConnected = isConnected };
        }
    }
}