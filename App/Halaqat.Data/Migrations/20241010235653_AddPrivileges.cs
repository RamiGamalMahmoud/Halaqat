using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Halaqat.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddPrivileges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "UsersManagementPrivileges_CanUpdate",
                table: "Users",
                type: "bit",
                nullable: true,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "UsersManagementPrivileges_CanRead",
                table: "Users",
                type: "bit",
                nullable: true,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "UsersManagementPrivileges_CanDelete",
                table: "Users",
                type: "bit",
                nullable: true,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "UsersManagementPrivileges_CanCreate",
                table: "Users",
                type: "bit",
                nullable: true,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "CirclesManagementPrivileges_CanCreate",
                table: "Users",
                type: "bit",
                nullable: true,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "CirclesManagementPrivileges_CanDelete",
                table: "Users",
                type: "bit",
                nullable: true,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "CirclesManagementPrivileges_CanRead",
                table: "Users",
                type: "bit",
                nullable: true,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "CirclesManagementPrivileges_CanUpdate",
                table: "Users",
                type: "bit",
                nullable: true,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "EmployeesManagementPrivileges_CanCreate",
                table: "Users",
                type: "bit",
                nullable: true,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "EmployeesManagementPrivileges_CanDelete",
                table: "Users",
                type: "bit",
                nullable: true,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "EmployeesManagementPrivileges_CanRead",
                table: "Users",
                type: "bit",
                nullable: true,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "EmployeesManagementPrivileges_CanUpdate",
                table: "Users",
                type: "bit",
                nullable: true,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ProgramsManagementPrivileges_CanCreate",
                table: "Users",
                type: "bit",
                nullable: true,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ProgramsManagementPrivileges_CanDelete",
                table: "Users",
                type: "bit",
                nullable: true,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ProgramsManagementPrivileges_CanRead",
                table: "Users",
                type: "bit",
                nullable: true,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ProgramsManagementPrivileges_CanUpdate",
                table: "Users",
                type: "bit",
                nullable: true,
                defaultValue: false);

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

            migrationBuilder.AddColumn<bool>(
                name: "StudentsManagementPrivileges_CanCreate",
                table: "Users",
                type: "bit",
                nullable: true,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "StudentsManagementPrivileges_CanDelete",
                table: "Users",
                type: "bit",
                nullable: true,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "StudentsManagementPrivileges_CanRead",
                table: "Users",
                type: "bit",
                nullable: true,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "StudentsManagementPrivileges_CanUpdate",
                table: "Users",
                type: "bit",
                nullable: true,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CirclesManagementPrivileges_CanCreate",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CirclesManagementPrivileges_CanDelete",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CirclesManagementPrivileges_CanRead",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CirclesManagementPrivileges_CanUpdate",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "EmployeesManagementPrivileges_CanCreate",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "EmployeesManagementPrivileges_CanDelete",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "EmployeesManagementPrivileges_CanRead",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "EmployeesManagementPrivileges_CanUpdate",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ProgramsManagementPrivileges_CanCreate",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ProgramsManagementPrivileges_CanDelete",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ProgramsManagementPrivileges_CanRead",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ProgramsManagementPrivileges_CanUpdate",
                table: "Users");

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

            migrationBuilder.DropColumn(
                name: "StudentsManagementPrivileges_CanCreate",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "StudentsManagementPrivileges_CanDelete",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "StudentsManagementPrivileges_CanRead",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "StudentsManagementPrivileges_CanUpdate",
                table: "Users");

            migrationBuilder.AlterColumn<bool>(
                name: "UsersManagementPrivileges_CanUpdate",
                table: "Users",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true,
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "UsersManagementPrivileges_CanRead",
                table: "Users",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true,
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "UsersManagementPrivileges_CanDelete",
                table: "Users",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true,
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "UsersManagementPrivileges_CanCreate",
                table: "Users",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true,
                oldDefaultValue: false);
        }
    }
}
