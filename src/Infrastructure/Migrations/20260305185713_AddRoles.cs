using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "a7b8c9d0-1e2f-3a4b-5c6d-7e8f9a0b1c2d", null, "Instructor", "INSTRUCTOR" },
                    { "d4a1c57e-5f2b-4e3a-9c8d-1a2b3c4d5e6f", null, "Admin", "ADMIN" },
                    { "f1e2d3c4-b5a6-7890-abcd-ef1234567890", null, "Student", "STUDENT" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a7b8c9d0-1e2f-3a4b-5c6d-7e8f9a0b1c2d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d4a1c57e-5f2b-4e3a-9c8d-1a2b3c4d5e6f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f1e2d3c4-b5a6-7890-abcd-ef1234567890");
        }
    }
}
