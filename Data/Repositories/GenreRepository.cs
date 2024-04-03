using Data.DbContexts;
using Data.Interfaces;
using Domain.Entities;

namespace Data.Repositories;

public class GenreRepository(AppDbContext dbContext) : GenericRepository<Genre>(dbContext), IGenreRepository
{
}
