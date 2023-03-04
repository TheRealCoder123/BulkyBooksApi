using BulkyBookAPI.Data;
using BulkyBookAPI.Domain.DTOs.WishlistDTOs;
using BulkyBookAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace BulkyBookAPI.Repository
{
    public class WishlistRepository : IWishlistRepository
    {

        private readonly BulkyDbContext _dbContext;

        public WishlistRepository(BulkyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<WishlistResponsedDTO> AddToWishlistAsync(AddWishlistDTO addWishlistDTO)
        {
            var responseDTO = new WishlistResponsedDTO();

            var user = await _dbContext.User.FirstOrDefaultAsync(x => x.UserId == addWishlistDTO.UserId);
            var book = await _dbContext.Book.FirstOrDefaultAsync(x => x.BookId == addWishlistDTO.BookId);

            var isAddedAlreadyToWishlist = await _dbContext.Wishlist
                .FirstOrDefaultAsync(x => x.Book.BookId == addWishlistDTO.BookId);

            if (isAddedAlreadyToWishlist != null) {

                responseDTO.Sucess = false;
                responseDTO.Message = "Already added to wishlist";
                responseDTO.Status = HttpStatusCode.Conflict;

                return responseDTO;

            }




            if (user == null) {

                responseDTO.Sucess = false;
                responseDTO.Message = "This user does not exist in to our database";
                responseDTO.Status = HttpStatusCode.NotFound;

                return responseDTO;
            
            }

            if (book == null) {
                responseDTO.Sucess = false;
                responseDTO.Message = "This book does not exist into our database";
                responseDTO.Status = HttpStatusCode.NotFound;

                return responseDTO;
            }

            var wishlistEntity = new Wishlist
            {
                WishlistId = Guid.NewGuid(),
                Book = book,
                User = user,
                Date = DateTime.UtcNow
            };

            await _dbContext.Wishlist.AddAsync(wishlistEntity);
            await _dbContext.SaveChangesAsync();

            var isAdded = _dbContext.Wishlist.Contains(wishlistEntity);

            if (isAdded) {

                responseDTO.Sucess = true;
                responseDTO.Message = "Added to wishlist";
                responseDTO.Status = HttpStatusCode.OK;

                return responseDTO;

            }

            responseDTO.Sucess = false;
            responseDTO.Message = "Something went wrong adding to wishlist";
            responseDTO.Status = HttpStatusCode.BadRequest;

            return responseDTO;

        }

        public async Task<IEnumerable<WishlistItemsResponseDTO>?> GetWishlistItemsAsync(Guid userId)
        {
            var wishlistItems = await _dbContext.Wishlist.Include(x=>x.Book).Where(x => x.User.UserId == userId).ToListAsync();

            var responseDTO = wishlistItems.Select(item =>
            {
                return new WishlistItemsResponseDTO
                {
                    WishlistId= item.WishlistId,
                    Book = item.Book,
                    Date = item.Date,

                };

            });

            return responseDTO;
        }

        public async Task<WishlistResponsedDTO> RemoveFromWishlistAsync(Guid wishlistId)
        {

            var responseDTO = new WishlistResponsedDTO();


            var wishlist = await _dbContext.Wishlist.FirstOrDefaultAsync(x => x.WishlistId == wishlistId);

            if (wishlist == null) {
                responseDTO.Sucess = false;
                responseDTO.Message = "This wishlist book does not exist";
                responseDTO.Status = HttpStatusCode.BadRequest;

                return responseDTO;
            }

            _dbContext.Wishlist.Remove(wishlist);
            await _dbContext.SaveChangesAsync();

            var isDeleted = _dbContext.Wishlist.Contains(wishlist);

            if (!isDeleted) {

                responseDTO.Sucess = true;
                responseDTO.Message = "Book successfully deleted";
                responseDTO.Status = HttpStatusCode.OK;

                return responseDTO;

            }

            responseDTO.Sucess = false;
            responseDTO.Message = "Something went wrong deleting the book from your wish list";
            responseDTO.Status = HttpStatusCode.BadRequest;

            return responseDTO;


        }
    }
}
