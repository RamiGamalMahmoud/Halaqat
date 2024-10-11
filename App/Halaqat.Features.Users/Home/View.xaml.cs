using System.Windows.Controls;

namespace Halaqat.Features.Users.Home
{
    internal partial class View : UserControl, Shared.Abstraction.Features.Users.IHomeView
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
