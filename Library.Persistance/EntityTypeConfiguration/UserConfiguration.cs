using Library.Domain.Entities;
using Library.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Infrastructure.EntityTypeConfiguration
{
	public class UserConfiguration : IEntityTypeConfiguration<User>
	{
		public void Configure(EntityTypeBuilder<User> builder)
		{
			builder.HasKey(u => u.Id);
			builder.HasIndex(u => u.Id).IsUnique();
			builder.Property(u => u.Id).IsRequired();
		}
	}
}