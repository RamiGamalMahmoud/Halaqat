using CommunityToolkit.Mvvm.Messaging;
using System.Windows;

namespace Halaqat.Features.Users.Editor
{
    internal partial class View : Window
    {
        public View(ViewModel viewModel, IMessenger messenger)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
