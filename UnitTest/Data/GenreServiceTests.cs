using Application.Common.Exceptions;
using Application.DTOs.GenreDTOs;
using Application.Interfaces;
using Application.Services;
using Data.Interfaces;
using Domain.Entities;
using FluentValidation;
using Moq;
using System.Net;

namespace UnitTest.Data;

public class GenreServiceTests
{
    private Mock<IUnitOfWork> mockUnitOfWork = new();
    private Mock<IValidator<Genre>> mockValidator = new();
    private IUnitOfWork unitOfWork;
    private IValidator<Genre> validator;
    private IGenreService service;

    [SetUp]
    public void Setup()
    {
        unitOfWork = mockUnitOfWork.Object;
        validator = mockValidator.Object;

        service = new GenreService(unitOfWork, validator);
    }

    [Test]
    public async Task AddGenreAsync_WhenGenreAlreadyExists_ThrowsStatusCodeException()
    {
        var dto = new AddGenreDto() { Name = "Test1" };
        mockUnitOfWork.Setup(x => x.Genre.GetByNameAsync(dto.Name)).ReturnsAsync(new Genre());

        var exception = Assert.ThrowsAsync<StatusCodeException>(() => service.CreateAsync(dto));

        Assert.That(exception.StatusCode, Is.EqualTo(HttpStatusCode.AlreadyReported));
        Assert.That(exception.Message, Is.EqualTo($"{dto.Name}"));
    }

}
