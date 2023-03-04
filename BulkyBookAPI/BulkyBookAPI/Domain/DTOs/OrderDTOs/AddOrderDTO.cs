using BulkyBookAPI.Domain.DTOs.BookDTOs;
using BulkyBookAPI.Domain.Entities;

namespace BulkyBookAPI.Domain.DTOs.OrderDTOs
{
    public class AddOrderDTO
    {
        public string TotalPrice { get; set; } = string.Empty;
        public DateTime Date { get; set; } = DateTime.UtcNow;
        public string ShippingStatus { get; set; } = string.Empty;
        public string PaymentStatus { get; set; } = string.Empty;
        public int OrderItemsQuantity { get; set; } = 0;
        public string Address { get; set; } = string.Empty;
        public Guid? CreditCardId { get; set; }
        public Guid? UserID { get; set; }
        public IEnumerable<Guid> BookIds { get; set; }
    }
}
