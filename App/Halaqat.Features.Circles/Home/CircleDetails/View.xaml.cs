using System.Windows;

namespace Halaqat.Features.Circles.Home.CircleDetails
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
