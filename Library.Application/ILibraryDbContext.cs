using Library.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Library.Application
{
	public interface ILibraryDbContext
	{
		DbSet<User> Users { get; set; }
		DbSet<Book> Books { get; set; }
		DbSet<Author> Authors { get; set; }
		DbSet<Category> Categories { get; set; }
		Task<int> SaveChangesAsync(CancellationToken cancellationToken);
	}
}