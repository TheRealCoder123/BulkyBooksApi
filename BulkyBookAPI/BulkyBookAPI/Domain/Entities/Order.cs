namespace BulkyBookAPI.Domain.Entities
{
    public class Order
    {

        public Guid OrderId { get; set; }
        public string TotalPrice { get; set; } = string.Empty;
        public DateTime Date { get; set; } = DateTime.UtcNow;
        public string ShippingStatus { get; set; } = string.Empty;
        public string PaymentStatus { get; set; } = string.Empty;
        public int OrderItemsQuantity { get; set; } = 0;
        public string Address { get; set; } = string.Empty;


        public CreditCards? CreditCard { get; set; } 
        public User? User { get; set; } 
        public IEnumerable<OrderedBooks>? Books { get; set; } 


    }
}
