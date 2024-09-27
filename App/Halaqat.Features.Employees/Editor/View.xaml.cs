using CommunityToolkit.Mvvm.Messaging;
using Halaqat.Shared.Models;
using System.Windows;

namespace Halaqat.Features.Employees.Editor
{
    internal partial class View : Window
    {
        public View(EditorViewModelBase viewModel, IMessenger messenger)
        {
            InitializeComponent();
            DataContext = viewModel;

            messenger.Register<Shared.Messages.Common.EntityCreatedMessage<Employee>>(this, (r, m) => Close());
            messenger.Register<Shared.Messages.Common.EntityUpdatedMessage<Employee>>(this, (r, m) => Close());
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            await (DataContext as EditorViewModelBase).LoadDataAsync();
        }
    }
}
