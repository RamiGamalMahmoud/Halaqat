using CommunityToolkit.Mvvm.Messaging;
using Halaqat.Shared;
using Halaqat.Shared.Models;
using MediatR;
using System.Threading.Tasks;

namespace Halaqat.Features.Employees.Editor
{
    internal class CreateViewModel : EditorViewModelBase
    {
        public CreateViewModel(IMediator mediator, IMessenger messenger) : base(mediator, messenger, null)
        {
            EnableJobTitles = true;
        }

        protected override async Task Save()
        {
            if (DataModel.JobTitle.Name == "معلم")
            {
                Result<Teacher> teacherResult = await _mediator.Send(new Shared.Commands.Common.CreateModelCommand<Teacher, EmployeeViewModel>(DataModel));
                if (teacherResult.IsSuccess)
                {
                    _messenger.Send(new Shared.Messages.Common.EntityCreatedMessage<Employee>(teacherResult.Value));
                    _messenger.Send(new Shared.Messages.Notifications.SuccessNotification());
                    return;
                }
            }

            else
            {
                Result<Employee> result = await _mediator.Send(new Shared.Commands.Common.CreateModelCommand<Employee, EmployeeViewModel>(DataModel));
                if (result.IsSuccess)
                {
                    _messenger.Send(new Shared.Messages.Common.EntityCreatedMessage<Employee>(result.Value));
                    _messenger.Send(new Shared.Messages.Notifications.SuccessNotification());
                    return;
                }
            }

            _messenger.Send(new Shared.Messages.Notifications.FailureNotification());
        }
    }
}
