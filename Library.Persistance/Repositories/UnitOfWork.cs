using Library.Application.Repositories;
using Library.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Infrastructure.Repositories
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly LibraryDbContext _context;
		public UnitOfWork(LibraryDbContext context) => _context = context;
		public Task Save(CancellationToken cancellationToken) => _context.SaveChangesAsync(cancellationToken);
	}
}