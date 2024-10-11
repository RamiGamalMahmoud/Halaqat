using CommunityToolkit.Mvvm.Messaging;
using Halaqat.Shared;
using Halaqat.Shared.Models;
using MediatR;
using System.Threading.Tasks;

namespace Halaqat.Features.Users.Editor
{
    internal class UpdateViewModel(IMediator mediator, IMessenger messenger, User model) : ViewModel(mediator, messenger, model)
    {
        protected override async Task Save()
        {
            Result result = await _mediator.Send(new Shared.Commands.Common.UpdateModelCommand<UserDataModel>(DataModel));

            if(result.IsSuccess)
            {

            }
            else
            {

            }
        }
    }
}
