using CommunityToolkit.Mvvm.ComponentModel;

namespace Halaqat.Shared.Models
{
    public partial class Privileges : ObservableObject
    {
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(HasFullPrivileges))]
        private bool _canCreate;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(HasFullPrivileges))]
        private bool _canRead;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(HasFullPrivileges))]
        private bool _canUpdate;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(HasFullPrivileges))]
        private bool _canDelete;

        public bool HasFullPrivileges
        {
            get => CanCreate && CanRead && CanUpdate && CanDelete;
            set
            {
                CanRead = value;
                CanCreate = value;
                CanUpdate = value;
                CanDelete = value;
            }
        }

        partial void OnCanReadChanged(bool oldValue, bool newValue)
        {
            if (newValue is false)
            {
                CanCreate = false;
                CanDelete = false;
                CanUpdate = false;
            }
        }

        partial void OnCanCreateChanged(bool oldValue, bool newValue)
        {
            if (newValue is true)
            {
                CanRead = true;
            }
        }
        partial void OnCanDeleteChanged(bool oldValue, bool newValue)
        {
            if (newValue is true)
            {
                CanRead = true;
            }
        }

        partial void OnCanUpdateChanged(bool oldValue, bool newValue)
        {
            if (newValue is true)
            {
                CanRead = true;
            }
        }
    }
}
