using System.Windows.Controls;

namespace Halaqat.Features.Programs.Home
{
    internal partial class View : UserControl, Shared.Abstraction.Features.Programs.IHomeView
    {
        public View(ViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
            _viewModel = viewModel;
        }

        private async void UserControl_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            await Dispatcher.Invoke(() => _viewModel.LoadDataAsync(false));
        }

        private readonly ViewModel _viewModel;
    }
}
