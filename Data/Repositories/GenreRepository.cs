using Data.DbContexts;
using Data.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

public class GenreRepository(AppDbContext dbContext) : GenericRepository<Genre>(dbContext), IGenreRepository
{
    public async Task<Genre?> GetByNameAsync(string name)
     => await _dbContext.Genres.FirstOrDefaultAsync(x => x.Name == name);
}
