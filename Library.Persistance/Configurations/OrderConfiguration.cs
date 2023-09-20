using Library.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Infrastructure.Configurations;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{


	public void Configure(EntityTypeBuilder<Order> builder)
	{
		builder.HasKey(o => o.Id);
		builder.HasIndex(o => o.Id).IsUnique();
		builder.Property(o => o.Id).IsRequired();
	}
}