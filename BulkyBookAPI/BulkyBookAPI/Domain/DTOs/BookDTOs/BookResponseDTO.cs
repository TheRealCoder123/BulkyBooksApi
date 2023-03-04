using BulkyBookAPI.Domain.DTOs.AuthorDTOs;
using System.Net;

namespace BulkyBookAPI.Domain.DTOs.BookDTOs
{
    public class BookResponseDTO
    {
        public string Message { get; set; } = string.Empty;
        public HttpStatusCode Status { get; set; } 
        public bool? Success { get; set; }
        public BookDTO? Book { get; set; }
        public IEnumerable<BookDTO>? Books { get; set; } = null;
    }
}
