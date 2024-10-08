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
            PreviewKeyDown += (s, e) => { if (e.Key == System.Windows.Input.Key.Escape) Close(); };

            messenger.Register<Shared.Messages.Common.EntityCreatedMessage<Circle>>(this, (r, m) => Close());
            messenger.Register<Shared.Messages.Common.EntityUpdatedMessage<Circle>>(this, (r, m) => Close());
            _viewModel = viewModel;
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            await Dispatcher.Invoke((DataContext as ViewModel).LoadDataAsync);
        }

        private readonly ViewModel _viewModel;

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            //_viewModel.StudentsChanged();
        }
    }
}
