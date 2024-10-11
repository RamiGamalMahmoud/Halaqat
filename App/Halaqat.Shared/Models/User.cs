using CommunityToolkit.Mvvm.ComponentModel;
using System;

namespace Halaqat.Shared.Models
{
    [ObservableObject]
    public partial class User : ModelBase
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime DateCreated { get; set; }

        [ObservableProperty]
        private bool _isActive;

        public bool HasFullPrivileges
        {
            get => UsersManagementPrivileges.HasFullPrivileges &&
                EmployeesManagementPrivileges.HasFullPrivileges &&
                StudentsManagementPrivileges.HasFullPrivileges &&
                CirclesManagementPrivileges.HasFullPrivileges &&
                ProgramsManagementPrivileges.HasFullPrivileges &&
                ReportsManagementPrivileges.HasFullPrivileges;
            set
            {
                UsersManagementPrivileges.HasFullPrivileges = value;
                EmployeesManagementPrivileges.HasFullPrivileges = value;
                StudentsManagementPrivileges.HasFullPrivileges = value;
                CirclesManagementPrivileges.HasFullPrivileges = value;
                ProgramsManagementPrivileges.HasFullPrivileges = value;
                ReportsManagementPrivileges.HasFullPrivileges = value;
            }
        }

        public Privileges UsersManagementPrivileges { get; set; } = new Privileges();
        public Privileges EmployeesManagementPrivileges { get; set; } = new Privileges();
        public Privileges StudentsManagementPrivileges { get; set; } = new Privileges();
        public Privileges CirclesManagementPrivileges { get; set; } = new Privileges();
        public Privileges ProgramsManagementPrivileges { get; set; } = new Privileges();
        public Privileges ReportsManagementPrivileges { get; set; } = new Privileges();
    }
}
