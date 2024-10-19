using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using Halaqat.Resources;
using Halaqat.Shared.Abstraction;
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
                new ViewItem("إدارة", typeof(Shared.Abstraction.Features.Employees.IHomeView), user.EmployeesManagementPrivileges.CanRead),
                new ViewItem("الطلبة", typeof(Shared.Abstraction.Features.Students.IHomeView), user.StudentsManagementPrivileges.CanRead),
                new ViewItem("الحلقات", typeof(Shared.Abstraction.Features.Circles.IHomeView), user.CirclesManagementPrivileges.CanRead),
                new ViewItem("البرامج", typeof(Shared.Abstraction.Features.Programs.IHomeView), user.ProgramsManagementPrivileges.CanRead),
                new ViewItem("التقارير", typeof(object), user.ReportsManagementPrivileges.CanRead),
                new ViewItem("الماليات", typeof(object), user.UsersManagementPrivileges.CanRead),
                new ViewItem("المستخدمين", typeof(Shared.Abstraction.Features.Users.IHomeView), user.UsersManagementPrivileges.CanRead),
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
            if (newValue.View.GetInterface(nameof(IView)) is null)
            {
                CurrentView = new EmptyView() { Text = newValue.Title };
                return;
            }
            CurrentView = _serviceProvider.GetRequiredService(newValue.View);
        }

        [ObservableProperty]
        private ViewItem _viewItem;
        private readonly IServiceProvider _serviceProvider;

        public string UserName { get; private set; }
    }

    record ViewItem(string Title, Type View, bool IsEnabled);
}
