using BulkyBookAPI.Domain.DTOs;
using BulkyBookAPI.Domain.DTOs.BookDTOs;
using BulkyBookAPI.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BulkyBookAPI.Controllers
{

    [ApiController]
    [Route("books")]
    public class BookController : Controller
    {
        private readonly IBookRepository _bookRepository;

        public BookController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetBooksAsync() { 

            var books = await _bookRepository.GetAllBooksAsync();
            return Ok(books);

        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddNewBookAsync([FromBody] AddBookDTO addBookDTO) {

            var newBook = await _bookRepository.AddNewBookAsync(addBookDTO);

            var BookReponse = new BookResponseDTO
            {
                Book = newBook
            };

            if (newBook == null) {

                BookReponse.Success = false;
                BookReponse.Message = "Something went wrong, check if the author or genre exist";
                BookReponse.Status = HttpStatusCode.BadRequest.ToString();

                return BadRequest(BookReponse);

            }

            BookReponse.Success = true;
            BookReponse.Message = "Book successfully added";
            BookReponse.Status = HttpStatusCode.OK.ToString();

            return Ok(BookReponse);
        
        }

        [HttpGet]
        [Route("booksBy/genre/{genre_id}")]
        [Authorize]
        public async Task<IActionResult> GetBooksByGenreIdAsync(Guid genre_id) {

            var books = await _bookRepository.GetBooksByGenre(genre_id);

            var BookReponse = new BookResponseDTO
            {
                Book = null,
                Books = books
            };

            if (books == null)
            {

                BookReponse.Success = false;
                BookReponse.Message = "Something went wrong, check if the genre exist";
                BookReponse.Status = HttpStatusCode.BadRequest.ToString();

                return BadRequest(BookReponse);

            }

            BookReponse.Success = true;
            BookReponse.Message = "All books in this genre";
            BookReponse.Status = HttpStatusCode.OK.ToString();

            return Ok(BookReponse);
        }

        [HttpGet]
        [Route("booksBy/author/{author_id}")]
        [Authorize]
        public async Task<IActionResult> GetBooksByAuthorIdAsync(Guid author_id) {

            var books = await _bookRepository.GetBooksByAuthor(author_id);

            var BookReponse = new BookResponseDTO
            {
                Book = null,
                Books = books
            };

            if (books == null)
            {

                BookReponse.Success = false;
                BookReponse.Message = "Something went wrong, check if the author exist";
                BookReponse.Status = HttpStatusCode.BadRequest.ToString();

                return BadRequest(BookReponse);

            }

            BookReponse.Success = true;
            BookReponse.Message = "All books in this genre";
            BookReponse.Status = HttpStatusCode.OK.ToString();

            return Ok(BookReponse);
        }

        [HttpGet]
        [Route("search")]
        [Authorize]
        public async Task<IActionResult> SearchAsync([FromQuery] string query)
        {
                
            var searchedBooks = await _bookRepository.SearchBooks(query);

            return Ok(searchedBooks);

        }


    }
}
