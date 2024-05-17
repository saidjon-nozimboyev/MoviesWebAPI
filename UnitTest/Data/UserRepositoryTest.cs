using Data.DbContexts;
using Data.Enums;
using Data.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using UnitTest.Helpers;

namespace UnitTest.Data;

public class UserRepositoryTest
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

    public async Task AddAsync(string name)
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

    [TearDown]
    public void Teardown() 
    {
        dbContext.Database.EnsureDeleted();
        dbContext.Dispose();
    }
}
