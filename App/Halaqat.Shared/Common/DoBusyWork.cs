using CommunityToolkit.Mvvm.ComponentModel;

namespace Halaqat.Shared.Common
{
    public partial class DoBusyWork : ObservableObject
    {
        [ObservableProperty]
        private bool _isBusy;
    }
}
