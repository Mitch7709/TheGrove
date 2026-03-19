using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Add_InstructorQualifications : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InstructorClassTypes",
                columns: table => new
                {
                    QualifiedClassTypesId = table.Column<int>(type: "int", nullable: false),
                    QualifiedInstructorsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstructorClassTypes", x => new { x.QualifiedClassTypesId, x.QualifiedInstructorsId });
                    table.ForeignKey(
                        name: "FK_InstructorClassTypes_ClassTypes_QualifiedClassTypesId",
                        column: x => x.QualifiedClassTypesId,
                        principalTable: "ClassTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InstructorClassTypes_Instructors_QualifiedInstructorsId",
                        column: x => x.QualifiedInstructorsId,
                        principalTable: "Instructors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InstructorClassTypes_QualifiedInstructorsId",
                table: "InstructorClassTypes",
                column: "QualifiedInstructorsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InstructorClassTypes");
        }
    }
}
