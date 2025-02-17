using System.Windows.Controls;
using Halaqat.Shared.Abstraction.Features.Circles;

namespace Halaqat.Features.Circles.Home
{
    internal partial class View : UserControl, IHomeView
    {
        public View(ViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }

        private async void UserControl_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            if (!_loaded)
            {
                await Dispatcher.Invoke(() => (DataContext as ViewModel).LoadDataCommand.ExecuteAsync(false));
                _loaded = true;
            }
        }

        private void DataGrid_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex() + 1).ToString();
        }

        private bool _loaded;
    }
}
