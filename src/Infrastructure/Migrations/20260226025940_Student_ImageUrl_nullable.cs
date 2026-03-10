using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations;

/// <inheritdoc />
public partial class Student_ImageUrl_nullable : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AlterColumn<string>(
            name: "ImageUrl",
            table: "Students",
            type: "nvarchar(200)",
            maxLength: 200,
            nullable: true,
            oldClrType: typeof(string),
            oldType: "nvarchar(200)",
            oldMaxLength: 200);
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AlterColumn<string>(
            name: "ImageUrl",
            table: "Students",
            type: "nvarchar(200)",
            maxLength: 200,
            nullable: false,
            defaultValue: "",
            oldClrType: typeof(string),
            oldType: "nvarchar(200)",
            oldMaxLength: 200,
            oldNullable: true);
    }
}
