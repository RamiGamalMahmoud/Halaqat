using Halaqat.Shared.Abstraction.MainWindow;
using System.Windows;

namespace Halaqat.MainWindow
{
    internal partial class View : Window, IMainWindowView
    {
        private readonly ViewModel _viewModel;

        public View(ViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
            _viewModel = viewModel;
            Loaded += View_Loaded;
        }

        private async void View_Loaded(object sender, RoutedEventArgs e)
        {
            await Dispatcher.Invoke(_viewModel.Load);
        }

        private void ListBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }
    }
}
