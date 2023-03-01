namespace BulkyBookAPI.Domain.DTOs.BookDTOs
{
    public class AddBookDTO
    {

        public string Title { get; set; } = string.Empty;
        public string CreatedDate { get; set; }
        public string Price { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string? PublishedDate { get; set; }
        public string Cover { get; set; } = string.Empty;
        public int? Pages { get; set; }
        public string? ISBN { get; set; }
        public string? Publisher { get; set; }
        public int? Quantity { get; set; }
        public Guid AuthorId { get; set; }
        public Guid GenreId { get; set; }


    }
}
