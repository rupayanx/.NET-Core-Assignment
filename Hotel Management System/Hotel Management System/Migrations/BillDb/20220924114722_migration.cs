using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hotel_Management_System.Migrations.BillDb
{
    public partial class migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Guest",
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
                    table.PrimaryKey("PK_Guest", x => x.GuestId);
                });

            migrationBuilder.CreateTable(
                name: "Room",
                columns: table => new
                {
                    RoomId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    room_status = table.Column<bool>(type: "bit", nullable: false),
                    room_comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    room_inventory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    room_price = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Room", x => x.RoomId);
                });

            migrationBuilder.CreateTable(
                name: "Room_Reservation",
                columns: table => new
                {
                    reservationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoomId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Checkin_Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Checkout_Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Number_of_Guests = table.Column<int>(type: "int", nullable: false),
                    GuestsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GuestId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GuestId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Room_Reservation", x => x.reservationId);
                    table.ForeignKey(
                        name: "FK_Room_Reservation_Guest_GuestId1",
                        column: x => x.GuestId1,
                        principalTable: "Guest",
                        principalColumn: "GuestId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Room_Reservation_Room_GuestId",
                        column: x => x.GuestId,
                        principalTable: "Room",
                        principalColumn: "RoomId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bills",
                columns: table => new
                {
                    BillId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Amount = table.Column<float>(type: "real", nullable: false),
                    BillDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GuestId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    reservationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bills", x => x.BillId);
                    table.ForeignKey(
                        name: "FK_Bills_Guest_GuestId",
                        column: x => x.GuestId,
                        principalTable: "Guest",
                        principalColumn: "GuestId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bills_Room_Reservation_reservationId",
                        column: x => x.reservationId,
                        principalTable: "Room_Reservation",
                        principalColumn: "reservationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bills_GuestId",
                table: "Bills",
                column: "GuestId");

            migrationBuilder.CreateIndex(
                name: "IX_Bills_reservationId",
                table: "Bills",
                column: "reservationId");

            migrationBuilder.CreateIndex(
                name: "IX_Room_Reservation_GuestId",
                table: "Room_Reservation",
                column: "GuestId");

            migrationBuilder.CreateIndex(
                name: "IX_Room_Reservation_GuestId1",
                table: "Room_Reservation",
                column: "GuestId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bills");

            migrationBuilder.DropTable(
                name: "Room_Reservation");

            migrationBuilder.DropTable(
                name: "Guest");

            migrationBuilder.DropTable(
                name: "Room");
        }
    }
}
