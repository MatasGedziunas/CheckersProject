using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CheckersProject.Migrations
{
    /// <inheritdoc />
    public partial class Addedrelationshipbetweencellsandboard : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cells_Boards_Boardid",
                table: "Cells");

            migrationBuilder.DropForeignKey(
                name: "FK_Games_Boards_LastBoardid",
                table: "Games");

            migrationBuilder.DropIndex(
                name: "IX_Games_LastBoardid",
                table: "Games");

            migrationBuilder.RenameColumn(
                name: "LastBoardid",
                table: "Games",
                newName: "LastBoardId");

            migrationBuilder.RenameColumn(
                name: "Boardid",
                table: "Cells",
                newName: "boardId");

            migrationBuilder.RenameIndex(
                name: "IX_Cells_Boardid",
                table: "Cells",
                newName: "IX_Cells_boardId");

            migrationBuilder.AlterColumn<int>(
                name: "boardId",
                table: "Cells",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Games_LastBoardId",
                table: "Games",
                column: "LastBoardId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Cells_Boards_boardId",
                table: "Cells",
                column: "boardId",
                principalTable: "Boards",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Boards_LastBoardId",
                table: "Games",
                column: "LastBoardId",
                principalTable: "Boards",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cells_Boards_boardId",
                table: "Cells");

            migrationBuilder.DropForeignKey(
                name: "FK_Games_Boards_LastBoardId",
                table: "Games");

            migrationBuilder.DropIndex(
                name: "IX_Games_LastBoardId",
                table: "Games");

            migrationBuilder.RenameColumn(
                name: "LastBoardId",
                table: "Games",
                newName: "LastBoardid");

            migrationBuilder.RenameColumn(
                name: "boardId",
                table: "Cells",
                newName: "Boardid");

            migrationBuilder.RenameIndex(
                name: "IX_Cells_boardId",
                table: "Cells",
                newName: "IX_Cells_Boardid");

            migrationBuilder.AlterColumn<int>(
                name: "Boardid",
                table: "Cells",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Games_LastBoardid",
                table: "Games",
                column: "LastBoardid");

            migrationBuilder.AddForeignKey(
                name: "FK_Cells_Boards_Boardid",
                table: "Cells",
                column: "Boardid",
                principalTable: "Boards",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Boards_LastBoardid",
                table: "Games",
                column: "LastBoardid",
                principalTable: "Boards",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
