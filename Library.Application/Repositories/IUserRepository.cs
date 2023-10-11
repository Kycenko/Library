using Library.Application.Repositories.Base;
using Library.Domain.Entities;

namespace Library.Application.Repositories;

public interface IUserRepository : IBaseRepository<Domain.Entities.User>
{
    Task<Domain.Entities.User?> GetByEmail(string email, CancellationToken cancellationToken);
}