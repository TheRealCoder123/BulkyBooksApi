using BulkyBookAPI.Domain.DTOs.WishlistDTOs;
using BulkyBookAPI.Migrations;
using BulkyBookAPI.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BulkyBookAPI.Controllers
{
    [ApiController]
    [Route("wishlist")]
    public class WishlistController : Controller
    {
        private readonly IWishlistRepository _wishlistRepository;

        public WishlistController(IWishlistRepository wishlistRepository)
        {
            _wishlistRepository = wishlistRepository;
        }

        [HttpDelete]
        [Route("{wishlist_id}")]
        [Authorize]
        public async Task<IActionResult> DeleteBookFromWishlistAsync(Guid wishlist_id) {

            var deleteResult = await _wishlistRepository.RemoveFromWishlistAsync(wishlist_id);

            switch (deleteResult.Status)
            {
                case HttpStatusCode.OK:
                    return Ok(deleteResult);
                case HttpStatusCode.BadRequest:
                    return BadRequest(deleteResult);
                default: return BadRequest(deleteResult);
            }


        }

        [HttpGet]
        [Route("books/{user_id}")]
        [Authorize]
        public async Task<IActionResult> GetWishlistItemsAsync(Guid user_id) {

            var books = await _wishlistRepository.GetWishlistItemsAsync(user_id);

            return Ok(books);
        }

        [HttpPost]
        [Route("addBook")]
        [Authorize]
        public async Task<IActionResult> AddBookToWishlistAsync([FromBody] AddWishlistDTO addWishlistDTO) {

            var addResult = await _wishlistRepository.AddToWishlistAsync(addWishlistDTO);

            switch (addResult.Status)
            {
                case HttpStatusCode.OK:
                    return Ok(addResult);
                case HttpStatusCode.BadRequest:
                    return BadRequest(addResult);
                case HttpStatusCode.Conflict:
                    return BadRequest(addResult);
                case HttpStatusCode.NotFound:
                    return BadRequest(addResult);
                default: return BadRequest(addResult);
            }


        }


    }
}
