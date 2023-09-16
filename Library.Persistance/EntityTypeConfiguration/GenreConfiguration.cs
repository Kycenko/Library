using Library.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Infrastructure.EntityTypeConfiguration;

public class GenreConfiguration : IEntityTypeConfiguration<Genre>
{
	public void Configure(EntityTypeBuilder<Genre> builder)
	{
		builder.HasKey(g => g.Id);
		builder.HasIndex(g => g.Id).IsUnique();
		builder.Property(g => g.Id).IsRequired();
	}
}