using BulkyBookAPI.Domain.DTOs.UserDTOs;

namespace BulkyBookAPI.Repository
{
    public interface IUserRepository
    {

        Task<RegisterResponseDTO> RegisterUser(RegisterUserDTO registerDTO);
        Task<LoginResponseDTO> LoginUser(LoginUserDTO loginDTO);


    }
}
