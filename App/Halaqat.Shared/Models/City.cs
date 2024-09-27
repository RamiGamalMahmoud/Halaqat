using CommunityToolkit.Mvvm.ComponentModel;

namespace Halaqat.Shared.Models
{
    [ObservableObject]
    public partial class City : ModelBase
    {
        [ObservableProperty]
        private string _name;
    }
}
