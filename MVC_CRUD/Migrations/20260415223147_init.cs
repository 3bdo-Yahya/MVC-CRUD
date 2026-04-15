using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MVC_CRUD.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Age", "CreatedAt", "Email", "Name", "Phone" },
                values: new object[,]
                {
                    { 1, 22, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ahmed1@gmail.com", "Ahmed Ali", "01000000001" },
                    { 2, 20, new DateTime(2024, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "sara2@gmail.com", "Sara Mohamed", "01000000002" },
                    { 3, 23, new DateTime(2024, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "omar3@gmail.com", "Omar Hassan", "01000000003" },
                    { 4, 21, new DateTime(2024, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "mona4@gmail.com", "Mona Ahmed", "01000000004" },
                    { 5, 24, new DateTime(2024, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "khaled5@gmail.com", "Khaled Ali", "01000000005" },
                    { 6, 19, new DateTime(2024, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "nour6@gmail.com", "Nour Tarek", "01000000006" },
                    { 7, 25, new DateTime(2024, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "youssef7@gmail.com", "Youssef Adel", "01000000007" },
                    { 8, 22, new DateTime(2024, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "heba8@gmail.com", "Heba Mostafa", "01000000008" },
                    { 9, 26, new DateTime(2024, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "tamer9@gmail.com", "Tamer Saad", "01000000009" },
                    { 10, 20, new DateTime(2024, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "laila10@gmail.com", "Laila Sameh", "01000000010" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
