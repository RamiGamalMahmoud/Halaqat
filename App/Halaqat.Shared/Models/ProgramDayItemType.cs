using CommunityToolkit.Mvvm.ComponentModel;

namespace Halaqat.Shared.Models
{
    [ObservableObject]
    public partial class ProgramDayItemType : ModelBase
    {
        [ObservableProperty]
        private string _name;
    }
}
