using System.Windows.Controls;

namespace Halaqat.Features.Management.Homde
{
    internal partial class View : UserControl, Shared.Abstraction.Features.Management.IHomeView
    {
        public View(ViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
