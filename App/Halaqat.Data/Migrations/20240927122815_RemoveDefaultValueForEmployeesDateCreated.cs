using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Halaqat.Data.Migrations
{
    /// <inheritdoc />
    public partial class RemoveDefaultValueForEmployeesDateCreated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Employees",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 27, 14, 28, 16, 238, DateTimeKind.Local).AddTicks(1702));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Employees",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 27, 14, 28, 16, 238, DateTimeKind.Local).AddTicks(1702),
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }
    }
}
