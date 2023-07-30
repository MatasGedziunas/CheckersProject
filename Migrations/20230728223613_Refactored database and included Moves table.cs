using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CheckersProject.Migrations
{
    /// <inheritdoc />
    public partial class RefactoreddatabaseandincludedMovestable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "LastBoardid",
                table: "Games",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Moves",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GameId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    MoveNumber = table.Column<int>(type: "int", nullable: false),
                    FromCell = table.Column<int>(type: "int", nullable: false),
                    ToCell = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Moves", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Moves_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Games_LastBoardid",
                table: "Games",
                column: "LastBoardid");

            migrationBuilder.CreateIndex(
                name: "IX_Moves_GameId",
                table: "Moves",
                column: "GameId");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Boards_LastBoardid",
                table: "Games",
                column: "LastBoardid",
                principalTable: "Boards",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Boards_LastBoardid",
                table: "Games");

            migrationBuilder.DropTable(
                name: "Moves");

            migrationBuilder.DropIndex(
                name: "IX_Games_LastBoardid",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "LastBoardid",
                table: "Games");

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
    }
}
