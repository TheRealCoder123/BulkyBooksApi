using BulkyBookAPI.Data;
using BulkyBookAPI.Domain.DTOs.AuthorDTOs;
using BulkyBookAPI.Domain.DTOs.BookDTOs;
using BulkyBookAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BulkyBookAPI.Repository
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly BulkyDbContext _dbcontext;

        public AuthorRepository(BulkyDbContext dbContext)
        {
            _dbcontext = dbContext;
        }

        public async Task<AuthorDTO> AddNewAuthorAsync(AddAuthorDTO addAuthorDTO)
        {

            var author = new Author
            {
                AuthorId = Guid.NewGuid(),
                Name = addAuthorDTO.Name,
                Lastname = addAuthorDTO.Lastname,
                MiddleName = addAuthorDTO.MiddleName,
                Biography = addAuthorDTO.Biography,
                Birthdate = addAuthorDTO.Birthdate,
                Nationality = addAuthorDTO.Nationality,
                Image = addAuthorDTO.Image
            };

            await _dbcontext.Author.AddAsync(author);
            await _dbcontext.SaveChangesAsync();

            return new AuthorDTO
            {
                AuthorId = author.AuthorId,
                Name = author.Name,
                Lastname = author.Lastname,
                MiddleName = author.MiddleName,
                Biography = author.Biography,
                Birthdate = author.Birthdate,
                Nationality = author.Nationality,
                Image = author.Image

            };

        }

        public async Task<AuthorDTO?> GetAuthorByIdAsync(Guid authorId)
        {
            var author = await _dbcontext.Author.FirstOrDefaultAsync(author => author.AuthorId == authorId);

            if (author == null) {
                return null;
            }

            return new AuthorDTO
            {
                AuthorId = author.AuthorId,
                Name = author.Name,
                Lastname = author.Lastname,
                MiddleName = author.MiddleName,
                Biography = author.Biography,
                Birthdate = author.Birthdate,
                Nationality = author.Nationality,
                Image = author.Image

            };
        }

        public async Task<IEnumerable<AuthorDTO>> GetAuthorsAsync()
        {
            var authors = await _dbcontext.Author.ToListAsync();

            var authorsDTO = authors.Select(author =>
            {
                return new AuthorDTO
                {
                    AuthorId = author.AuthorId,
                    Name = author.Name,
                    Lastname = author.Lastname,
                    MiddleName = author.MiddleName,
                    Biography = author.Biography,
                    Birthdate = author.Birthdate,
                    Nationality = author.Nationality,
                    Image = author.Image

                };
            });


            return authorsDTO;
        }

        public async Task<IEnumerable<AuthorDTO>?> SearchAuthorAsync(string query)
        {
            var authors = await _dbcontext.Author.ToListAsync();

            var authorsDTO = new List<AuthorDTO>();

            authors.ForEach(author =>
            {

                if (author.Name.ToLower().Contains(query.ToLower()))
                {
                    var searcherAuthor = new AuthorDTO
                    {
                        AuthorId = author.AuthorId,
                        Name = author.Name,
                        Lastname = author.Lastname,
                        MiddleName = author.MiddleName,
                        Biography = author.Biography,
                        Birthdate = author.Birthdate,
                        Nationality = author.Nationality,
                        Image = author.Image

                    };
                    authorsDTO.Add(searcherAuthor);
                }

            });

            return authorsDTO;

        }
    }
}
