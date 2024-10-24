using System.Windows.Controls;

namespace Halaqat.Features.Management.Cities.Home
{
    internal partial class View : UserControl
    {
        public View(ViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
            Loaded += View_Loaded;
        }

        private async void View_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            await Dispatcher.Invoke(() => (DataContext as ViewModel).LoadDataAsync(false));
        }
    }
}
