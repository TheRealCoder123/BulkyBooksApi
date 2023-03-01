using BulkyBookAPI.Domain.Entities;

namespace BulkyBookAPI.Repository
{
    public interface ITokenHandler
    {
        Task<string> CreateTokenAsync(User user);
    }
}
