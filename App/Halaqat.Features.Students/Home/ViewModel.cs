using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Halaqat.Shared.Common;
using Halaqat.Shared.Models;
using MediatR;
using System.Threading.Tasks;

namespace Halaqat.Features.Students.Home
{
    internal partial class ViewModel : Shared.Common.HomeViewModelBase<Student>
    {
        public ViewModel(IMediator mediator, IMessenger messenger) : base(mediator, messenger)
        {
            User = _messenger.Send(new Shared.Messages.Users.LoggedInUserRequestMessage());
        }

        public override async Task LoadDataAsync(bool isReload)
        {
            using (BusyWorkRunner.CreateBusyWork(DoBusyWork))
            {
                Teacher = (await _mediator.Send(new Shared.Commands.Teachers.GetLoggedInTeacherCommand(User.Id))).Value;
                Models = await _mediator.Send(new Shared.Commands.Common.GetAllCommand<Student>(isReload));
                ShowStudentMemorizingAndReviewTableCommand.NotifyCanExecuteChanged();
            }
        }

        private bool CanShowMemorizingTable(Student student)
        {
            IsEnabled = Teacher is not null && student is not null && Teacher.Circles.Contains(student.Circle);
            return Teacher is not null && student is not null && Teacher.Circles.Contains(student.Circle);
        }

        [ObservableProperty]
        private bool _isEnabled;

        [RelayCommand(CanExecute = nameof(CanShowMemorizingTable))]
        private async Task ShowStudentMemorizingAndReviewTable(Student student)
        {
            await _mediator.Send(new Shared.Commands.MemorizingAndReviewCommands.ShowMemorizingAndReviewViewCommand(student, Teacher));
        }

        async partial void OnSearchTermChanged(string oldValue, string newValue)
        {
            if (newValue is null || string.IsNullOrEmpty(newValue))
            {
                await LoadDataCommand.ExecuteAsync(false);
                return;
            }
            Models = await _mediator.Send(new Shared.Commands.Students.Search(newValue));
        }

        [ObservableProperty]
        private string _searchTerm;

        public User User { get => _user; private set => SetProperty(ref _user, value); }
        private User _user;

        public Teacher Teacher { get => _teacher; private set => SetProperty(ref _teacher, value); }
        private Teacher _teacher;

    }
}
