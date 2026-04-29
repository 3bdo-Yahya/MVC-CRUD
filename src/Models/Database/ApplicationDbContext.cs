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
                },
                new Book
                {
                    Id = 4,
                    Title = "Deep Work",
                    Author = "Cal Newport",
                    Genre = "Productivity",
                    PublishedYear = 2016,
                    CopiesAvailable = 4,
                    CreatedAt = new DateTime(2026, 1, 4)
                },
                new Book
                {
                    Id = 5,
                    Title = "Design Patterns",
                    Author = "Erich Gamma",
                    Genre = "Software Engineering",
                    PublishedYear = 1994,
                    CopiesAvailable = 2,
                    CreatedAt = new DateTime(2026, 1, 5)
                },
                new Book
                {
                    Id = 6,
                    Title = "Refactoring",
                    Author = "Martin Fowler",
                    Genre = "Software Engineering",
                    PublishedYear = 2018,
                    CopiesAvailable = 3,
                    CreatedAt = new DateTime(2026, 1, 6)
                },
                new Book
                {
                    Id = 7,
                    Title = "Ikigai",
                    Author = "Francesc Miralles",
                    Genre = "Wellbeing",
                    PublishedYear = 2017,
                    CopiesAvailable = 6,
                    CreatedAt = new DateTime(2026, 1, 7)
                },
                new Book
                {
                    Id = 8,
                    Title = "The Lean Startup",
                    Author = "Eric Ries",
                    Genre = "Business",
                    PublishedYear = 2011,
                    CopiesAvailable = 3,
                    CreatedAt = new DateTime(2026, 1, 8)
                },
                new Book
                {
                    Id = 9,
                    Title = "Sapiens",
                    Author = "Yuval Noah Harari",
                    Genre = "History",
                    PublishedYear = 2014,
                    CopiesAvailable = 4,
                    CreatedAt = new DateTime(2026, 1, 9)
                });
        }
    }
}
