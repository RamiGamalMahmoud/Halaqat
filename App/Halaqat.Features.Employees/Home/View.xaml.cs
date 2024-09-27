using Halaqat.Shared.Abstraction.Features.Employees;
using System.Windows.Controls;

namespace Halaqat.Features.Employees.Home
{
    internal partial class View : UserControl, IHomeView
    {
        private readonly ViewModel _viewModel;

        public View(ViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;

            _viewModel = viewModel;
        }

        private async void View_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            await Dispatcher.Invoke(async () => await _viewModel.LoadDataAsync(false));
        }

        private void DataGrid_LostFocus(object sender, System.Windows.RoutedEventArgs e)
        {
            //(sender as DataGrid).SelectedItem = null;
        }
    }
}
