using Library.Application.Repositories;
using Library.Application.User.Commands;
using Library.Domain.Common;

using Library.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Repositories;

public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
{
	protected readonly LibraryDbContext DbContext;
	protected BaseRepository(LibraryDbContext dbContext) => DbContext = dbContext;
	public void Create(T entity) => DbContext.AddAsync(entity);
    public void Update(T entity) => DbContext.Update(entity);
    public void Delete(T entity) => DbContext.Update(entity);
    public Task<T?> GetById(Guid id, CancellationToken cancellationToken) => DbContext.Set<T>().FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
	public Task<List<T>> GetAll(CancellationToken cancellationToken) => DbContext.Set<T>().ToListAsync(cancellationToken);
}


