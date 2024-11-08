using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Halaqat.Shared.Common;
using Halaqat.Shared.Models;
using MediatR;
using System.Linq;
using System.Threading.Tasks;

namespace Halaqat.Features.Students.Home
{
    internal partial class ViewModel : Shared.Common.HomeViewModelBase<Student>
    {
        public ViewModel(IMediator mediator, IMessenger messenger) : base(mediator, messenger)
        {
            User = _messenger.Send(new Shared.Messages.Users.LoggedInUserRequestMessage());
            Privileges = _messenger.Send(new Shared.Messages.Users.GetStudentsPrivilegesRequestMessage());
        }

        public override async Task LoadDataAsync(bool isReload)
        {
            using (BusyWorkRunner.CreateBusyWork(DoBusyWork))
            {
                Teacher = (await _mediator.Send(new Shared.Commands.Teachers.GetLoggedInTeacherCommand(User.Id))).Value;
                _all = await _mediator.Send(new Shared.Commands.Common.GetAllCommand<Student>(isReload));
                Models = _all;
            }
        }

        protected override void OnSearch()
        {
            Models = string.IsNullOrEmpty(SearchTerm) ? _all : _all.Where(x => x.Name.Contains(SearchTerm));
        }

        [RelayCommand]
        private async Task ShowMemorizingReport(Student student)
        {
            await _mediator.Send(new Shared.Commands.MemorizingAndReviewCommands.ShowMemorizationBookletReportCommand(student));
        }

        public User User { get => _user; private set => SetProperty(ref _user, value); }
        private User _user;

        public Teacher Teacher { get => _teacher; private set => SetProperty(ref _teacher, value); }
        private Teacher _teacher;

    }
}
