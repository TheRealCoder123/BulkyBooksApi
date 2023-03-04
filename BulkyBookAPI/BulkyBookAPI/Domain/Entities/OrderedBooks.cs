using System.ComponentModel.DataAnnotations;

namespace BulkyBookAPI.Domain.Entities
{
    public class OrderedBooks
    {
        

        [Key]
        public Guid OrderedBookId { get; set; }
        public Guid OrderId { get; set; }
        public Guid BookId { get; set; }

    }
}
