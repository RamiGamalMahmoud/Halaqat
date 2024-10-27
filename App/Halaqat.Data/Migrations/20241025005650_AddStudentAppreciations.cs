using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Halaqat.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddStudentAppreciations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "ProgramDayAppreciation",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProgramDayAppreciation_StudentId",
                table: "ProgramDayAppreciation",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProgramDayAppreciation_Students_StudentId",
                table: "ProgramDayAppreciation",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProgramDayAppreciation_Students_StudentId",
                table: "ProgramDayAppreciation");

            migrationBuilder.DropIndex(
                name: "IX_ProgramDayAppreciation_StudentId",
                table: "ProgramDayAppreciation");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "ProgramDayAppreciation");
        }
    }
}
