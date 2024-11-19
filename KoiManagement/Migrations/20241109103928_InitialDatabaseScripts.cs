using System;
using KoiManagement.WebApplication.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KoiManagement.WebApplication.Migrations
{
    /// <inheritdoc />
    public partial class InitialDatabaseScripts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BookingSchedule",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    koi_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Booking_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    vets_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingSchedule", x => x.Id);
                });
            migrationBuilder.InsertData(
     table: "BookingSchedule",
     columns: new[] { "name", "phone", "email", "koi_name", "Booking_Date", "vets_name", "description" },
     values: new object[,]
     {
        { "John Doe", "1234567890", "johndoe@example.com", "Koi A", DateTime.Now.AddDays(1), "Dr. Smith", "Routine check-up" },
        { "Jane Doe", "0987654321", "janedoe@example.com", "Koi B", DateTime.Now.AddDays(2), "Dr. Lee", "Follow-up treatment" }
     }
 );

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookingSchedule");
        }

    }
}
