using Library.Application.Repositories.Base;
using Library.Domain.Common;
using Library.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Repositories.Base;

public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
{
    protected readonly LibraryDbContext DbContext;

    protected BaseRepository(LibraryDbContext dbContext) => DbContext = dbContext;

    public async Task Create(T entity) => await DbContext.AddAsync(entity);

    public void Update(T entity) => DbContext.Update(entity);

    public void Delete(T entity) => DbContext.Remove(entity);

    public Task<T?> GetById(Guid id, CancellationToken cancellationToken) =>
        DbContext.Set<T>().FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

    public Task<List<T>> GetAll(CancellationToken cancellationToken) => DbContext.Set<T>().ToListAsync(cancellationToken);
}