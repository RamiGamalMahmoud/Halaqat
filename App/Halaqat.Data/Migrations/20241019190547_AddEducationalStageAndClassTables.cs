using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Halaqat.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddEducationalStageAndClassTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EducationalStages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "NVARCHAR(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EducationalStages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Classes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "NVARCHAR(20)", nullable: false),
                    EducationalStageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Classes_EducationalStages_EducationalStageId",
                        column: x => x.EducationalStageId,
                        principalTable: "EducationalStages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "EducationalStages",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "ما قبل الدراسة" },
                    { 2, "إبتدائي" },
                    { 3, "متوسطة" },
                    { 4, "ثانوي" },
                    { 5, "جامعي" }
                });

            migrationBuilder.InsertData(
                table: "Classes",
                columns: new[] { "Id", "EducationalStageId", "Name" },
                values: new object[,]
                {
                    { 1, 2, "أول" },
                    { 2, 2, "ثاني" },
                    { 3, 2, "ثالث" },
                    { 4, 2, "رابع" },
                    { 5, 2, "خامس" },
                    { 6, 2, "سادس" },
                    { 7, 3, "أول" },
                    { 8, 3, "ثاني" },
                    { 9, 3, "ثالث" },
                    { 10, 4, "أول" },
                    { 11, 4, "ثاني" },
                    { 12, 4, "ثالث" },
                    { 13, 5, "أول" },
                    { 14, 5, "ثاني" },
                    { 15, 5, "ثالث" },
                    { 16, 5, "رابع" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Classes_EducationalStageId",
                table: "Classes",
                column: "EducationalStageId");

            migrationBuilder.CreateIndex(
                name: "IX_EducationalStages_Name",
                table: "EducationalStages",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Classes");

            migrationBuilder.DropTable(
                name: "EducationalStages");
        }
    }
}
