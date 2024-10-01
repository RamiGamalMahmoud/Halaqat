using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Halaqat.Data.Migrations
{
    /// <inheritdoc />
    public partial class CreateCircleStudentsRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CircleId",
                table: "Students",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Students_CircleId",
                table: "Students",
                column: "CircleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Circles_CircleId",
                table: "Students",
                column: "CircleId",
                principalTable: "Circles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Circles_CircleId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_CircleId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "CircleId",
                table: "Students");
        }
    }
}
