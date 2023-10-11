using Library.Application.Repositories;
using Library.Domain.Entities;
using Library.Infrastructure.Context;
using Library.Infrastructure.Repositories.Base;

namespace Library.Infrastructure.Repositories;

public class AuthorRepository : BaseRepository<Author>, IAuthorRepository   
{
    public AuthorRepository(LibraryDbContext dbContext) : base(dbContext)
    {
    }

    public Task<Author?> GetByName(string name, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}