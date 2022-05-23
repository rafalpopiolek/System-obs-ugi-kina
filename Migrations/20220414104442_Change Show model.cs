using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class ChangeShowmodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shows_Movies_MovieId",
                schema: "Identity",
                table: "Shows");

            migrationBuilder.AlterColumn<int>(
                name: "MovieId",
                schema: "Identity",
                table: "Shows",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Shows_Movies_MovieId",
                schema: "Identity",
                table: "Shows",
                column: "MovieId",
                principalSchema: "Identity",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shows_Movies_MovieId",
                schema: "Identity",
                table: "Shows");

            migrationBuilder.AlterColumn<int>(
                name: "MovieId",
                schema: "Identity",
                table: "Shows",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Shows_Movies_MovieId",
                schema: "Identity",
                table: "Shows",
                column: "MovieId",
                principalSchema: "Identity",
                principalTable: "Movies",
                principalColumn: "Id");
        }
    }
}
