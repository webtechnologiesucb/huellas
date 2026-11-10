using System;

namespace huellitas_api.Models
{
    public class RefreshToken
    {
        public int Id { get; set; }
        public string UserEmail { get; set; } = null!;
        public string Token { get; set; } = null!;
        public bool IsValid { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ExpiresAt { get; set; }
    }
}