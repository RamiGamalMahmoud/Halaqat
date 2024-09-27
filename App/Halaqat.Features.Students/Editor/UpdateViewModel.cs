using CommunityToolkit.Mvvm.Messaging;
using Halaqat.Shared;
using Halaqat.Shared.Models;
using MediatR;
using System.Threading.Tasks;

namespace Halaqat.Features.Students.Editor
{
    internal class UpdateViewModel(IMediator mediator, IMessenger messenger, Student student) : ViewModel(mediator, messenger, student)
    {
        protected override async Task Save()
        {
            Result result = await _mediator.Send(new Shared.Commands.Common.UpdateModelCommand<StudentDataModel>(DataModel));

            if (result.IsSuccess)
            {
                _messenger.Send(new Shared.Messages.Common.EntityUpdatedMessage<Student>());
                _messenger.Send(new Shared.Messages.Notifications.SuccessNotification());
            }
            else
            {
                _messenger.Send(new Shared.Messages.Notifications.FailureNotification());
            }
        }
    }
}
