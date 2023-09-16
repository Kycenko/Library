using Library.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Infrastructure.EntityTypeConfiguration;

public class ReviewConfiguration : IEntityTypeConfiguration<Review>
{
	public void Configure(EntityTypeBuilder<Review> builder)
	{
		builder.HasKey(r => r.Id);
		builder.HasIndex(r => r.Id).IsUnique();
		builder.Property(r => r.Id).IsRequired();
	}
}