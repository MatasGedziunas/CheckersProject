using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CheckersProject.Migrations
{
    /// <inheritdoc />
    public partial class AddedaGameandUsertablesapieceTablewhichismappedtopieceIdincelltablecolumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "piece",
                table: "Cells",
                newName: "pieceId");

            migrationBuilder.CreateTable(
                name: "Piece",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    team = table.Column<int>(type: "int", nullable: false),
                    pieceType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Piece", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cells_pieceId",
                table: "Cells",
                column: "pieceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cells_Piece_pieceId",
                table: "Cells",
                column: "pieceId",
                principalTable: "Piece",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cells_Piece_pieceId",
                table: "Cells");

            migrationBuilder.DropTable(
                name: "Piece");

            migrationBuilder.DropIndex(
                name: "IX_Cells_pieceId",
                table: "Cells");

            migrationBuilder.RenameColumn(
                name: "pieceId",
                table: "Cells",
                newName: "piece");
        }
    }
}
