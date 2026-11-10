namespace huellitas_api.Models
{
    public class TokenResponse
    {
        public string? JwtToken { get; set; }
        public string? RefreshToken { get; set; }
    }
}