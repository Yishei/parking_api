using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace parking_api.Migrations
{
    /// <inheritdoc />
    public partial class _0055 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pollings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CondoId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PollStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PollEnd = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pollings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pollings_Condos_CondoId",
                        column: x => x.CondoId,
                        principalTable: "Condos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PollInputs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PollId = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Required = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PollInputs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PollInputs_Pollings_PollId",
                        column: x => x.PollId,
                        principalTable: "Pollings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PollInputSelections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InputId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PollInputSelections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PollInputSelections_PollInputs_InputId",
                        column: x => x.InputId,
                        principalTable: "PollInputs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PollResults",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InputId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Result = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubmitTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PollResults", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PollResults_PollInputs_InputId",
                        column: x => x.InputId,
                        principalTable: "PollInputs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pollings_CondoId",
                table: "Pollings",
                column: "CondoId");

            migrationBuilder.CreateIndex(
                name: "IX_PollInputs_PollId",
                table: "PollInputs",
                column: "PollId");

            migrationBuilder.CreateIndex(
                name: "IX_PollInputSelections_InputId",
                table: "PollInputSelections",
                column: "InputId");

            migrationBuilder.CreateIndex(
                name: "IX_PollResults_InputId",
                table: "PollResults",
                column: "InputId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PollInputSelections");

            migrationBuilder.DropTable(
                name: "PollResults");

            migrationBuilder.DropTable(
                name: "PollInputs");

            migrationBuilder.DropTable(
                name: "Pollings");
        }
    }
}
