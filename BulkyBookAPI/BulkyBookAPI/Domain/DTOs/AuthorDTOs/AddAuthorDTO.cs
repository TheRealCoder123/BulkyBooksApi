namespace BulkyBookAPI.Domain.DTOs.AuthorDTOs
{
    public class AddAuthorDTO
    {
        public string Name { get; set; } = string.Empty;
        public string Lastname { get; set; } = string.Empty;
        public string? MiddleName { get; set; }
        public string? Birthdate { get; set; }
        public string? Nationality { get; set; }
        public string Biography { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;

    }
}
