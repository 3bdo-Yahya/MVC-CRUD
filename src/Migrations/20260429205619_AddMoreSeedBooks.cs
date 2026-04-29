using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Visual.Migrations
{
    /// <inheritdoc />
    public partial class AddMoreSeedBooks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "CopiesAvailable", "CreatedAt", "Genre", "PublishedYear", "Title" },
                values: new object[,]
                {
                    { 4, "Cal Newport", 4, new DateTime(2026, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Productivity", 2016, "Deep Work" },
                    { 5, "Erich Gamma", 2, new DateTime(2026, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Software Engineering", 1994, "Design Patterns" },
                    { 6, "Martin Fowler", 3, new DateTime(2026, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Software Engineering", 2018, "Refactoring" },
                    { 7, "Francesc Miralles", 6, new DateTime(2026, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Wellbeing", 2017, "Ikigai" },
                    { 8, "Eric Ries", 3, new DateTime(2026, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Business", 2011, "The Lean Startup" },
                    { 9, "Yuval Noah Harari", 4, new DateTime(2026, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "History", 2014, "Sapiens" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 9);
        }
    }
}
