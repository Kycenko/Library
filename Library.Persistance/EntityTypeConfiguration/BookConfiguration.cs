using Library.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.EntityTypeConfiguration
{
	public class BookConfiguration : IEntityTypeConfiguration<Book>
	{
		public void Configure(EntityTypeBuilder<Book> builder)
		{
			builder.HasKey(u => u.BookId);
			builder.HasIndex(u => u.BookId).IsUnique();
			// builder.HasOne(b => b.Author)
			// 	.WithMany()
			// 	.HasForeignKey(b => b.AuthorId);
			// builder.HasOne(b => b.Category)
			// 	.WithMany()
			// 	.HasForeignKey(b => b.CategoryId);
		}
	}
}