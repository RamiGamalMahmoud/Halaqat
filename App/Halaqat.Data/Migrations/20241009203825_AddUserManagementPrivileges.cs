using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Halaqat.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddUserManagementPrivileges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "UsersManagementPrivileges_CanCreate",
                table: "Users",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "UsersManagementPrivileges_CanDelete",
                table: "Users",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "UsersManagementPrivileges_CanRead",
                table: "Users",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "UsersManagementPrivileges_CanUpdate",
                table: "Users",
                type: "bit",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UsersManagementPrivileges_CanCreate",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UsersManagementPrivileges_CanDelete",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UsersManagementPrivileges_CanRead",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UsersManagementPrivileges_CanUpdate",
                table: "Users");
        }
    }
}
