using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CheckersProject.Migrations
{
    /// <inheritdoc />
    public partial class FixedUserIdrelationshipingame : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "WhiteUserId",
                table: "Games",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BlackUserId",
                table: "Games",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Games_BlackUserId",
                table: "Games",
                column: "BlackUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_WhiteUserId",
                table: "Games",
                column: "WhiteUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Users_BlackUserId",
                table: "Games",
                column: "BlackUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Users_WhiteUserId",
                table: "Games",
                column: "WhiteUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Users_BlackUserId",
                table: "Games");

            migrationBuilder.DropForeignKey(
                name: "FK_Games_Users_WhiteUserId",
                table: "Games");

            migrationBuilder.DropIndex(
                name: "IX_Games_BlackUserId",
                table: "Games");

            migrationBuilder.DropIndex(
                name: "IX_Games_WhiteUserId",
                table: "Games");

            migrationBuilder.AlterColumn<string>(
                name: "WhiteUserId",
                table: "Games",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "BlackUserId",
                table: "Games",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
