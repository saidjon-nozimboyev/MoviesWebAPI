using Data.DbContexts;
using Data.Interfaces;

namespace Data.Repositories;

public class UnitOfWork(AppDbContext dbContext) : IUnitOfWork
{
    private readonly AppDbContext appDbContext = dbContext;

    public IGenreRepository Genre => new GenreRepository(appDbContext);

    public IMovieRepository Movie => new MovieRepository(appDbContext);

    public IUserRepository User => new UserRepository(appDbContext);
}
