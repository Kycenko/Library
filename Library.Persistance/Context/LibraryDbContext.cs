﻿using Library.Domain.Entities;
using Library.Infrastructure.EntityTypeConfiguration;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Context
{
	public class LibraryDbContext : DbContext
	{
		public DbSet<Admin>? Admins { get; set; }
		public DbSet<Customer>? Customers { get; set; }
		public DbSet<Book>? Books { get; set; }
		public DbSet<Author>? Authors { get; set; }
		public DbSet<Genre>? Genres { get; set; }
		public DbSet<Order>? Orders { get; set; }
		public DbSet<Publisher>? Publishers { get; set; }
		public DbSet<Review>? Reviews { get; set; }
		public DbSet<OrderItem>? OrderItems { get; set; }


		public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options)
		{
			if (!Database.CanConnect())
			{
				Database.EnsureCreated();
				Database.Migrate();
			}
		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.Entity<Admin>().ToTable("Admins");
			builder.Entity<Customer>().ToTable("Customers");
			//builder.Ignore<User>();
			builder.ApplyConfiguration(new UserConfiguration());
			builder.ApplyConfiguration(new AuthorConfiguration());
			builder.ApplyConfiguration(new GenreConfiguration());
			builder.ApplyConfiguration(new BookConfiguration());
			builder.ApplyConfiguration(new OrderConfiguration());
			builder.ApplyConfiguration(new ReviewConfiguration());
			builder.ApplyConfiguration(new PublisherConfiguration());
			builder.ApplyConfiguration(new OrderItemConfiguration());
			base.OnModelCreating(builder);
		}
	}
}