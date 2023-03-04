using BulkyBookAPI.Domain.Entities;

namespace BulkyBookAPI.Domain.DTOs.WishlistDTOs
{
    public class WishlistDTO
    {
        public Guid WishlistId { get; set; }
        public Book? Book { get; set; }
        public User? User { get; set; }
        public DateTime Date { get; set; } = DateTime.UtcNow;
    }
}
