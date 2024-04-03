using Application.DTOs.UserDTOs;

namespace Application.Interfaces;

public interface IAccountService
{
    Task<bool> RegistrAsync(AddUserDto dto);
    Task<string> LoginAsync(LoginDto login);
}
