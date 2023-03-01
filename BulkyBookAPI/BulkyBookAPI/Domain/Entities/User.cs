using BulkyBookAPI.Domain.DTOs;

namespace BulkyBookAPI.Domain.Entities
{
    public class User
    {

        public Guid UserId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Lastname { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Role { get; set; } = new UserRoles().BUYER;

    }
}
