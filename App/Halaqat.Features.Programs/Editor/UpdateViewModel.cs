using CommunityToolkit.Mvvm.Messaging;
using Halaqat.Shared;
using Halaqat.Shared.Models;
using MediatR;
using System.Threading.Tasks;

namespace Halaqat.Features.Programs.Editor
{
    internal class UpdateViewModel(IMediator mediator, IMessenger messenger, Program model) : ViewModel(mediator, messenger, model)
    {
        protected override async Task Save()
        {
            Result result = await _mediator.Send(new Shared.Commands.Common.UpdateModelCommand<ProgramDataModel>(DataModel));

            if(result.IsSuccess)
            {
                _messenger.Send(new Shared.Messages.Common.EntityUpdatedMessage<Program>());
                _messenger.Send(new Shared.Messages.Notifications.SuccessNotification());
                HasChangesObject.SetNotHasChanges();
            }
            else
            {
                _messenger.Send(new Shared.Messages.Notifications.FailureNotification());
            }
        }
    }
}
