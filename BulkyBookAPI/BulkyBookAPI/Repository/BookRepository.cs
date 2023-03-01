using BulkyBookAPI.Data;
using BulkyBookAPI.Domain.DTOs.BookDTOs;
using BulkyBookAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BulkyBookAPI.Repository
{
    public class BookRepository : IBookRepository
    {

        private readonly BulkyDbContext _dbContext;

        public BookRepository(BulkyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<BookDTO?> AddNewBookAsync(AddBookDTO addBookDTO)
        {

            var author = await _dbContext.Author.FirstOrDefaultAsync(x => x.AuthorId == addBookDTO.AuthorId);
            var genre = await _dbContext.Genre.FirstOrDefaultAsync(x => x.GenreId == addBookDTO.GenreId);


            if (author == null || genre == null) {
                return null;
            }

            var book = new Book
            {
                BookId = Guid.NewGuid(),
                Title = addBookDTO.Title,
                CreatedDate = addBookDTO.CreatedDate,
                Pages = addBookDTO.Pages,
                Price = addBookDTO.Price,
                Description = addBookDTO.Description,
                PublishedDate = addBookDTO.PublishedDate,
                Cover = addBookDTO.Cover,
                ISBN = addBookDTO.ISBN,
                Publisher = addBookDTO.Publisher,
                Quantity = addBookDTO.Quantity,
                Genre = genre,
                Author = author
            };

            await _dbContext.Book.AddAsync(book);
            await _dbContext.SaveChangesAsync();

            return new BookDTO
            {
                BookId = book.BookId,
                Title = book.Title,
                CreatedDate = book.CreatedDate,
                Pages = book.Pages,
                Price = book.Price,
                Description = book.Description,
                PublishedDate = book.PublishedDate,
                Cover = book.Cover,
                ISBN = book.ISBN,
                Publisher = book.Publisher,
                Quantity = book.Quantity,
                Genre = book.Genre,
                Author = book.Author
            };

        }

        public async Task<IEnumerable<BookDTO>> GetAllBooksAsync()
        {
            var books = await _dbContext.Book.Include(x=>x.Author).Include(x=>x.Genre).ToListAsync();

           

            return books.Select(book =>
            {
                return new BookDTO
                {
                    BookId = book.BookId,
                    Title = book.Title,
                    CreatedDate = book.CreatedDate,
                    Pages = book.Pages,
                    Price = book.Price,
                    Description = book.Description,
                    PublishedDate = book.PublishedDate,
                    Cover = book.Cover,
                    ISBN = book.ISBN,
                    Publisher = book.Publisher,
                    Quantity = book.Quantity,
                    Genre = book.Genre,
                    Author = book.Author
                };

            });


        }

        public async Task<IEnumerable<BookDTO>?> GetBooksByGenre(Guid GenreId)
        {

            var genre = await _dbContext.Genre.FirstOrDefaultAsync(x => x.GenreId == GenreId);


            if (genre == null)
            {
                return null;
            }


            var books = await _dbContext.Book.Where(x => x.Genre.GenreId == GenreId)
                .Include(x=>x.Author).Include(x=>x.Genre).ToListAsync();

            return books.Select(book =>
            {
                return new BookDTO
                {
                    BookId = book.BookId,
                    Title = book.Title,
                    CreatedDate = book.CreatedDate,
                    Pages = book.Pages,
                    Price = book.Price,
                    Description = book.Description,
                    PublishedDate = book.PublishedDate,
                    Cover = book.Cover,
                    ISBN = book.ISBN,
                    Publisher = book.Publisher,
                    Quantity = book.Quantity,
                    Genre = book.Genre,
                    Author = book.Author
                };

            });
        }


        public async Task<IEnumerable<BookDTO>?> GetBooksByAuthor(Guid AuthorId) {


            var author = await _dbContext.Author.FirstOrDefaultAsync(x => x.AuthorId == AuthorId);


            if (author == null)
            {
                return null;
            }


            var books = await _dbContext.Book.Where(x => x.Author.AuthorId == AuthorId)
                .Include(x => x.Author).Include(x => x.Genre).ToListAsync();

            return books.Select(book =>
            {
                return new BookDTO
                {
                    BookId = book.BookId,
                    Title = book.Title,
                    CreatedDate = book.CreatedDate,
                    Pages = book.Pages,
                    Price = book.Price,
                    Description = book.Description,
                    PublishedDate = book.PublishedDate,
                    Cover = book.Cover,
                    ISBN = book.ISBN,
                    Publisher = book.Publisher,
                    Quantity = book.Quantity,
                    Genre = book.Genre,
                    Author = book.Author
                };


            });

        }

        public async Task<IEnumerable<BookDTO>?> SearchBooks(string query)
        {
            var books = await _dbContext.Book.Include(x => x.Author).Include(x => x.Genre).ToListAsync();

            var booksDTO = new List<BookDTO>();

            books.ForEach(book =>
            {

                if (book.Title.ToLower().Contains(query.ToLower()))
                {
                    var searchedBookDTO = new BookDTO
                    {
                        BookId = book.BookId,
                        Title = book.Title,
                        CreatedDate = book.CreatedDate,
                        Pages = book.Pages,
                        Price = book.Price,
                        Description = book.Description,
                        PublishedDate = book.PublishedDate,
                        Cover = book.Cover,
                        ISBN = book.ISBN,
                        Publisher = book.Publisher,
                        Quantity = book.Quantity,
                        Genre = book.Genre,
                        Author = book.Author
                    };

                    booksDTO.Add(searchedBookDTO);
                }

            });

            return booksDTO;

        }
    }
}
