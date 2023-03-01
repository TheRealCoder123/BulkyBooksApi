namespace BulkyBookAPI.Domain.DTOs.GenreDTOs
{
    public class GenreDTO
    {
        public Guid GenreId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? GenreImg { get; set; }
    }
}
