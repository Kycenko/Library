using Library.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Infrastructure.EntityTypeConfiguration;

public class PublisherConfiguration : IEntityTypeConfiguration<Publisher>
{
	public void Configure(EntityTypeBuilder<Publisher> builder)
	{
		builder.HasKey(p => p.Id);
		builder.HasIndex(p => p.Id).IsUnique();
		builder.Property(p => p.Id).IsRequired();
	}
}