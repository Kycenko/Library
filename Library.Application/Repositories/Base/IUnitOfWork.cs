namespace Library.Application.Repositories.Base;

public interface IUnitOfWork
{
    Task Save(CancellationToken cancellationToken);
}