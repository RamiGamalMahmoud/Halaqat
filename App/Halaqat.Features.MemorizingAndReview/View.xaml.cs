using System.Windows;

namespace Halaqat.Features.MemorizingAndReview
{
    internal partial class View : Window
    {
        public View(ViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
            Loaded += View_Loaded;
        }

        private async void View_Loaded(object sender, RoutedEventArgs e)
        {
            await Dispatcher.Invoke(() => (DataContext as ViewModel).LoadDataAsync());
        }
    }
}
