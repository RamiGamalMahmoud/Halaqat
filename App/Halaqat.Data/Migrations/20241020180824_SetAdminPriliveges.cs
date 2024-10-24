using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Halaqat.Data.Migrations
{
    /// <inheritdoc />
    public partial class SetAdminPriliveges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                UPDATE Users SET
                UsersManagementPrivileges_CanUpdate = 1,
                UsersManagementPrivileges_CanRead = 1,
                UsersManagementPrivileges_CanDelete = 1,
                UsersManagementPrivileges_CanCreate = 1,

                CirclesManagementPrivileges_CanCreate = 1,
                CirclesManagementPrivileges_CanDelete = 1,
                CirclesManagementPrivileges_CanRead = 1,
                CirclesManagementPrivileges_CanUpdate = 1,

                EmployeesManagementPrivileges_CanCreate = 1,
                EmployeesManagementPrivileges_CanDelete = 1,
                EmployeesManagementPrivileges_CanRead = 1,
                EmployeesManagementPrivileges_CanUpdate = 1,

                ProgramsManagementPrivileges_CanCreate = 1,
                ProgramsManagementPrivileges_CanDelete = 1,
                ProgramsManagementPrivileges_CanRead = 1,
                ProgramsManagementPrivileges_CanUpdate = 1,

                ReportsManagementPrivileges_CanCreate = 1,
                ReportsManagementPrivileges_CanDelete = 1,
                ReportsManagementPrivileges_CanRead = 1,
                ReportsManagementPrivileges_CanUpdate = 1,

                StudentsManagementPrivileges_CanCreate = 1,
                StudentsManagementPrivileges_CanDelete = 1,
                StudentsManagementPrivileges_CanRead = 1,
                StudentsManagementPrivileges_CanUpdate = 1
                Where Id = 1;
                ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
