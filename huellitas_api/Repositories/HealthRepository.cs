using huellitas_api.Models;
using huellitas_api.Repositories.Interfaces;

namespace huellitas_api.Repositories
{
    public class HealthRepository : IHealthRepository
    {
        private readonly HuellitasDigitalesContext _context;

        public HealthRepository(HuellitasDigitalesContext context)
        {
            _context = context;
        }

        public async Task<bool> CheckDatabaseAsync()
        {
            try
            {
                return await _context.Database.CanConnectAsync();
            }
            catch
            {
                return false;
            }
        }
    }
}
