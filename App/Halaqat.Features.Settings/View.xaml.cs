using Halaqat.Shared;
using Halaqat.Shared.Abstraction.Features.Settings;
using System.Windows.Controls;

namespace Halaqat.Features.Settings
{
    internal partial class View : UserControl, ISettingsView
    {
        public View(ISettingsVewModel settingsVewModel)
        {
            InitializeComponent();
            _viewModel = settingsVewModel as ViewModel;
            DataContext = _viewModel;
        }

        private readonly ViewModel _viewModel;
    }
}
