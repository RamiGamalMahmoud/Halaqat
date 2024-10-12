using CommunityToolkit.Mvvm.ComponentModel;

namespace Halaqat.Shared.Models
{
    [ObservableObject]
    public partial class Appreciation : ModelBase
    {
        [ObservableProperty]
        private string _name;
    }
}
