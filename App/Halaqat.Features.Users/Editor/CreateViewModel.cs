using CommunityToolkit.Mvvm.Messaging;
using Halaqat.Shared;
using Halaqat.Shared.Models;
using MediatR;
using System.Threading.Tasks;

namespace Halaqat.Features.Users.Editor
{
    internal class CreateViewModel(IMediator mediator, IMessenger messenger) : ViewModel(mediator, messenger, null)
    {
        protected override async Task Save()
        {
            Result<User> result = await _mediator.Send(new Shared.Commands.Common.CreateModelCommand<User, UserDataModel>(DataModel));
            if(result.IsSuccess)
            {

            }
            else
            {

            }
        }
    }
}
