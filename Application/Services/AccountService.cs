using Application.Common.Exceptions;
using Application.Common.Security;
using Application.DTOs.UserDTOs;
using Application.Interfaces;
using Data.Interfaces;
using Domain.Entities;
using System.Net;

namespace Application.Services;

public class AccountService(IUnitOfWork unitOfWork, IAuthManager authManager)
    : IAccountService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    public IAuthManager _auth = authManager;

    public async Task<string> LoginAsync(LoginDto login)
    {
        var user = await _unitOfWork.User.GetByEmailAsync(login.Email);
        if (user == null)
        {
            throw new StatusCodeException(HttpStatusCode.NotFound, "User with this email not found!");
        }

        if (!user.Password.Equals(PasswordHasher.GetHash(login.Password)))
            throw new StatusCodeException(HttpStatusCode.Conflict, "Password is incorrect!");

        return _auth.GeneratedToken(user);
    }

    public async Task<bool> RegistrAsync(AddUserDto dto)
    {
        var user = await _unitOfWork.User.GetByEmailAsync(dto.Email);

        if (user is not null)
        {
            throw new StatusCodeException(HttpStatusCode.AlreadyReported, "User with this email already exists");
        }
        var entity = (User)dto;
        entity.Password = PasswordHasher.GetHash(entity.Password);

        await _unitOfWork.User.CreateAsync(entity);

        return true;
    }
}
