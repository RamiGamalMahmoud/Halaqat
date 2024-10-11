using CommunityToolkit.Mvvm.ComponentModel;
using Halaqat.Shared.Common;
using Halaqat.Shared.Models;
using System.ComponentModel.DataAnnotations;

namespace Halaqat.Features.Users
{
    internal partial class UserDataModel : DataModelBase<User>
    {
        public UserDataModel(User model) : base(model)
        {
            if (model is null)
            {
            }
            else
            {
                UserName = model.UserName;
                Password = model.Password;
                IsActive = model.IsActive;

                UsersManagementPrivileges = model.UsersManagementPrivileges;
                EmployeesManagementPrivileges = model.EmployeesManagementPrivileges;
                StudentsManagementPrivileges = model.StudentsManagementPrivileges;
                CirclesManagementPrivileges = model.CirclesManagementPrivileges;
                ProgramsManagementPrivileges = model.ProgramsManagementPrivileges;
                ReportsManagementPrivileges = model.ReportsManagementPrivileges;
            }

            UsersManagementPrivileges.PropertyChanged += Privileges_PropertyChanged;
            EmployeesManagementPrivileges.PropertyChanged += Privileges_PropertyChanged;
            StudentsManagementPrivileges.PropertyChanged += Privileges_PropertyChanged;
            CirclesManagementPrivileges.PropertyChanged += Privileges_PropertyChanged;
            ProgramsManagementPrivileges.PropertyChanged += Privileges_PropertyChanged;
            ReportsManagementPrivileges.PropertyChanged += Privileges_PropertyChanged;
            ValidateAllProperties();
        }

        private void Privileges_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            OnPropertyChanged();
        }

        public override void Update(User model = null)
        {
            User userModelToUpdate = model is null ? Model : model;

            userModelToUpdate.UserName = UserName;
            userModelToUpdate.Password = Password;
            userModelToUpdate.UsersManagementPrivileges = UsersManagementPrivileges;
            userModelToUpdate.EmployeesManagementPrivileges = EmployeesManagementPrivileges;
            userModelToUpdate.StudentsManagementPrivileges = StudentsManagementPrivileges;
            userModelToUpdate.CirclesManagementPrivileges = CirclesManagementPrivileges;
            userModelToUpdate.ProgramsManagementPrivileges = ProgramsManagementPrivileges;
            userModelToUpdate.ReportsManagementPrivileges = ReportsManagementPrivileges;

        }

        [ObservableProperty]
        [Required(ErrorMessage = "حقل مطلوب")]
        [NotifyDataErrorInfo]
        [NotifyPropertyChangedFor(nameof(IsValid))]
        private string _userName;

        [ObservableProperty]
        [Required(ErrorMessage = "حقل مطلوب")]
        [NotifyDataErrorInfo]
        [NotifyPropertyChangedFor(nameof(IsValid))]
        private string _password;

        [ObservableProperty]
        [Required(ErrorMessage = "حقل مطلوب")]
        [NotifyDataErrorInfo]
        [NotifyPropertyChangedFor(nameof(IsValid))]
        private bool _isActive;

        public Privileges UsersManagementPrivileges { get; private set; } = new Privileges();
        public Privileges EmployeesManagementPrivileges { get; private set; } = new Privileges();
        public Privileges StudentsManagementPrivileges { get; private set; } = new Privileges();
        public Privileges CirclesManagementPrivileges { get; private set; } = new Privileges();
        public Privileges ProgramsManagementPrivileges { get; private set; } = new Privileges();
        public Privileges ReportsManagementPrivileges { get; private set; } = new Privileges();
    }
}
