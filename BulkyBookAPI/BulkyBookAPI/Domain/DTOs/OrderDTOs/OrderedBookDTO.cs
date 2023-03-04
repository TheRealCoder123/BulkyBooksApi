namespace BulkyBookAPI.Domain.DTOs.OrderDTOs
{
    public class OrderedBookDTO
    {
        public Guid OrderedBookId { get; set; }
        public Guid OrderId { get; set; }
        public Guid BookId { get; set; }
    }
}
