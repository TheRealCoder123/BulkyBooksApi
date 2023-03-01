namespace BulkyBookAPI.Domain.DTOs.AuthorDTOs
{
    public class AuthorResponseDTO
    {
        public string Message { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public bool? Success { get; set; }
        public AuthorDTO? Author { get; set; }
    }
}
