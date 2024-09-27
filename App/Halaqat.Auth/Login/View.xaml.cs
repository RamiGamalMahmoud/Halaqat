using Halaqat.Shared.Abstraction.Features.Auth;
using System.Windows;

namespace Halaqat.Auth.Login
{
    internal partial class View : Window, ILoginView
    {
        public View(ViewModel viewModel)
        {
            InitializeComponent();

            DataContext = viewModel;
        }
    }
}
