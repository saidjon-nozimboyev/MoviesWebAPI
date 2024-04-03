using Application.DTOs.UserDTOs;

namespace Application.Interfaces;

public interface IUserService
{
    Task<UserDto> GetByIdAsync(int id);
    Task<List<UserDto>> GetAllAsync();
    Task UpdateAsync(UpdateUserDto dto);
    Task DeleteAsync(int id);
}
