using CommunityToolkit.Mvvm.ComponentModel;

namespace Halaqat.Shared.Models
{
    [ObservableObject]
    public partial class Gender : ModelBase
    {
        [ObservableProperty]
        private string _name;
    }
}
