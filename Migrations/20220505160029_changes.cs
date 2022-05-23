using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class changes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_AspNetUsers_ApplicationUserId",
                schema: "Identity",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_ApplicationUserId",
                schema: "Identity",
                table: "Reservations");

            migrationBuilder.AlterColumn<Guid>(
                name: "ApplicationUserId",
                schema: "Identity",
                table: "Reservations",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                schema: "Identity",
                table: "Reservations",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_ApplicationUserId",
                schema: "Identity",
                table: "Reservations",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_AspNetUsers_ApplicationUserId",
                schema: "Identity",
                table: "Reservations",
                column: "ApplicationUserId",
                principalSchema: "Identity",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
