using CommunityToolkit.Mvvm.Messaging;
using Halaqat.Shared;
using Halaqat.Shared.Models;
using MediatR;
using System.Threading.Tasks;

namespace Halaqat.Features.Management.AcademicQualifications.Editor
{
    internal class UpdateViewModel(IMediator mediator, IMessenger messenger, AcademicQualification model) : ViewModel(mediator, messenger, model)
    {
        protected override async Task Save()
        {
            Result result = await _mediator.Send(new Shared.Commands.Common.UpdateModelCommand<AcademicQualificationDataModel>(DataModel));
            if (result.IsSuccess)
            {
                _messenger.Send(new Shared.Messages.Common.EntityUpdatedMessage<AcademicQualification>());
                _messenger.Send(new Shared.Messages.Notifications.SuccessNotification());
            }
            else
            {
                _messenger.Send(new Shared.Messages.Notifications.FailureNotification());
            }
        }
    }
}
