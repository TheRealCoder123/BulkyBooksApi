using BulkyBookAPI.Domain.DTOs;
using BulkyBookAPI.Domain.DTOs.BookDTOs;
using BulkyBookAPI.Domain.DTOs.CreditCardDTOs;
using BulkyBookAPI.Domain.DTOs.UserDTOs;
using BulkyBookAPI.Domain.Entities;
using System.Runtime.CompilerServices;

namespace BulkyBookAPI.Utils
{
    public static class Extensions
    {

        public static UserResponseDTO ToUserDTO(this User user) { 

            return new UserResponseDTO
            {
                UserId = user.UserId,
                Name = user.Name,
                Lastname = user.Lastname,
                Address = user.Address,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Role = user.Role,
            };

        }


        public static Book ToBook(this BookDTO book)
        {

            return new Book
            {
                BookId = book.BookId,
                Title = book.Title,
                CreatedDate = book.CreatedDate,
                Pages = book.Pages,
                Price = book.Price,
                Description = book.Description,
                PublishedDate = book.PublishedDate,
                Cover = book.Cover,
                ISBN = book.ISBN,
                Publisher = book.Publisher,
                Quantity = book.Quantity,
                Genre = book.Genre,
                Author = book.Author
            };

        }
     
    }
}
