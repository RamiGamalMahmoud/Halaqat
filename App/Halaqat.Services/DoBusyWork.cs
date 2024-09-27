using CommunityToolkit.Mvvm.ComponentModel;

namespace Halaqat.Services
{
    public partial class DoBusyWork : ObservableObject
    {
        [ObservableProperty]
        private bool _isBusy;
    }
}
