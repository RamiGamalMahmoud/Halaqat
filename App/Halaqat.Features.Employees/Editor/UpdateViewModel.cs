using CommunityToolkit.Mvvm.Messaging;
using Halaqat.Shared;
using Halaqat.Shared.Models;
using MediatR;
using System.Threading.Tasks;

namespace Halaqat.Features.Employees.Editor
{
    internal class UpdateViewModel : EditorViewModelBase
    {
        public UpdateViewModel(IMediator mediator, IMessenger messenger, Employee model) : base(mediator, messenger, model)
        {
        }

        protected override async Task Save()
        {
            Result result = await _mediator.Send(new Shared.Commands.Common.UpdateModelCommand<EmployeeViewModel>(DataModel));

            if(result.IsSuccess)
            {
                _messenger.Send(new Shared.Messages.Common.EntityUpdatedMessage<Employee>());
                _messenger.Send(new Shared.Messages.Notifications.SuccessNotification());
            }
            else
            {
                _messenger.Send(new Shared.Messages.Notifications.FailureNotification());
            }
        }
    }
}
