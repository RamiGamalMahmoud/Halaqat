using Halaqat.Shared.Abstraction.MainWindow;
using Microsoft.Extensions.Logging;
using System.Windows;

namespace Halaqat.MainWindow
{
    internal partial class View : Window, IMainWindowView
    {
        public View(ViewModel viewModel, ILogger logger)
        {
            InitializeComponent();
            logger.Log(LogLevel.Information, this.ToString());
            DataContext = viewModel;
        }

        private void ListBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }
    }
}
