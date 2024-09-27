using CommunityToolkit.Mvvm.ComponentModel;

namespace Halaqat.Shared.Models
{
    [ObservableObject]
    public partial class Phone : ModelBase
    {
        [ObservableProperty]
        private string _number;
    }
}
