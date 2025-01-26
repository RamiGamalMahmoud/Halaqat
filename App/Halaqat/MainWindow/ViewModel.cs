using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using Halaqat.Resources;
using Halaqat.Shared;
using Halaqat.Shared.Models;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Halaqat.MainWindow
{
    internal partial class ViewModel : ObservableObject
    {
        public ViewModel(IServiceProvider serviceProvider, IMediator mediator, IMessenger messenger)
        {
            _serviceProvider = serviceProvider;
            _mediator = mediator;
            _messenger = messenger;
        }

        partial void OnViewItemChanged(ViewItem oldValue, ViewItem newValue)
        {
            if (newValue is null || newValue.Action is null)
            {
                CurrentView = new EmptyView() { Text = newValue is null ? "| محتوى غير موجود |" : $"| {newValue.Title} |" };
                return;
            }
            newValue.Action?.Invoke();
        }

        private void SetCurrentView(Type viewType)
        {
            CurrentView = viewType is null ? new EmptyView() : _serviceProvider.GetRequiredService(viewType);

        }

        public async Task Load()
        {
            User loggedInUser = _messenger.Send(new Shared.Messages.Users.LoggedInUserRequestMessage()).Response;
            UserName = loggedInUser.UserName;
            Shared.Models.Teacher teacher = (await _mediator.Send(new Shared.Commands.Teachers.GetLoggedInTeacherCommand(loggedInUser.Id))).Value;

            ViewItems.Add(new ViewItem("إدارة", () => SetCurrentView(typeof(Shared.Abstraction.Features.Employees.IHomeView)), loggedInUser.EmployeesManagementPrivileges.CanRead));
            ViewItems.Add(new ViewItem("الطلبة", () => SetCurrentView(typeof(Shared.Abstraction.Features.Students.IHomeView)), loggedInUser.StudentsManagementPrivileges.CanRead));
            ViewItems.Add(new ViewItem("الحلقات", () => SetCurrentView(typeof(Shared.Abstraction.Features.Circles.IHomeView)), loggedInUser.CirclesManagementPrivileges.CanRead));
            ViewItems.Add(new ViewItem("البرامج", () => SetCurrentView(typeof(Shared.Abstraction.Features.Programs.IHomeView)), loggedInUser.ProgramsManagementPrivileges.CanRead));
            ViewItems.Add(new ViewItem("المستخدمين", () => SetCurrentView(typeof(Shared.Abstraction.Features.Users.IHomeView)), loggedInUser.UsersManagementPrivileges.CanRead));
            ViewItems.Add(new ViewItem("الإعدادات", () => SetCurrentView(typeof(Shared.Abstraction.Features.Settings.ISettingsView)), loggedInUser.HasSettingsPrivileges));
            ViewItems.Add(new ViewItem(" المعلم", () => SetCurrentView(typeof(Teachers.View)), teacher is not null));
            ViewItems.Add(new ViewItem("خروج", () => _messenger.Send<Messages.Users.LogoutMessage>()));
        }

        [ObservableProperty]
        private bool _userIsATeacher;

        [ObservableProperty]
        private object _currentView;

        [ObservableProperty]
        private ViewItem _viewItem;
        public ObservableCollection<ViewItem> ViewItems { get; } = new ObservableCollection<ViewItem>();

        private readonly IServiceProvider _serviceProvider;
        private readonly IMediator _mediator;
        private readonly IMessenger _messenger;

        public string UserName { get; private set; }
    }
}
