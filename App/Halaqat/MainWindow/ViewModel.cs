using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Halaqat.Resources;
using Halaqat.Shared;
using Halaqat.Shared.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Halaqat.MainWindow
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
                    () => SetCurrentView(typeof(Shared.Abstraction.Features.Employees.IHomeView)),
                    user.EmployeesManagementPrivileges.CanRead),
                new ViewItem(
                    "الطلبة",
                    () => SetCurrentView(typeof(Shared.Abstraction.Features.Students.IHomeView)),
                    user.StudentsManagementPrivileges.CanRead),
                new ViewItem(
                    "الحلقات",
                    () => SetCurrentView(typeof(Shared.Abstraction.Features.Circles.IHomeView)),
                    user.CirclesManagementPrivileges.CanRead),
                new ViewItem(
                    "البرامج",
                    () => SetCurrentView(typeof(Shared.Abstraction.Features.Programs.IHomeView)),
                    user.ProgramsManagementPrivileges.CanRead),
                new ViewItem("التقارير"),
                new ViewItem("الماليات"),
                new ViewItem(
                    "المستخدمين",
                    () => SetCurrentView(typeof(Shared.Abstraction.Features.Users.IHomeView)),
                    user.UsersManagementPrivileges.CanRead),
                new ViewItem(
                    "الإعدادات",
                    () => SetCurrentView(typeof(Shared.Abstraction.Features.Settings.ISettingsView)),
                    true),
                new ViewItem("خروج",
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
                CurrentView = new EmptyView() { Text = newValue.Title };
                return;
            }
            newValue.Action.Invoke();
        }

        private void SetCurrentView(Type type)
        {
            if(type is null)
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

    record ViewItem(string Title, Action Action = null, bool IsEnabled = true);
}
