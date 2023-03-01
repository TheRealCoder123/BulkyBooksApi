using BulkyBookAPI.Domain.DTOs.AuthorDTOs;
using BulkyBookAPI.Domain.Entities;

namespace BulkyBookAPI.Repository
{
    public interface IAuthorRepository
    {

        Task<AuthorDTO> AddNewAuthorAsync(AddAuthorDTO addAuthorDTO);
        Task<IEnumerable<AuthorDTO>> GetAuthorsAsync();
        Task<AuthorDTO> GetAuthorByIdAsync(Guid authorId);
        Task<IEnumerable<AuthorDTO>?> SearchAuthorAsync(string query);

    }
}
