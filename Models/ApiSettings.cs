namespace FlightPal.Models
{
    public class ApiSettings
    {
        public CedulaApiSettings CedulaApi { get; set; } = new();
    }

    public class CedulaApiSettings
    {
        public string BaseUrl { get; set; } = string.Empty;
        public string AppId { get; set; } = string.Empty;
        public string Token { get; set; } = string.Empty;
    }
}
