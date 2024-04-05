using Application.DTOs.GenreDTOs;
using Application.Interfaces;
using Data.Interfaces;
using Domain.Entities;
using FluentValidation;

namespace Application.Services;

public class GenreService(IUnitOfWork unitOfWork,
                          IValidator<Genre> validator) 
    : IGenreService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IValidator<Genre> _validator = validator;

    public Task CreateAsync(AddGenreDto dto)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<GenreDto>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<GenreDto?> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(GenreDto dto)
    {
        throw new NotImplementedException();
    }
}
