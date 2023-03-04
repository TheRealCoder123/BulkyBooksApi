using BulkyBookAPI.Domain.DTOs.BookDTOs;
using BulkyBookAPI.Domain.Entities;

namespace BulkyBookAPI.Repository
{
    public interface IBookRepository
    {

        Task<BookDTO> AddNewBookAsync(AddBookDTO addBookDTO);
        Task<IEnumerable<BookDTO>> GetAllBooksAsync();
        Task<IEnumerable<BookDTO>> GetBooksByGenre(Guid GenreId);
        Task<IEnumerable<BookDTO>?> GetBooksByAuthor(Guid AuthorId);
        Task<BookResponseDTO> GetBookById(Guid bookId);
        Task<IEnumerable<BookDTO>?> SearchBooks(string query);



    }
}
