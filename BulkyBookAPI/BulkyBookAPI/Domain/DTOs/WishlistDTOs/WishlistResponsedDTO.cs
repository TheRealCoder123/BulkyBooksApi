using System.Net;

namespace BulkyBookAPI.Domain.DTOs.WishlistDTOs
{
    public class WishlistResponsedDTO
    {
        public string Message { get; set; } = string.Empty;
        public bool Sucess { get; set; } 
        public HttpStatusCode Status { get; set; }
        public WishlistDTO? Wishlist { get; set; }
    }
}
