using System.Windows.Controls;

namespace Halaqat.Features.Students.Home
{
    internal partial class View : UserControl, Shared.Abstraction.Features.Students.IHomeView
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
                await Dispatcher.Invoke(() => (DataContext as ViewModel).LoadDataAsync(false));
                _loaded = true;
            }
        }

        private bool _loaded;

        private void DataGrid_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex() + 1).ToString();
        }
    }
}
