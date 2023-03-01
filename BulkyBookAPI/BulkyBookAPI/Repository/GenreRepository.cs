using BulkyBookAPI.Data;
using BulkyBookAPI.Domain.DTOs.GenreDTOs;
using BulkyBookAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BulkyBookAPI.Repository
{
    public class GenreRepository : IGenreRepository
    {
        private readonly BulkyDbContext bulkyDbContext;

        public GenreRepository(BulkyDbContext bulkyDbContext)
        {
            this.bulkyDbContext = bulkyDbContext;
        }

        public async Task<GenreDTO> AddNewGenreAsync(AddGenreDTO addGenreDTO)
        {

            var genre = new Genre {
                GenreId = Guid.NewGuid(),
                Name = addGenreDTO.Name,
                Description = addGenreDTO.Description,
                GenreImg = addGenreDTO.GenreImg,
            };

            var addedGenre = await bulkyDbContext.Genre.AddAsync(genre);
            await bulkyDbContext.SaveChangesAsync();
            
            return new GenreDTO
            {
                GenreId = genre.GenreId,
                Description = genre.Description,
                Name = genre.Name,
                GenreImg = genre.GenreImg,
            };


        }

        public async Task<IEnumerable<GenreDTO>> GetAllGenresAsync()
        {

            var genres = await bulkyDbContext.Genre.ToListAsync();

            return genres.Select(genre =>
            {
                return new GenreDTO
                {
                    GenreId = genre.GenreId,
                    Description = genre.Description,
                    Name = genre.Name,
                    GenreImg = genre.GenreImg,
                };
            });


        }
    }
}
