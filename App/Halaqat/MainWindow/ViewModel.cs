using CommunityToolkit.Mvvm.ComponentModel;
using Halaqat.Resources;
using Halaqat.Shared.Abstraction;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Halaqat.MainWindow
{
    internal partial class ViewModel : ObservableObject
    {
        public ViewModel(IServiceProvider serviceProvider)
        {
            ViewItems = new ObservableCollection<ViewItem>()
            {
                new ViewItem("العاملين", typeof(Shared.Abstraction.Features.Employees.IHomeView)),
                new ViewItem("الطلبة", typeof(Shared.Abstraction.Features.Students.IHomeView)),
                new ViewItem("المستخدمين", typeof(object)),
                new ViewItem("التقارير", typeof(object)),
                new ViewItem("الحلقات", typeof(Shared.Abstraction.Features.Circles.IHomeView)),
                new ViewItem("الماليات", typeof(object)),
            };
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
    }

    record ViewItem(string Title, Type View);
}
