using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Halaqat.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddUniqueIndexToCircleName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Circles_Name",
                table: "Circles",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Circles_Name",
                table: "Circles");
        }
    }
}
