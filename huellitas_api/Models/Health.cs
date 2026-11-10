namespace huellitas_api.Models
{
    class HealthResponse
    {
        public string Status { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public DateTime Timestamp { get; set; }
        public string Database { get; set; } = string.Empty;
    }
}
