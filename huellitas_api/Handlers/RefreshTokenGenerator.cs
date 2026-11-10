using System.Security.Cryptography;
using huellitas_api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace huellitas_api.Handlers
{
    public class RefreshTokenGenerator : IRefreshTokenGenerator
    {
        private readonly HuellitasDigitalesContext _dbContext;
        private readonly JwtSettings _jwtSettings;

        public RefreshTokenGenerator(
            HuellitasDigitalesContext dbContext,
            IOptions<JwtSettings> options)
        {
            _dbContext = dbContext;
            _jwtSettings = options.Value;
        }

        public async Task<string> GenerateToken(
            string userEmail,
            CancellationToken cancellationToken)
        {
            var refreshToken = CreateToken();

            var existingToken = await _dbContext.RefreshTokens
                .FirstOrDefaultAsync(t => t.UserEmail == userEmail, cancellationToken);

            if (existingToken != null)
            {
                existingToken.Token = RefreshTokenHasher.Hash(refreshToken);
                existingToken.IsValid = true;
                existingToken.CreatedAt = DateTime.UtcNow;
                existingToken.ExpiresAt = DateTime.UtcNow.AddDays(_jwtSettings.RefreshTokenDays);
            }
            else
            {
                _dbContext.RefreshTokens.Add(new RefreshToken
                {
                    UserEmail = userEmail,
                    Token = RefreshTokenHasher.Hash(refreshToken),
                    IsValid = true,
                    CreatedAt = DateTime.UtcNow,
                    ExpiresAt = DateTime.UtcNow.AddDays(_jwtSettings.RefreshTokenDays)
                });
            }

            await _dbContext.SaveChangesAsync(cancellationToken);
            return refreshToken;
        }

        public async Task<string?> RotateToken(
            RefreshToken storedToken,
            CancellationToken cancellationToken)
        {
            var refreshToken = CreateToken();
            var now = DateTime.UtcNow;
            var updatedRows = await _dbContext.RefreshTokens
                .Where(token =>
                    token.Id == storedToken.Id &&
                    token.Token == storedToken.Token &&
                    token.IsValid &&
                    token.ExpiresAt > now)
                .ExecuteUpdateAsync(updates => updates
                    .SetProperty(token => token.Token, RefreshTokenHasher.Hash(refreshToken))
                    .SetProperty(token => token.IsValid, true)
                    .SetProperty(token => token.CreatedAt, now)
                    .SetProperty(token => token.ExpiresAt, now.AddDays(_jwtSettings.RefreshTokenDays)),
                    cancellationToken);

            return updatedRows == 1 ? refreshToken : null;
        }

        private static string CreateToken()
        {
            return Convert.ToBase64String(RandomNumberGenerator.GetBytes(32));
        }
    }
}