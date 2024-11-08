using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Halaqat.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddTeacher : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TeacherId",
                table: "ProgramDayAppreciation",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProgramDayAppreciation_TeacherId",
                table: "ProgramDayAppreciation",
                column: "TeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProgramDayAppreciation_Teachers_TeacherId",
                table: "ProgramDayAppreciation",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProgramDayAppreciation_Teachers_TeacherId",
                table: "ProgramDayAppreciation");

            migrationBuilder.DropIndex(
                name: "IX_ProgramDayAppreciation_TeacherId",
                table: "ProgramDayAppreciation");

            migrationBuilder.DropColumn(
                name: "TeacherId",
                table: "ProgramDayAppreciation");
        }
    }
}
