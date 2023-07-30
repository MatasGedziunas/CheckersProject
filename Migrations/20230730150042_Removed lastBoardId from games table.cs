using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CheckersProject.Migrations
{
    /// <inheritdoc />
    public partial class RemovedlastBoardIdfromgamestable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {


            migrationBuilder.DropIndex(
                name: "IX_Games_LastBoardId",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "LastBoardId",
                table: "Games");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LastBoardId",
                table: "Games",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Board",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Board", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Cell",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    boardId = table.Column<int>(type: "int", nullable: false),
                    pieceId = table.Column<int>(type: "int", nullable: true),
                    x = table.Column<int>(type: "int", nullable: false),
                    y = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cell", x => x.id);
                    table.ForeignKey(
                        name: "FK_Cell_Board_boardId",
                        column: x => x.boardId,
                        principalTable: "Board",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cell_Pieces_pieceId",
                        column: x => x.pieceId,
                        principalTable: "Pieces",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Games_LastBoardId",
                table: "Games",
                column: "LastBoardId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cell_boardId",
                table: "Cell",
                column: "boardId");

            migrationBuilder.CreateIndex(
                name: "IX_Cell_pieceId",
                table: "Cell",
                column: "pieceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Board_LastBoardId",
                table: "Games",
                column: "LastBoardId",
                principalTable: "Board",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
