using System.Windows.Controls;

namespace Halaqat.MainWindow.Teachers
{
    internal partial class View : UserControl
    {
        private readonly ViewModel _viewModel;

        public View(ViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
            _viewModel = viewModel;
            Loaded += View_Loaded;
        }

        private async void View_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            await Dispatcher.Invoke(_viewModel.LoadData);
        }
    }
}
