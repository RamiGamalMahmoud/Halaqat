using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Halaqat.Resources;
using Halaqat.Shared.Models;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Halaqat.MainWindow.Teachers
{
    internal partial class ViewModel : ObservableObject
    {
        private readonly User _user;
        private readonly IMediator _mediator;
        private readonly IMessenger _messenger;

        public ViewModel(IMediator mediator, IMessenger messenger, IServiceProvider serviceProvider)
        {
            _user = messenger.Send(new Shared.Messages.Users.LoggedInUserRequestMessage()).Response;
            _serviceProvider = serviceProvider;
            _mediator = mediator;
            _messenger = messenger;
        }

        public async Task LoadData()
        {
            Teacher = (await _mediator.Send(new Shared.Commands.Teachers.GetLoggedInTeacherCommand(_user.Id))).Value;
        }

        partial void OnCircleChanged(Circle oldValue, Circle newValue)
        {
            if (newValue is null)
            {
                Students = Teacher.Circles.SelectMany(x => x.Students);
            }
            else
            {
                Students = Circle.Students.ToList();
            }
        }

        [ObservableProperty]
        private Circle _circle;

        [ObservableProperty]
        private IEnumerable<Student> _students;

        [RelayCommand]
        private async Task ShowStudentMemorizingAndReviewTable(Student student)
        {
            await _mediator.Send(new Shared.Commands.MemorizingAndReviewCommands.ShowMemorizingAndReviewViewCommand(student, Teacher));
        }

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
        private readonly IServiceProvider _serviceProvider;

        public object CurrentView
        {
            get => _currentView;
            private set => SetProperty(ref _currentView, value);
        }
        private object _currentView;

        public Teacher Teacher
        {
            get => _teacher;
            private set => SetProperty(ref _teacher, value);
        }
        private Teacher _teacher;
        public IEnumerable<ViewItem> ViewItems { get; }

        [ObservableProperty]
        private ViewItem _viewItem;
    }
}
