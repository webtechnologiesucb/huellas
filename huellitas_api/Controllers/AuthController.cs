using huellitas_api.Handlers;
using huellitas_api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace huellitas_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AuthController : ControllerBase
    {
        private readonly HuellitasDigitalesContext _dbContext;
        private readonly JwtSettings _jwtSettings;
        private readonly IRefreshTokenGenerator _refreshTokenGenerator;

        public AuthController(
            HuellitasDigitalesContext dbContext,
            IOptions<JwtSettings> options,
            IRefreshTokenGenerator refreshTokenGenerator)
        {
            _dbContext = dbContext;
            _jwtSettings = options.Value;
            _refreshTokenGenerator = refreshTokenGenerator;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(
            [FromBody] UserCred userCred,
            CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(userCred.Email) ||
                string.IsNullOrWhiteSpace(userCred.Password))
            {
                return BadRequest(new { message = "Email y contraseña son requeridos" });
            }

            var user = await _dbContext.Usuarios
                .FirstOrDefaultAsync(
                    candidate => candidate.Email == userCred.Email.Trim() &&
                                 candidate.DeletedAt == null,
                    cancellationToken);

            if (user == null)
            {
                return Unauthorized(new { message = "Credenciales inválidas" });
            }

            if (user.BloqueadoHasta > DateTime.UtcNow ||
                !BCrypt.Net.BCrypt.Verify(userCred.Password, user.PasswordHash))
            {
                return Unauthorized(new { message = "Credenciales inválidas" });
            }

            return Ok(await GenerateTokenPairAsync(user, cancellationToken));
        }

        [HttpPost("Refresh")]
        public async Task<IActionResult> Refresh(
            [FromBody] TokenResponse tokenResponse,
            CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(tokenResponse.JwtToken) ||
                string.IsNullOrWhiteSpace(tokenResponse.RefreshToken))
            {
                return BadRequest(new { message = "Token y refresh token son requeridos" });
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            ClaimsPrincipal principal;
            try
            {
                principal = tokenHandler.ValidateToken(
                    tokenResponse.JwtToken,
                    new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(_jwtSettings.SecurityKey)),
                        ValidateIssuer = true,
                        ValidIssuer = _jwtSettings.Issuer,
                        ValidateAudience = true,
                        ValidAudience = _jwtSettings.Audience,
                        ValidateLifetime = false,
                        ValidAlgorithms = [SecurityAlgorithms.HmacSha256],
                        ClockSkew = TimeSpan.Zero,
                        NameClaimType = ClaimTypes.Name
                    },
                    out var validatedToken);

                if (validatedToken is not JwtSecurityToken jwtSecurityToken ||
                    jwtSecurityToken.ValidTo == DateTime.MinValue)
                {
                    return Unauthorized(new { message = "Token inválido" });
                }
            }
            catch (Exception exception) when (
                exception is SecurityTokenException or ArgumentException)
            {
                return Unauthorized(new { message = "Token expirado o inválido" });
            }

            var userIdClaim = principal.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var userEmail = principal.FindFirst(ClaimTypes.Email)?.Value;
            if (!Guid.TryParse(userIdClaim, out var userId) ||
                string.IsNullOrWhiteSpace(userEmail))
            {
                return Unauthorized(new { message = "Token inválido" });
            }

            var now = DateTime.UtcNow;
            var storedToken = await _dbContext.RefreshTokens
                .FirstOrDefaultAsync(token =>
                    token.UserEmail == userEmail &&
                    token.Token == RefreshTokenHasher.Hash(tokenResponse.RefreshToken) &&
                    token.IsValid &&
                    token.ExpiresAt > now,
                    cancellationToken);
            var user = await _dbContext.Usuarios
                .FirstOrDefaultAsync(
                    candidate => candidate.Id == userId &&
                                 candidate.Email == userEmail &&
                                 candidate.DeletedAt == null &&
                                 (candidate.BloqueadoHasta == null || candidate.BloqueadoHasta <= now),
                    cancellationToken);

            if (storedToken == null || user == null)
            {
                return Unauthorized(new { message = "Refresh token inválido o expirado" });
            }

            var refreshToken = await _refreshTokenGenerator.RotateToken(
                storedToken,
                cancellationToken);
            if (refreshToken == null)
            {
                return Unauthorized(new { message = "Refresh token inválido o expirado" });
            }

            return Ok(new TokenResponse
            {
                JwtToken = GenerateJwtToken(CreateClaims(user)),
                RefreshToken = refreshToken
            });
        }

        private async Task<TokenResponse> GenerateTokenPairAsync(
            Usuario user,
            CancellationToken cancellationToken)
        {
            return new TokenResponse
            {
                JwtToken = GenerateJwtToken(CreateClaims(user)),
                RefreshToken = await _refreshTokenGenerator.GenerateToken(
                    user.Email,
                    cancellationToken)
            };
        }

        private static Claim[] CreateClaims(Usuario user)
        {
            return
            [
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Email),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.RolId.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            ];
        }

        private string GenerateJwtToken(IEnumerable<Claim> claims)
        {
            var now = DateTime.UtcNow;
            var token = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                notBefore: now,
                expires: now.AddMinutes(_jwtSettings.AccessTokenMinutes),
                signingCredentials: new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SecurityKey)),
                    SecurityAlgorithms.HmacSha256)
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
