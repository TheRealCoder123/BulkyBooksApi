namespace BulkyBookAPI.Domain.DTOs.WishlistDTOs
{
    public class AddWishlistDTO
    {
        public Guid BookId { get; set; }
        public Guid UserId { get; set; }
    }
}
