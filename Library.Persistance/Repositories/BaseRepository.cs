using Library.Application.Repositories;
using Library.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Repositories;

public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
{
    
    private readonly LibraryDbContext _dbContext;

    public BaseRepository(LibraryDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public void Create(T entity)
    {
        _dbContext.AddAsync(entity);
    }

    public void Update(T entity)
    {
        _dbContext.Update(entity);
    }

    public void Delete(T entity)
    {
        _dbContext.Update(entity);
    }

    public async Task<T?> GetById(Guid id)
    {
        return await _dbContext.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<IEnumerable<T>?> GetAll()
    {
        return await _dbContext.Set<T>().ToListAsync();
    }
}