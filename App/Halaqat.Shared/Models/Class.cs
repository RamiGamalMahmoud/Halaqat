using CommunityToolkit.Mvvm.ComponentModel;

namespace Halaqat.Shared.Models
{
    [ObservableObject]
    public partial class Class : ModelBase
    {
        [ObservableProperty]
        private string _name;

        [ObservableProperty]
        private EducationalStage _educationalStage;
    }
}
