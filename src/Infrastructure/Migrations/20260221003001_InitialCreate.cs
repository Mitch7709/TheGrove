using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations;

/// <inheritdoc />
public partial class InitialCreate : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "ClassTypes",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                Style = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                Level = table.Column<int>(type: "int", nullable: false),
                IsActive = table.Column<bool>(type: "bit", nullable: false),
                CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_ClassTypes", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "Instructors",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                Bio = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                ImageUrl = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Instructors", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "Rooms",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                Capacity = table.Column<int>(type: "int", nullable: false),
                IsActive = table.Column<bool>(type: "bit", nullable: false),
                CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Rooms", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "Students",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                Age = table.Column<int>(type: "int", nullable: false),
                DateOfBirth = table.Column<DateOnly>(type: "date", nullable: false),
                PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                ImageUrl = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                WaiverStatus = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Students", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "TimeSlots",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                StartTime = table.Column<TimeOnly>(type: "time", nullable: false),
                DurationInMinutes = table.Column<int>(type: "int", nullable: false),
                DayOfWeek = table.Column<string>(type: "nvarchar(max)", nullable: false),
                IsActive = table.Column<bool>(type: "bit", nullable: false),
                RoomId = table.Column<int>(type: "int", nullable: false),
                CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_TimeSlots", x => x.Id);
                table.ForeignKey(
                    name: "FK_TimeSlots_Rooms_RoomId",
                    column: x => x.RoomId,
                    principalTable: "Rooms",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Restrict);
            });

        migrationBuilder.CreateTable(
            name: "Sessions",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                StudentId = table.Column<int>(type: "int", nullable: false),
                InstructorId = table.Column<int>(type: "int", nullable: false),
                TimeSlotId = table.Column<int>(type: "int", nullable: false),
                Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Sessions", x => x.Id);
                table.ForeignKey(
                    name: "FK_Sessions_Instructors_InstructorId",
                    column: x => x.InstructorId,
                    principalTable: "Instructors",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Restrict);
                table.ForeignKey(
                    name: "FK_Sessions_Students_StudentId",
                    column: x => x.StudentId,
                    principalTable: "Students",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Restrict);
                table.ForeignKey(
                    name: "FK_Sessions_TimeSlots_TimeSlotId",
                    column: x => x.TimeSlotId,
                    principalTable: "TimeSlots",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Restrict);
            });

        migrationBuilder.CreateTable(
            name: "Bookings",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                SessionId = table.Column<int>(type: "int", nullable: false),
                StudentId = table.Column<int>(type: "int", nullable: false),
                BookingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                PaymentStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                ConfirmationId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                PriceAtBooking = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                BookingStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Bookings", x => x.Id);
                table.ForeignKey(
                    name: "FK_Bookings_Sessions_SessionId",
                    column: x => x.SessionId,
                    principalTable: "Sessions",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_Bookings_Students_StudentId",
                    column: x => x.StudentId,
                    principalTable: "Students",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Restrict);
            });

        migrationBuilder.CreateIndex(
            name: "IX_Bookings_SessionId",
            table: "Bookings",
            column: "SessionId");

        migrationBuilder.CreateIndex(
            name: "IX_Bookings_StudentId_SessionId",
            table: "Bookings",
            columns: new[] { "StudentId", "SessionId" },
            unique: true);

        migrationBuilder.CreateIndex(
            name: "IX_Sessions_InstructorId",
            table: "Sessions",
            column: "InstructorId");

        migrationBuilder.CreateIndex(
            name: "IX_Sessions_StudentId",
            table: "Sessions",
            column: "StudentId");

        migrationBuilder.CreateIndex(
            name: "IX_Sessions_TimeSlotId",
            table: "Sessions",
            column: "TimeSlotId");

        migrationBuilder.CreateIndex(
            name: "IX_TimeSlots_RoomId",
            table: "TimeSlots",
            column: "RoomId");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "Bookings");

        migrationBuilder.DropTable(
            name: "ClassTypes");

        migrationBuilder.DropTable(
            name: "Sessions");

        migrationBuilder.DropTable(
            name: "Instructors");

        migrationBuilder.DropTable(
            name: "Students");

        migrationBuilder.DropTable(
            name: "TimeSlots");

        migrationBuilder.DropTable(
            name: "Rooms");
    }
}
