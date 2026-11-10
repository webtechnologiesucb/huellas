using huellitas_api.Models;

namespace huellitas_api.Handlers
{
    public interface IRefreshTokenGenerator
    {
        Task<string> GenerateToken(string userEmail, CancellationToken cancellationToken);
        Task<string?> RotateToken(RefreshToken storedToken, CancellationToken cancellationToken);
    }
}