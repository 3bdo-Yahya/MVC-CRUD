using Microsoft.EntityFrameworkCore;
using Visual.Models;

namespace Visual.Models.Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Course>()
                .Property(c => c.Price)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Student>().HasData(
                new Student
                {
                    Id = 1,
                    Name = "Ahmed Ali",
                    Age = 22,
                    Email = "ahmed1@gmail.com",
                    Phone = "01000000001",
                    CreatedAt = new DateTime(2024, 1, 1)
                },
new Student
{
    Id = 2,
    Name = "Sara Mohamed",
    Age = 20,
    Email = "sara2@gmail.com",
    Phone = "01000000002",
    CreatedAt = new DateTime(2024, 1, 2)
},
new Student
{
    Id = 3,
    Name = "Omar Hassan",
    Age = 23,
    Email = "omar3@gmail.com",
    Phone = "01000000003",
    CreatedAt = new DateTime(2024, 1, 3)
},
new Student
{
    Id = 4,
    Name = "Mona Ahmed",
    Age = 21,
    Email = "mona4@gmail.com",
    Phone = "01000000004",
    CreatedAt = new DateTime(2024, 1, 4)
},
new Student
{
    Id = 5,
    Name = "Khaled Ali",
    Age = 24,
    Email = "khaled5@gmail.com",
    Phone = "01000000005",
    CreatedAt = new DateTime(2024, 1, 5)
},
new Student
{
    Id = 6,
    Name = "Nour Tarek",
    Age = 19,
    Email = "nour6@gmail.com",
    Phone = "01000000006",
    CreatedAt = new DateTime(2024, 1, 6)
},
new Student
{
    Id = 7,
    Name = "Youssef Adel",
    Age = 25,
    Email = "youssef7@gmail.com",
    Phone = "01000000007",
    CreatedAt = new DateTime(2024, 1, 7)
},
new Student
{
    Id = 8,
    Name = "Heba Mostafa",
    Age = 22,
    Email = "heba8@gmail.com",
    Phone = "01000000008",
    CreatedAt = new DateTime(2024, 1, 8)
},
new Student
{
    Id = 9,
    Name = "Tamer Saad",
    Age = 26,
    Email = "tamer9@gmail.com",
    Phone = "01000000009",
    CreatedAt = new DateTime(2024, 1, 9)
},
new Student
{
    Id = 10,
    Name = "Laila Sameh",
    Age = 20,
    Email = "laila10@gmail.com",
    Phone = "01000000010",
    CreatedAt = new DateTime(2024, 1, 10)
}
            );

            modelBuilder.Entity<Course>().HasData(
                new Course
                {
                    Id = 1,
                    Title = "Full Stack Web Development",
                    Description = "Learn Node.js, Express, and MongoDB from scratch.",
                    Hours = 60,
                    Instructor = "Alaa Ahmed",
                    Price = 150.00m,
                    CreatedAt = new DateTime(2026, 1, 1)
                },
                new Course
                {
                    Id = 2,
                    Title = "Mastering C# and .NET",
                    Description = "Build professional desktop and web applications.",
                    Hours = 45,
                    Instructor = "Ahmed Ali",
                    Price = 120.00m,
                    CreatedAt = new DateTime(2026, 1, 2)
                },
                new Course
                {
                    Id = 3,
                    Title = "UI/UX Design Fundamentals",
                    Description = "Design beautiful user interfaces with Figma.",
                    Hours = 30,
                    Instructor = "Sara Mohamed",
                    Price = 90.00m,
                    CreatedAt = new DateTime(2026, 1, 3)
                }
            );
        }
    }
}
