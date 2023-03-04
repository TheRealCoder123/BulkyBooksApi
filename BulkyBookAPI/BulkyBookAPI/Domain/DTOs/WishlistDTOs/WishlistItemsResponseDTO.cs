using BulkyBookAPI.Domain.Entities;

namespace BulkyBookAPI.Domain.DTOs.WishlistDTOs
{
    public class WishlistItemsResponseDTO
    {
        public Guid WishlistId { get; set; }
        public Book? Book { get; set; }
        public DateTime Date { get; set; } = DateTime.UtcNow;
    }
}
