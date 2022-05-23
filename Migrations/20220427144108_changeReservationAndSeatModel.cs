using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class changeReservationAndSeatModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberOfSeats",
                schema: "Identity",
                table: "Seats");

            migrationBuilder.AddColumn<int>(
                name: "SeatId",
                schema: "Identity",
                table: "Reservations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_SeatId",
                schema: "Identity",
                table: "Reservations",
                column: "SeatId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Seats_SeatId",
                schema: "Identity",
                table: "Reservations",
                column: "SeatId",
                principalSchema: "Identity",
                principalTable: "Seats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Seats_SeatId",
                schema: "Identity",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_SeatId",
                schema: "Identity",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "SeatId",
                schema: "Identity",
                table: "Reservations");

            migrationBuilder.AddColumn<int>(
                name: "NumberOfSeats",
                schema: "Identity",
                table: "Seats",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
