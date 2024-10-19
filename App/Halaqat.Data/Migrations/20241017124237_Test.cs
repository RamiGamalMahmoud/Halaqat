using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Halaqat.Data.Migrations
{
    /// <inheritdoc />
    public partial class Test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProgramDayAppreciation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateAppreciated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProgramDayId = table.Column<int>(type: "int", nullable: false),
                    AppreciationId = table.Column<int>(type: "int", nullable: false),
                    ProgramDayItemTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgramDayAppreciation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProgramDayAppreciation_Appreciations_AppreciationId",
                        column: x => x.AppreciationId,
                        principalTable: "Appreciations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProgramDayAppreciation_ProgramDays_ProgramDayId",
                        column: x => x.ProgramDayId,
                        principalTable: "ProgramDays",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProgramDayAppreciation_ProgramItemTypes_ProgramDayItemTypeId",
                        column: x => x.ProgramDayItemTypeId,
                        principalTable: "ProgramItemTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProgramDayAppreciation_AppreciationId",
                table: "ProgramDayAppreciation",
                column: "AppreciationId");

            migrationBuilder.CreateIndex(
                name: "IX_ProgramDayAppreciation_ProgramDayId",
                table: "ProgramDayAppreciation",
                column: "ProgramDayId");

            migrationBuilder.CreateIndex(
                name: "IX_ProgramDayAppreciation_ProgramDayItemTypeId",
                table: "ProgramDayAppreciation",
                column: "ProgramDayItemTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProgramDayAppreciation");
        }
    }
}
