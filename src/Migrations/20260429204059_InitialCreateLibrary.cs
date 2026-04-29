using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Visual.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreateLibrary : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false),
                    Author = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Genre = table.Column<string>(type: "TEXT", maxLength: 80, nullable: false),
                    PublishedYear = table.Column<int>(type: "INTEGER", nullable: false),
                    CopiesAvailable = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "CopiesAvailable", "CreatedAt", "Genre", "PublishedYear", "Title" },
                values: new object[,]
                {
                    { 1, "Robert C. Martin", 4, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Software Engineering", 2008, "Clean Code" },
                    { 2, "Andrew Hunt", 3, new DateTime(2026, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Software Engineering", 1999, "The Pragmatic Programmer" },
                    { 3, "James Clear", 5, new DateTime(2026, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Self Development", 2018, "Atomic Habits" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}
