using Halaqat.Shared.Abstraction.Features.Settings;
using System.Windows;

namespace Halaqat.Features.Settings.DatabaseConfiguration
{
    internal partial class View : Window, IDatabaseConfigurationView
    {
        public View(ViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
