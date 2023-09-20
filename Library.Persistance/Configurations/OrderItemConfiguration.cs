using Library.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Infrastructure.Configurations;

public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
{
	public void Configure(EntityTypeBuilder<OrderItem> builder)
	{
		builder.HasKey(oi => oi.Id);
		builder.HasIndex(oi => oi.Id).IsUnique();
		builder.Property(oi => oi.Id).IsRequired();
	}
}