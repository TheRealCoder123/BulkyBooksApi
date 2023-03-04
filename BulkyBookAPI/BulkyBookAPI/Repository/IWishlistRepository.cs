using BulkyBookAPI.Domain.DTOs.WishlistDTOs;

namespace BulkyBookAPI.Repository
{
    public interface IWishlistRepository
    {

        Task<WishlistResponsedDTO> AddToWishlistAsync(AddWishlistDTO addWishlistDTO);
        Task<WishlistResponsedDTO> RemoveFromWishlistAsync(Guid wishlistId);
        Task<IEnumerable<WishlistItemsResponseDTO>> GetWishlistItemsAsync(Guid userId);

    }
}
