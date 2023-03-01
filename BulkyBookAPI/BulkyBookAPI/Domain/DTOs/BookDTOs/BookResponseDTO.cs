using BulkyBookAPI.Domain.DTOs.AuthorDTOs;

namespace BulkyBookAPI.Domain.DTOs.BookDTOs
{
    public class BookResponseDTO
    {
        public string Message { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public bool? Success { get; set; }
        public BookDTO? Book { get; set; }
        public IEnumerable<BookDTO>? Books { get; set; } = null;
    }
}
