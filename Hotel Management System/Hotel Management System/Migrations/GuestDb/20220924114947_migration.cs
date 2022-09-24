using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hotel_Management_System.Migrations.GuestDb
{
    public partial class migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "guests",
                columns: table => new
                {
                    GuestId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GuestName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GuestEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GuestAge = table.Column<int>(type: "int", nullable: false),
                    GuestPhoneNumber = table.Column<long>(type: "bigint", nullable: false),
                    GuestAdhaarCard = table.Column<long>(type: "bigint", nullable: false),
                    GuestAddress = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_guests", x => x.GuestId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "guests");
        }
    }
}
