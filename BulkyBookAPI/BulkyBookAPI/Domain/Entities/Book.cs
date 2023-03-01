using System.Data;

namespace BulkyBookAPI.Domain.Entities
{
    public class Book
    {

        public Guid BookId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string CreatedDate { get; set; } = string.Empty;
        public string Price { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string? PublishedDate { get; set; }
        public string Cover { get; set; } = string.Empty;
        public int? Pages { get; set; }
        public string? ISBN { get; set; }
        public string? Publisher { get; set; }
        public int? Quantity { get; set; } 
        public string Avilibatility { get; set; } = string.Empty;

        public Genre? Genre { get; set; }   
        public Author? Author { get; set; }


    }
}
