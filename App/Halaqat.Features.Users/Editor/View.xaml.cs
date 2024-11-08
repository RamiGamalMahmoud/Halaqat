using CommunityToolkit.Mvvm.Messaging;
using Halaqat.Shared.Models;
using System.Windows;

namespace Halaqat.Features.Users.Editor
{
    internal partial class View : Window
    {
        public View(ViewModel viewModel, IMessenger messenger)
        {
            InitializeComponent();
            DataContext = viewModel;

            messenger.Register<Shared.Messages.Common.EntityUpdatedMessage<User>>(this, (r, m) => Close());
            messenger.Register<Shared.Messages.Common.EntityCreatedMessage<User>>(this, (r, m) => Close());
        }
    }
}
