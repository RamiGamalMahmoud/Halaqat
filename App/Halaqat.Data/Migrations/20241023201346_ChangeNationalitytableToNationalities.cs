using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Halaqat.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangeNationalitytableToNationalities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Nationality",
                table: "Nationality");

            migrationBuilder.RenameTable(
                name: "Nationality",
                newName: "Nationalities");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Nationalities",
                table: "Nationalities",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Nationalities",
                table: "Nationalities");

            migrationBuilder.RenameTable(
                name: "Nationalities",
                newName: "Nationality");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Nationality",
                table: "Nationality",
                column: "Id");
        }
    }
}
