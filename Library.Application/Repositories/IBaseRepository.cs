using Library.Domain.Common;

namespace Library.Application.Repositories;

public interface IBaseRepository<T> where T : BaseEntity
{
    Task Create(T entity);
    void Update(T entity);
    void Delete(T entity);
    Task<T?> GetById(Guid id, CancellationToken cancellationToken);
    Task<List<T>> GetAll(CancellationToken cancellationToken);
}