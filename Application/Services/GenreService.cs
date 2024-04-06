using Application.Common.Exceptions;
using Application.Common.Validators;
using Application.DTOs.GenreDTOs;
using Application.Interfaces;
using Data.Interfaces;
using Domain.Entities;
using FluentValidation;
using System.Net;

namespace Application.Services;

public class GenreService(IUnitOfWork unitOfWork,
                          IValidator<Genre> validator)
    : IGenreService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IValidator<Genre> _validator = validator;

    public async Task CreateAsync(AddGenreDto dto)
    {
        var genre = await _unitOfWork.Genre.GetByNameAsync(dto.Name);
        if (genre != null)
        {
            throw new StatusCodeException(HttpStatusCode.AlreadyReported, "Janr already exists");
        }

        await _unitOfWork.Genre.CreateAsync(dto);
    }

    public async Task DeleteAsync(int id)
    {
        var genre = await _unitOfWork.Genre.GetByIdAsync(id);
        if (genre is null)
            throw new StatusCodeException(HttpStatusCode.NotFound, "Jant not found");

        await _unitOfWork.Genre.DeleteAsync(genre);
    }

    public async Task<List<GenreDto>> GetAllAsync()
    {
        var genres = await _unitOfWork.Genre.GetAllAsync();
        return genres.Select(x => (GenreDto)x).ToList();
    }

    public async Task<GenreDto?> GetByIdAsync(int id)
    {
        var genre = await _unitOfWork.Genre.GetByIdAsync(id);
        if (genre is null)
            throw new StatusCodeException(HttpStatusCode.NotFound, "Genre not found");

        return (GenreDto?)genre;
    }

    public async Task UpdateAsync(GenreDto dto)
    {
        var genre = await _unitOfWork.Genre.GetByIdAsync(dto.Id);
        if (genre is null)
            throw new StatusCodeException(HttpStatusCode.NotFound, "Genre not found");

        var result = await _validator.ValidateAsync(dto);
        if (!result.IsValid)
            throw new ValidatorException(result.GetErrorMessages());

        await _unitOfWork.Genre.UpdateAsync((Genre)dto);
    }
}
