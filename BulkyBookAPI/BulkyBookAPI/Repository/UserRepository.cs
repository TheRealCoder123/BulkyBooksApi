using BulkyBookAPI.Data;
using BulkyBookAPI.Domain.DTOs;
using BulkyBookAPI.Domain.DTOs.UserDTOs;
using BulkyBookAPI.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace BulkyBookAPI.Repository
{
    public class UserRepository : IUserRepository
    {

        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly BulkyDbContext _bulkyDbContext;
        private readonly ITokenHandler _tokenHandler;

        public UserRepository(IPasswordHasher<User> passwordHasher, BulkyDbContext bulkyDbContext, ITokenHandler tokenHandler)
        {
            _passwordHasher = passwordHasher;
            _bulkyDbContext = bulkyDbContext;
            _tokenHandler = tokenHandler;   
        }

        public async Task<LoginResponseDTO> LoginUser(LoginUserDTO loginDTO)
        {

            var user = await _bulkyDbContext.User.FirstOrDefaultAsync(x => x.Email == loginDTO.Email);

            if (user == null) {
                return new LoginResponseDTO
                {
                    Message = "User with those credentials does not exist",
                    Status = HttpStatusCode.NotFound,
                    Success = false,
                    Token = "",
                    User = null
                };
            }

            var isPasswordMatching = _passwordHasher.VerifyHashedPassword(user, user.Password, loginDTO.Password);

            if (isPasswordMatching == PasswordVerificationResult.Success && user != null)
            {

                var userResponseDTO = new UserResponseDTO
                {
                    UserId = user.UserId,
                    Name = user.Name,
                    Lastname = user.Lastname,
                    Address = user.Address,
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber,
                    Role = user.Role

                };

                var token = await _tokenHandler.CreateTokenAsync(user);

                return new LoginResponseDTO
                {
                    Message = "Successfully logged in",
                    Status = HttpStatusCode.OK,
                    Success = true,
                    Token = token,
                    User = userResponseDTO
                };

            }

            return new LoginResponseDTO
            {
                Message = "Your email or password does not match to any into our database",
                Status = HttpStatusCode.BadRequest,
                Success = false,
                Token = "",
                User = null
            };




        }

        public async Task<RegisterResponseDTO> RegisterUser(RegisterUserDTO registerDTO)
        {

            var registerReponse = new RegisterResponseDTO
            {
                Message = "Sucessfully Created Account",
                Success = true,
                Status = HttpStatusCode.OK
            };

            var sameEmailUser = await _bulkyDbContext.User.FirstOrDefaultAsync(x => x.Email == registerDTO.Email);

            if (sameEmailUser != null) { 

                registerReponse.Success = false;
                registerReponse.Message = "A user with that email already exists into out database";
                registerReponse.Status = HttpStatusCode.Conflict;
                return registerReponse;
            
            }

           

            var user = new User {
                UserId = Guid.NewGuid(),
                Name = registerDTO.Name,
                Lastname = registerDTO.Lastname,
                Address = "",
                Email = registerDTO.Email,
                PhoneNumber = "",
                Role = new UserRoles().BUYER,
            };

            var hashedPassword = _passwordHasher.HashPassword(user,registerDTO.Password);
            user.Password = hashedPassword;

            await _bulkyDbContext.User.AddAsync(user);
            await _bulkyDbContext.SaveChangesAsync();

            var success = _bulkyDbContext.User.Contains(user);

            if (success) {
                return registerReponse;
            }

            registerReponse.Message = "Something went wrong creating your account, please try again";
            registerReponse.Status = HttpStatusCode.BadRequest;
            registerReponse.Success = false;

            return registerReponse;
           
            
        }
    }
}
