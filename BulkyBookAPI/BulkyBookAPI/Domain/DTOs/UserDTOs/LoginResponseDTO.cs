using System.Net;

namespace BulkyBookAPI.Domain.DTOs.UserDTOs
{
    public class LoginResponseDTO
    {
        public string Message { get; set; } = string.Empty;
        public HttpStatusCode Status { get; set; }
        public bool Success { get; set; }
        public string Token { get; set; } = string.Empty;
        public UserResponseDTO? User { get; set; }

    }
}
