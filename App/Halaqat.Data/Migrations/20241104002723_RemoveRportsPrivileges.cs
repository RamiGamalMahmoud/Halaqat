using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Halaqat.Data.Migrations
{
    /// <inheritdoc />
    public partial class RemoveRportsPrivileges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReportsManagementPrivileges_CanCreate",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ReportsManagementPrivileges_CanDelete",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ReportsManagementPrivileges_CanRead",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ReportsManagementPrivileges_CanUpdate",
                table: "Users");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "ReportsManagementPrivileges_CanCreate",
                table: "Users",
                type: "bit",
                nullable: true,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ReportsManagementPrivileges_CanDelete",
                table: "Users",
                type: "bit",
                nullable: true,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ReportsManagementPrivileges_CanRead",
                table: "Users",
                type: "bit",
                nullable: true,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ReportsManagementPrivileges_CanUpdate",
                table: "Users",
                type: "bit",
                nullable: true,
                defaultValue: false);
        }
    }
}
