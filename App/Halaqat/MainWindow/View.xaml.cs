using Halaqat.Shared.Abstraction.MainWindow;
using System.Windows;

namespace Halaqat.MainWindow
{
    internal partial class View : Window, IMainWindowView
    {
        public View(ViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }

        private void ListBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }
    }
}
