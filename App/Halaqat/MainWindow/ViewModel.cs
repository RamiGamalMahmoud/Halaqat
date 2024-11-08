using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using Halaqat.Shared.Models;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace Halaqat.MainWindow
{
    internal partial class ViewModel : ObservableObject
    {
        public ViewModel(IServiceProvider serviceProvider, IMediator mediator, IMessenger messenger)
        {
            User user = messenger.Send(new Shared.Messages.Users.LoggedInUserRequestMessage()).Response;
            UserName = user.UserName;

            _serviceProvider = serviceProvider;
            _mediator = mediator;
            _messenger = messenger;
        }

        public async Task Load()
        {
            User user = _messenger.Send(new Shared.Messages.Users.LoggedInUserRequestMessage()).Response;
            Shared.Models.Teacher teacher = (await _mediator.Send(new Shared.Commands.Teachers.GetLoggedInTeacherCommand(user.Id))).Value;
            if (teacher is not null)
            {
                Dashboard = _serviceProvider.GetRequiredService<Teachers.View>();
                return;
            }
            Dashboard = _serviceProvider.GetRequiredService<AdministrativeOfficers.View>();
        }

        public object Dashboard
        {
            get => _currentView;
            private set => SetProperty(ref _currentView, value);
        }
        private object _currentView;

        private readonly IServiceProvider _serviceProvider;
        private readonly IMediator _mediator;
        private readonly IMessenger _messenger;

        public string UserName { get; private set; }
    }
}
