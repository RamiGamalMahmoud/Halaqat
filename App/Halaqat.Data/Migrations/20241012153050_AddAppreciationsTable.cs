using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Halaqat.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddAppreciationsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Appreciations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "NVARCHAR(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appreciations", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Appreciations",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "إعادة" },
                    { 2, "جيد" },
                    { 3, "جيد جدا" },
                    { 4, "ممتاز" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appreciations_Name",
                table: "Appreciations",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appreciations");
        }
    }
}
