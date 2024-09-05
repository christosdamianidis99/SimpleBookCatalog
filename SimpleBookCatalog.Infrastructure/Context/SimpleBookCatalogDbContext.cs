﻿using Microsoft.EntityFrameworkCore;
using SimpleBookCatalog.Domain.Entities;

public class SimpleBookCatalogDbContext : DbContext
{
    public SimpleBookCatalogDbContext(DbContextOptions<SimpleBookCatalogDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Genre>().HasData(
    new Genre { Id = 1, Name = "Fiction" },
    new Genre { Id = 2, Name = "Non-Fiction" },
    new Genre { Id = 3, Name = "Science Fiction" },
    new Genre { Id = 4, Name = "Fantasy" },
    new Genre { Id = 5, Name = "Mystery" },
    new Genre { Id = 6, Name = "Biography" }
);
        modelBuilder.Entity<Book>()
            .Property(b => b.Price)
            .HasPrecision(18, 2);

        modelBuilder.Entity<Book>()
                .HasOne(b => b.Author)
                .WithMany(a => a.Books)
                .HasForeignKey(b => b.AuthorId);

        modelBuilder.Entity<Book>()
            .HasOne(b => b.Publisher)
            .WithMany(a => a.Books)
            .HasForeignKey(b=>b.PublisherId);

        modelBuilder.Entity<Book>()
            .HasOne(b => b.Genre)
            .WithMany(a => a.Books)
            .HasForeignKey(b => b.GenreId);

        modelBuilder.Entity<Book>()
        .Property(b => b.Price)
        .HasPrecision(18, 2);

    }

    public DbSet<Book> Books { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<Publisher> Publishers { get; set; }

    public DbSet<Genre> Genres { get; set; }

}
