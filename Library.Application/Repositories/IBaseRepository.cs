using Library.Domain.Common;

namespace Library.Application.Repositories;

public interface IBaseRepository<T> where T : BaseEntity
{
    void Create(T entity);
    void Update(T entity);
    void Delete(T entity);
    Task<T?> GetById(Guid id);
    Task<IEnumerable<T>?> GetAll();
}