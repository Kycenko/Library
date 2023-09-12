using Library.Application;
using Library.Domain.Entities;
using Library.Infrastructure.EntityTypeConfiguration;
using Microsoft.EntityFrameworkCore;


namespace Library.Infrastructure
{
	public class LibraryDbContext : DbContext, ILibraryDbContext
	{
		public DbSet<User> Users { get; set; }
		public DbSet<Book> Books { get; set; }
		public DbSet<Author> Authors { get; set; }
		public DbSet<Category> Categories { get; set; }

		public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.ApplyConfiguration(new UserConfiguration());
			builder.ApplyConfiguration(new AuthorConfiguration());
			builder.ApplyConfiguration(new CategoryConfiguration());
			builder.ApplyConfiguration(new BookConfiguration());
			base.OnModelCreating(builder);
		}
	}
}