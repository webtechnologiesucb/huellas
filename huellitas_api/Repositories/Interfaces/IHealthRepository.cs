namespace huellitas_api.Repositories.Interfaces
{
    public interface IHealthRepository
    {
        Task<bool> CheckDatabaseAsync();
    }
}
