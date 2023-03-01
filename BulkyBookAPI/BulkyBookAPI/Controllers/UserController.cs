using BulkyBookAPI.Domain.DTOs.UserDTOs;
using BulkyBookAPI.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BulkyBookAPI.Controllers
{
    [ApiController]
    [Route("auth")]
    public class UserController : Controller
    {

        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> RegisterUserAsync([FromBody] RegisterUserDTO registerUserDTO) {

            var registerResult = await _userRepository.RegisterUser(registerUserDTO);

            switch (registerResult.Status) {
                case HttpStatusCode.OK:
                    return Ok(registerResult);
                case HttpStatusCode.Conflict:
                    return Conflict(registerResult);
                case HttpStatusCode.BadRequest:
                    return BadRequest(registerResult);
                default: return BadRequest(registerResult);
            }

        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> LoginUserAsync([FromBody] LoginUserDTO loginUserDTO) { 

            var loginResult = await _userRepository.LoginUser(loginUserDTO);
            switch (loginResult.Status)
            {
                case HttpStatusCode.OK:
                    return Ok(loginResult);
                case HttpStatusCode.NotFound:
                    return Conflict(loginResult);
                case HttpStatusCode.BadRequest:
                    return BadRequest(loginResult);
                default: return BadRequest(loginResult);
            }

        }


    }
}
