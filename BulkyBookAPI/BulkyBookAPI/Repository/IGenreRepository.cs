using BulkyBookAPI.Domain.DTOs.GenreDTOs;

namespace BulkyBookAPI.Repository
{
    public interface IGenreRepository
    {

        Task<IEnumerable<GenreDTO>> GetAllGenresAsync();
        Task<GenreDTO> AddNewGenreAsync(AddGenreDTO addGenreDTO);

    }
}
