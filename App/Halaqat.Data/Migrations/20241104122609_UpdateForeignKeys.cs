using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Halaqat.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateForeignKeys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProgramDayAppreciation_Students_StudentId",
                table: "ProgramDayAppreciation");

            migrationBuilder.AlterColumn<int>(
                name: "StudentId",
                table: "ProgramDayAppreciation",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ProgramDayAppreciation_Students_StudentId",
                table: "ProgramDayAppreciation",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProgramDayAppreciation_Students_StudentId",
                table: "ProgramDayAppreciation");

            migrationBuilder.AlterColumn<int>(
                name: "StudentId",
                table: "ProgramDayAppreciation",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_ProgramDayAppreciation_Students_StudentId",
                table: "ProgramDayAppreciation",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id");
        }
    }
}
