using System.Net;

namespace BlogAppAPI.Services.Payload
{
    public class APIResponse
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
        public object? Payload { get; set; }
        public HttpStatusCode? StatusCode { get; set; }
    }
}
