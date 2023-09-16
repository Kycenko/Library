using Library.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.EntityTypeConfiguration
{
	public class BookConfiguration : IEntityTypeConfiguration<Book>
	{
		public void Configure(EntityTypeBuilder<Book> builder)
		{
			builder.HasKey(b => b.Id);
			builder.HasIndex(b => b.Id).IsUnique();
			builder.Property(b => b.Id).IsRequired();
		}
	}
}