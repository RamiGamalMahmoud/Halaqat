using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Halaqat.Data.Migrations
{
    /// <inheritdoc />
    public partial class CreateGenderTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Employees",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 27, 14, 10, 54, 218, DateTimeKind.Local).AddTicks(9609),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 27, 12, 6, 20, 557, DateTimeKind.Local).AddTicks(5878));

            migrationBuilder.CreateTable(
                name: "Gender",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "NVARCHAR(5)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gender", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Gender",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "ذكر" },
                    { 2, "أنثى" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Gender");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Employees",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 27, 12, 6, 20, 557, DateTimeKind.Local).AddTicks(5878),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 27, 14, 10, 54, 218, DateTimeKind.Local).AddTicks(9609));
        }
    }
}
