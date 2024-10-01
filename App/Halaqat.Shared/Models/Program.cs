using CommunityToolkit.Mvvm.ComponentModel;

namespace Halaqat.Shared.Models
{
    [ObservableObject]
    public partial class Program : ModelBase
    {
        [ObservableProperty]
        private string _name;

        [ObservableProperty]
        private int _expectedDuration;

        [ObservableProperty]
        private string _notes;
    }
}
