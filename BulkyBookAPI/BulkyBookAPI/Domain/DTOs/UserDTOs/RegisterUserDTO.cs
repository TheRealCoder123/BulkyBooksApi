namespace BulkyBookAPI.Domain.DTOs.UserDTOs
{
    public class RegisterUserDTO
    {
        public string Name { get; set; } = string.Empty;
        public string Lastname { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
