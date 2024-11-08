using CommunityToolkit.Mvvm.ComponentModel;
using System;

namespace Halaqat.Shared.Models
{
    [ObservableObject]
    public partial class User : ModelBase
    {
        [ObservableProperty]
        private string _userName;
        [ObservableProperty]
        private string _password;
        public DateTime DateCreated { get; set; }

        [ObservableProperty]
        private bool _isActive;

        [ObservableProperty]
        private bool _hasReportsPrivileges;

        [ObservableProperty]
        private bool _hasSettingsPrivileges;

        [ObservableProperty]
        private bool _hasFinancePrivileges;

        public bool IsSuperAdmin { get; private set; }

        public bool HasFullPrivileges
        {
            get => UsersManagementPrivileges.HasFullPrivileges &&
                EmployeesManagementPrivileges.HasFullPrivileges &&
                StudentsManagementPrivileges.HasFullPrivileges &&
                CirclesManagementPrivileges.HasFullPrivileges &&
                ProgramsManagementPrivileges.HasFullPrivileges;
            set
            {
                UsersManagementPrivileges.HasFullPrivileges = value;
                EmployeesManagementPrivileges.HasFullPrivileges = value;
                StudentsManagementPrivileges.HasFullPrivileges = value;
                CirclesManagementPrivileges.HasFullPrivileges = value;
                ProgramsManagementPrivileges.HasFullPrivileges = value;
            }
        }

        public Privileges UsersManagementPrivileges { get; set; } = new Privileges();
        public Privileges EmployeesManagementPrivileges { get; set; } = new Privileges();
        public Privileges StudentsManagementPrivileges { get; set; } = new Privileges();
        public Privileges CirclesManagementPrivileges { get; set; } = new Privileges();
        public Privileges ProgramsManagementPrivileges { get; set; } = new Privileges();
    }
}
