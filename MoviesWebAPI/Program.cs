using Application.Common.Validators;
using Application.Interfaces;
using Application.Services;
using Data.DbContexts;
using Data.Interfaces;
using Data.Repositories;
using Domain.Entities;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using MoviesWebAPI.Middlewares;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("LocalDB"));
    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});
// Unit of Work
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

// Services
builder.Services.AddTransient<IAccountService, AccountService>();
builder.Services.AddTransient<IAuthManager, AuthManager>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddScoped<IValidator<User>, UserValidator>();
builder.Services.AddScoped<IValidator<Genre>, GenreValidator>();
builder.Services.AddScoped<IValidator<Movie>, MovieValidator>();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.MapControllers();

app.UseMiddleware<ExceptionsHandler>();

app.Run();
