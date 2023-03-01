using BulkyBookAPI.Domain.DTOs.GenreDTOs;
using BulkyBookAPI.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BulkyBookAPI.Controllers
{
    [ApiController]
    [Route("genre")]
    public class GenreController : Controller
    {

        private readonly IGenreRepository _genreRepository;

        public GenreController(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }


        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetGenresAsync() { 
        
            var genres = await _genreRepository.GetAllGenresAsync();
            return Ok(genres);

        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddNewGenreAsync([FromBody] AddGenreDTO addGenreDTO) { 

            var newGenre = await _genreRepository.AddNewGenreAsync(addGenreDTO);

            var genreResponse = new GenreResponseDTO {
                Genre = newGenre,
            };

            if (newGenre != null) {


                genreResponse.Message = "Genre Successfully created";
                genreResponse.Status = HttpStatusCode.OK.ToString();

                return Ok(newGenre);
            
            }

            genreResponse.Message = "Something went wrong adding the new genre, try again";
            genreResponse.Status = HttpStatusCode.BadRequest.ToString();

            return BadRequest(genreResponse);

        }


    }
}
