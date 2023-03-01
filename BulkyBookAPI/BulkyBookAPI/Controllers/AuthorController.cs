using BulkyBookAPI.Domain.DTOs.AuthorDTOs;
using BulkyBookAPI.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BulkyBookAPI.Controllers
{
    [ApiController]
    [Route("authors")]
    public class AuthorController : Controller
    {

        private readonly IAuthorRepository _authorRepository;

        public AuthorController(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAuthorsAsync() {

            var authors = await _authorRepository.GetAuthorsAsync();
            return Ok(authors);

        }


        [HttpGet]
        [Route("{author_id}")]
        [Authorize]
        public async Task<IActionResult> GetAuthorByIdAsync(Guid author_id) {

            var author = await _authorRepository.GetAuthorByIdAsync(author_id);

            var authorResponse = new AuthorResponseDTO
            {
                Author = author,
            };

            if (author == null) {

                authorResponse.Message = "This author does not exist";
                authorResponse.Success = false;
                authorResponse.Status = HttpStatusCode.BadRequest.ToString();

                return BadRequest(authorResponse);

            }

            authorResponse.Message = "Author request";
            authorResponse.Success = true;
            authorResponse.Status = HttpStatusCode.OK.ToString();

            return Ok(authorResponse);
        }

        [HttpPost]
        [Route("add")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddNewAuthor([FromBody] AddAuthorDTO addAuthorDTO) {

            var newAuthor = await _authorRepository.AddNewAuthorAsync(addAuthorDTO);

            return Ok(newAuthor);
        
        }


        [HttpGet]
        [Route("search")]
        [Authorize]
        public async Task<IActionResult> SearchAuthorsAsync([FromQuery] string query) { 
        
            var searchResult = await _authorRepository.SearchAuthorAsync(query);
            return Ok(searchResult);

        }


    }
}
