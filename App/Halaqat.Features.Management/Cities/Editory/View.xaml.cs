using System.Windows;

namespace Halaqat.Features.Management.Cities.Editory
{
    internal partial class View : Window
    {
        public View(ViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
