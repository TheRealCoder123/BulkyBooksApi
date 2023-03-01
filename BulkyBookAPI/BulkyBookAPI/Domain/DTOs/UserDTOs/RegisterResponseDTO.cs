using System.Net;

namespace BulkyBookAPI.Domain.DTOs.UserDTOs
{
    public class RegisterResponseDTO
    {

        public string Message { get; set; } = string.Empty;
        public HttpStatusCode Status { get; set; } 
        public bool Success { get; set; }

    }
}
