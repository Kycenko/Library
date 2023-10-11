using Library.Infrastructure.Context;
using Library.Application.Repositories.Base;

namespace Library.Infrastructure.Repositories.Base
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LibraryDbContext _context;
        public UnitOfWork(LibraryDbContext context) => _context = context;
        public Task Save(CancellationToken cancellationToken) => _context.SaveChangesAsync(cancellationToken);
    }
}