using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Halaqat.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddAcademicQualificationsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AcademicQualifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "NVARCHAR(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcademicQualifications", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AcademicQualifications",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "جامعي" },
                    { 2, "متوسط" },
                    { 3, "دكتوراه" },
                    { 4, "بدون" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AcademicQualifications_Name",
                table: "AcademicQualifications",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AcademicQualifications");
        }
    }
}
