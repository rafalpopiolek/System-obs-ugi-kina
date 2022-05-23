using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class change4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_AspNetUsers_ApplicationUserId1",
                schema: "Identity",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_ApplicationUserId1",
                schema: "Identity",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId1",
                schema: "Identity",
                table: "Reservations");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId1",
                schema: "Identity",
                table: "Reservations",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_ApplicationUserId1",
                schema: "Identity",
                table: "Reservations",
                column: "ApplicationUserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_AspNetUsers_ApplicationUserId1",
                schema: "Identity",
                table: "Reservations",
                column: "ApplicationUserId1",
                principalSchema: "Identity",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
