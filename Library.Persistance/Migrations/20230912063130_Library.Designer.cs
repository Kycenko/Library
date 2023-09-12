﻿// <auto-generated />
using System;
using Library.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Library.Infrastructure.Migrations
{
    [DbContext(typeof(LibraryDbContext))]
    [Migration("20230912063130_Library")]
    partial class Library
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Library.Domain.Entities.Author", b =>
                {
                    b.Property<Guid>("AuthorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("AuthorName")
                        .HasColumnType("text");

                    b.HasKey("AuthorId");

                    b.HasIndex("AuthorId")
                        .IsUnique();

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("Library.Domain.Entities.Book", b =>
                {
                    b.Property<Guid>("BookId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("AuthorId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("CategoryId")
                        .IsRequired()
                        .HasColumnType("uuid");

                    b.Property<decimal?>("Price")
                        .HasColumnType("numeric");

                    b.Property<DateTime?>("PublicationDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.HasKey("BookId");

                    b.HasIndex("AuthorId");

                    b.HasIndex("BookId")
                        .IsUnique();

                    b.HasIndex("CategoryId");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("Library.Domain.Entities.Category", b =>
                {
                    b.Property<Guid>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("CategoryName")
                        .HasColumnType("text");

                    b.HasKey("CategoryId");

                    b.HasIndex("CategoryId")
                        .IsUnique();

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Library.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<int>("Role")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("UserName")
                        .HasColumnType("text");

                    b.HasKey("UserId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Library.Domain.Entities.Book", b =>
                {
                    b.HasOne("Library.Domain.Entities.Author", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId");

                    b.HasOne("Library.Domain.Entities.Book", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Category");
                });
#pragma warning restore 612, 618
        }
    }
}
