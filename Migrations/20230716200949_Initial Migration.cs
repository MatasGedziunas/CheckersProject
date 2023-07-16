using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CheckersProject.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Boards",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boards", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Cells",
                columns: table => new
                {
                    x = table.Column<int>(type: "int", nullable: false),
                    y = table.Column<int>(type: "int", nullable: false),
                    piece = table.Column<int>(type: "int", nullable: true),
                    Boardid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cells", x => new { x.x, x.y });
                    table.ForeignKey(
                        name: "FK_Cells_Boards_Boardid",
                        column: x => x.Boardid,
                        principalTable: "Boards",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cells_Boardid",
                table: "Cells",
                column: "Boardid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cells");

            migrationBuilder.DropTable(
                name: "Boards");
        }
    }
}
