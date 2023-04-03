using Microsoft.EntityFrameworkCore;
using ORM.Model;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;

namespace ORM.EFCore
{
    public class PublisherDbContext : DbContext
    {
        public PublisherDbContext(DbContextOptions options) : base(options) { }
        public DbSet<Book> Books { get; set; } = null!;
        public DbSet<Author> Authors { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Author>().HasData(new Author[]
            {
                new Author { Id = 1,Name = "Saadi" },
                new Author { Id= 2,Name = "Hafez" },
                new Author { Id=3,Name = "Ferdowsi" },
                new Author { Id=4,Name = "Khayam" }
            });
            modelBuilder.Entity<Book>().HasData(new Book[] {
                new Book {
                    Id = 1,
                    AuthorId = 1,
                    Price = 2000000,
                    Title = "Golestan Saadi"
                },new Book{
                    Id= 2,
                    AuthorId = 2 ,
                    Price = 1000000,
                    Title = "Ghazaliat Hafez"
                },new Book{
                    Id= 3,
                    AuthorId = 3 ,
                    Price = 3000000,
                    Title = "Shahnameh Ferdowsi"
                },new Book{
                    Id= 4,
                    AuthorId = 4 ,
                    Price = 1500000,
                    Title = "Robaeyat Khayam"
                }
            });
        }
    }
}
