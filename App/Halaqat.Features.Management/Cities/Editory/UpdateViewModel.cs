using CommunityToolkit.Mvvm.Messaging;
using Halaqat.Shared;
using Halaqat.Shared.Models;
using MediatR;
using System.Threading.Tasks;

namespace Halaqat.Features.Management.Cities.Editory
{
    internal class UpdateViewModel(IMediator mediator, IMessenger messenger, City model) : ViewModel(mediator, messenger, model)
    {
        protected override async Task Save()
        {
            Result result = await _mediator.Send(new Shared.Commands.Common.UpdateModelCommand<CityDataModel>(DataModel));
            if (result.IsSuccess)
            {
                _messenger.Send(new Shared.Messages.Common.EntityUpdatedMessage<City>());
                _messenger.Send(new Shared.Messages.Notifications.SuccessNotification());
            }
            else
            {
                _messenger.Send(new Shared.Messages.Notifications.FailureNotification());
            }
        }
    }
}
