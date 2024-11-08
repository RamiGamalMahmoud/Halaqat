using System.Windows.Controls;

namespace Halaqat.MainWindow.AdministrativeOfficers
{
    internal partial class View : UserControl
    {
        public View(ViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
