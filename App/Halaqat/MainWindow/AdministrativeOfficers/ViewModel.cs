using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using Halaqat.Resources;
using Halaqat.Shared;
using Halaqat.Shared.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Halaqat.MainWindow.AdministrativeOfficers
{
    internal partial class ViewModel : ObservableObject
    {
        public ViewModel(IServiceProvider serviceProvider, IMessenger messenger)
        {
            User user = messenger.Send(new Shared.Messages.Users.LoggedInUserRequestMessage()).Response;
            UserName = user.UserName;
            IEnumerable<ViewItem> viewItems = new ObservableCollection<ViewItem>()
            {
                new ViewItem(
                    "إدارة",
                    user.EmployeesManagementPrivileges.CanRead,
                    () => SetCurrentView(typeof(Shared.Abstraction.Features.Employees.IHomeView))),
                new ViewItem(
                    "الطلبة",
                    user.StudentsManagementPrivileges.CanRead,
                    () => SetCurrentView(typeof(Shared.Abstraction.Features.Students.IHomeView))),
                new ViewItem(
                    "الحلقات",
                    user.CirclesManagementPrivileges.CanRead,
                    () => SetCurrentView(typeof(Shared.Abstraction.Features.Circles.IHomeView))),
                new ViewItem(
                    "البرامج",
                    user.ProgramsManagementPrivileges.CanRead,
                    () => SetCurrentView(typeof(Shared.Abstraction.Features.Programs.IHomeView))),
                //new ViewItem("التقارير", user.HasReportsPrivileges),
                //new ViewItem("الماليات", user.HasFinancePrivileges),
                new ViewItem(
                    "المستخدمين",
                    user.UsersManagementPrivileges.CanRead,
                    () => SetCurrentView(typeof(Shared.Abstraction.Features.Users.IHomeView))),
                new ViewItem(
                    "الإعدادات",
                    user.HasSettingsPrivileges,
                    () => SetCurrentView(typeof(Shared.Abstraction.Features.Settings.ISettingsView))),
                new ViewItem("خروج",
                true,
                () => messenger.Send<Messages.Users.LogoutMessage>())
            };

            ViewItems = viewItems.Where(x => x.IsEnabled);

            _serviceProvider = serviceProvider;
        }

        public object CurrentView
        {
            get => _currentView;
            private set => SetProperty(ref _currentView, value);
        }
        private object _currentView;

        public IEnumerable<ViewItem> ViewItems { get; }

        partial void OnViewItemChanged(ViewItem oldValue, ViewItem newValue)
        {
            if (newValue is null || newValue.Action is null)
            {
                CurrentView = new EmptyView() { Text = newValue is null ? "| محتوى غير موجود |" : $"| {newValue.Title} |" };
                return;
            }
            newValue.Action.Invoke();
        }

        private void SetCurrentView(Type type)
        {
            if (type is null)
            {
                CurrentView = new EmptyView();
            }
            CurrentView = _serviceProvider.GetRequiredService(type);
        }

        [ObservableProperty]
        private ViewItem _viewItem;
        private readonly IServiceProvider _serviceProvider;

        public string UserName { get; private set; }
    }
}
