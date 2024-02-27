using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace parking_api.Migrations
{
    /// <inheritdoc />
    public partial class _0056 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "PollResults");

            migrationBuilder.AddColumn<int>(
                name: "UnitId",
                table: "PollResults",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PollResults_UnitId",
                table: "PollResults",
                column: "UnitId");

            migrationBuilder.AddForeignKey(
                name: "FK_PollResults_Units_UnitId",
                table: "PollResults",
                column: "UnitId",
                principalTable: "Units",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PollResults_Units_UnitId",
                table: "PollResults");

            migrationBuilder.DropIndex(
                name: "IX_PollResults_UnitId",
                table: "PollResults");

            migrationBuilder.DropColumn(
                name: "UnitId",
                table: "PollResults");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "PollResults",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
