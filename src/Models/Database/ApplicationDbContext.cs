using Microsoft.EntityFrameworkCore;
using Visual.Models;

namespace Visual.Models.Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Book>().HasData(
                new Book
                {
                    Id = 1,
                    Title = "Clean Code",
                    Author = "Robert C. Martin",
                    Genre = "Software Engineering",
                    PublishedYear = 2008,
                    CopiesAvailable = 4,
                    CreatedAt = new DateTime(2026, 1, 1)
                },
                new Book
                {
                    Id = 2,
                    Title = "The Pragmatic Programmer",
                    Author = "Andrew Hunt",
                    Genre = "Software Engineering",
                    PublishedYear = 1999,
                    CopiesAvailable = 3,
                    CreatedAt = new DateTime(2026, 1, 2)
                },
                new Book
                {
                    Id = 3,
                    Title = "Atomic Habits",
                    Author = "James Clear",
                    Genre = "Self Development",
                    PublishedYear = 2018,
                    CopiesAvailable = 5,
                    CreatedAt = new DateTime(2026, 1, 3)
                });
        }
    }
}
