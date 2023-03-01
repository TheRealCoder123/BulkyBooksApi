namespace BulkyBookAPI.Domain.DTOs.GenreDTOs
{
    public class GenreResponseDTO
    {
        public string Message { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public GenreDTO Genre { get; set; } 
    }
}
