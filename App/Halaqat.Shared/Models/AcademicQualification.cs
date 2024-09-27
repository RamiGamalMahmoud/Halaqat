using CommunityToolkit.Mvvm.ComponentModel;

namespace Halaqat.Shared.Models
{
    [ObservableObject]
    public partial class AcademicQualification : ModelBase
    {
        [ObservableProperty]
        private string _name;
    }
}
