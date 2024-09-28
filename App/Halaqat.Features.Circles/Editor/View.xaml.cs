using CommunityToolkit.Mvvm.Messaging;
using Halaqat.Shared.Models;
using System.Windows;

namespace Halaqat.Features.Circles.Editor
{
    internal partial class View : Window
    {
        public View(ViewModel viewModel, IMessenger messenger)
        {
            InitializeComponent();
            DataContext = viewModel;

            messenger.Register<Shared.Messages.Common.EntityCreatedMessage<Circle>>(this, (r, m) => Close());
            messenger.Register<Shared.Messages.Common.EntityUpdatedMessage<Circle>>(this, (r, m) => Close());
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            await Dispatcher.Invoke((DataContext as ViewModel).LoadDataAsync);
        }
    }
}
