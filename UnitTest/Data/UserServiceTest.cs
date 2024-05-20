using Data.DbContexts;
using Data.Enums;
using Data.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using UnitTest.Helpers;

namespace UnitTest.Data;

public class UserServiceTest
{
    AppDbContext dbContext;
    IUnitOfWork unitOfWork;

    [SetUp]
    public void Setup()
    {
        dbContext = DbContextHelper.GetDbContext();
        unitOfWork = DbContextHelper.GetUnitOfWork();
    }

    [Test]
    [TestCase("Test1")]
    [TestCase("Test2")]
    [TestCase("Test3")]
    [TestCase("Test4")]
    [TestCase("Test5")]
    [TestCase("Test6")]
    [TestCase("Test7")]

    public async Task AddUserAsync(string name)
    {
        var user = new User()
        {
            Id = 1,
            FirstName = name,
            LastName = name,
            CreatedAt = DateTime.Now,
            Email = "usertes@gmail.com",
            Gender = Gender.Male,
            Password = "HelloWorld",
            Role = Role.User
        };

        await unitOfWork.User.CreateAsync(user);

        var result = await dbContext.Users.FirstOrDefaultAsync(x => x.FirstName == name);

        Assert.That(user.FirstName, Is.EqualTo(result!.FirstName));
    }

    [Test]
    [TestCase("Test1")]
    [TestCase("Test2")]
    [TestCase("Test3")]
    [TestCase("Test4")]
    [TestCase("Test5")]
    [TestCase("Test6")]
    [TestCase("Test7")]

    public async Task AddGenreAsync(string name)
    {
        var genre = new Genre()
        {
            CreatedAt = DateTime.Now,
            Description = "Description",
            Name = name,
        };

        await unitOfWork.Genre.CreateAsync(genre);

        var result = await dbContext.Genres.FirstOrDefaultAsync(x => x.Name == name);

        Assert.That(genre.Name, Is.EqualTo(result!.Name));
    }

    [Test]
    [TestCase("Test1")]
    [TestCase("Test2")]
    [TestCase("Test3")]
    [TestCase("Test4")]
    [TestCase("Test5")]
    [TestCase("Test6")]
    [TestCase("Test7")]

    public async Task AddMovieAsync(string name)
    {
        var movie = new Movie()
        {
            Company = name,
        };

        await unitOfWork.Movie.CreateAsync(movie);

        var result = await dbContext.Movies.FirstOrDefaultAsync(x => x.Company == name);

        Assert.That(movie.Company, Is.EqualTo(result!.Company));
    }

    [TearDown]
    public void Teardown() 
    {
        dbContext.Database.EnsureDeleted();
        dbContext.Dispose();
    }
}