using Data.DbContexts;
using Data.Interfaces;
using Domain.Entities;

namespace Data.Repositories;

public class MovieRepository(AppDbContext dbContext) : GenericRepository<Movie>(dbContext), IMovieRepository
{
}
