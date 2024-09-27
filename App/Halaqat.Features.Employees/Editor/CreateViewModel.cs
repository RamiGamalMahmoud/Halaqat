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
        }

        protected override async Task Save()
        {
            Result<Employee> result = await _mediator.Send(new Shared.Commands.Common.CreateModelCommand<Employee, EmployeeViewModel>(DataModel));
            if(result.IsSuccess)
            {
                _messenger.Send(new Shared.Messages.Common.EntityCreatedMessage<Employee>(result.Value));
                _messenger.Send(new Shared.Messages.Notifications.SuccessNotification());
            }
            else
            {
                _messenger.Send(new Shared.Messages.Notifications.FailureNotification());
            }
        }
    }
}
