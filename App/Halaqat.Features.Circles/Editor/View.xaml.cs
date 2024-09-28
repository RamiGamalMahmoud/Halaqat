using System.Windows;

namespace Halaqat.Features.Circles.Editor
{
    internal partial class View : Window
    {
        public View(ViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            await Dispatcher.Invoke((DataContext as ViewModel).LoadDataAsync);
        }
    }
}
