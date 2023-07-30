using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CheckersProject.Migrations
{
    /// <inheritdoc />
    public partial class Addedboardstogame : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GameId",
                table: "Boards",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Boards_GameId",
                table: "Boards",
                column: "GameId");

            migrationBuilder.AddForeignKey(
                name: "FK_Boards_Games_GameId",
                table: "Boards",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Boards_Games_GameId",
                table: "Boards");

            migrationBuilder.DropIndex(
                name: "IX_Boards_GameId",
                table: "Boards");

            migrationBuilder.DropColumn(
                name: "GameId",
                table: "Boards");
        }
    }
}
