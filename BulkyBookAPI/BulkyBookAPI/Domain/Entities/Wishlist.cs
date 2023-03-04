namespace BulkyBookAPI.Domain.Entities
{
    public class Wishlist
    {

        public Guid WishlistId { get; set; }
        public Book? Book { get; set; }
        public User? User { get; set; }
        public DateTime Date { get; set; } = DateTime.UtcNow;

    }
}
