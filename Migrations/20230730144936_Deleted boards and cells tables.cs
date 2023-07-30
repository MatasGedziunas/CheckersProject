using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CheckersProject.Migrations
{
    /// <inheritdoc />
    public partial class Deletedboardsandcellstables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cells_Boards_boardId",
                table: "Cells");

            migrationBuilder.DropForeignKey(
                name: "FK_Cells_Pieces_pieceId",
                table: "Cells");

            migrationBuilder.DropForeignKey(
                name: "FK_Games_Boards_LastBoardId",
                table: "Games");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cells",
                table: "Cells");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Boards",
                table: "Boards");

            migrationBuilder.RenameTable(
                name: "Cells",
                newName: "Cell");

            migrationBuilder.RenameTable(
                name: "Boards",
                newName: "Board");

            migrationBuilder.RenameIndex(
                name: "IX_Cells_pieceId",
                table: "Cell",
                newName: "IX_Cell_pieceId");

            migrationBuilder.RenameIndex(
                name: "IX_Cells_boardId",
                table: "Cell",
                newName: "IX_Cell_boardId");

            migrationBuilder.AddColumn<int>(
                name: "PieceId",
                table: "Moves",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cell",
                table: "Cell",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Board",
                table: "Board",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cell_Board_boardId",
                table: "Cell",
                column: "boardId",
                principalTable: "Board",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cell_Pieces_pieceId",
                table: "Cell",
                column: "pieceId",
                principalTable: "Pieces",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Board_LastBoardId",
                table: "Games",
                column: "LastBoardId",
                principalTable: "Board",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cell_Board_boardId",
                table: "Cell");

            migrationBuilder.DropForeignKey(
                name: "FK_Cell_Pieces_pieceId",
                table: "Cell");

            migrationBuilder.DropForeignKey(
                name: "FK_Games_Board_LastBoardId",
                table: "Games");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cell",
                table: "Cell");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Board",
                table: "Board");

            migrationBuilder.DropColumn(
                name: "PieceId",
                table: "Moves");

            migrationBuilder.RenameTable(
                name: "Cell",
                newName: "Cells");

            migrationBuilder.RenameTable(
                name: "Board",
                newName: "Boards");

            migrationBuilder.RenameIndex(
                name: "IX_Cell_pieceId",
                table: "Cells",
                newName: "IX_Cells_pieceId");

            migrationBuilder.RenameIndex(
                name: "IX_Cell_boardId",
                table: "Cells",
                newName: "IX_Cells_boardId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cells",
                table: "Cells",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Boards",
                table: "Boards",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cells_Boards_boardId",
                table: "Cells",
                column: "boardId",
                principalTable: "Boards",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cells_Pieces_pieceId",
                table: "Cells",
                column: "pieceId",
                principalTable: "Pieces",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Boards_LastBoardId",
                table: "Games",
                column: "LastBoardId",
                principalTable: "Boards",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
