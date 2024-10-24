using CommunityToolkit.Mvvm.Messaging;
using Halaqat.Shared;
using Halaqat.Shared.Models;
using MediatR;
using System.Threading.Tasks;

namespace Halaqat.Features.Management.AcademicQualifications.Editor
{
    internal class CreateViewModel(IMediator mediator, IMessenger messenger) : ViewModel(mediator, messenger, null)
    {
        protected override async Task Save()
        {
            Result<AcademicQualification> result = await _mediator.Send(new Shared.Commands.Common.CreateModelCommand<AcademicQualification, AcademicQualificationDataModel>(DataModel));
            if (result.IsSuccess)
            {
                _messenger.Send(new Shared.Messages.Common.EntityCreatedMessage<AcademicQualification>(result.Value));
                _messenger.Send(new Shared.Messages.Notifications.SuccessNotification());
            }
            else
            {
                _messenger.Send(new Shared.Messages.Notifications.FailureNotification());
            }
        }
    }
}
