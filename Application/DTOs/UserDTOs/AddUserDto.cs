using Data.Enums;
using Domain.Entities;

namespace Application.DTOs.UserDTOs;

public class AddUserDto
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public Gender Gender { get; set; }
    public string Password { get; set; } = string.Empty;


    public static implicit operator User(AddUserDto dto)
    {
        return new User
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Email = dto.Email,
            Gender = dto.Gender,
            Password = dto.Password
        };
    }
}
