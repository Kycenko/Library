using Library.Application.Repositories;
using Library.Domain.Common;
using Library.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Repositories;

public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
{
	protected readonly LibraryDbContext _dbContext;


	protected BaseRepository(LibraryDbContext dbContext)
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

	public Task<T?> GetById(Guid id, CancellationToken cancellationToken)
	{
		return _dbContext.Set<T>().FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
	}

	public Task<List<T>> GetAll(CancellationToken cancellationToken)
	{
		return _dbContext.Set<T>().ToListAsync(cancellationToken);
	}
}