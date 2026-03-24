using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Update_Session_RemoveStudent_AddClassType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sessions_Students_StudentId",
                table: "Sessions");

            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "Sessions",
                newName: "ClassTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Sessions_StudentId",
                table: "Sessions",
                newName: "IX_Sessions_ClassTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sessions_ClassTypes_ClassTypeId",
                table: "Sessions",
                column: "ClassTypeId",
                principalTable: "ClassTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sessions_ClassTypes_ClassTypeId",
                table: "Sessions");

            migrationBuilder.RenameColumn(
                name: "ClassTypeId",
                table: "Sessions",
                newName: "StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_Sessions_ClassTypeId",
                table: "Sessions",
                newName: "IX_Sessions_StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sessions_Students_StudentId",
                table: "Sessions",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
