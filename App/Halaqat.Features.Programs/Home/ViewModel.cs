using CommunityToolkit.Mvvm.Messaging;
using Halaqat.Shared.Common;
using Halaqat.Shared.Models;
using MediatR;
using System.Threading.Tasks;

namespace Halaqat.Features.Programs.Home
{
    internal class ViewModel(IMediator mediator, IMessenger messenger) : HomeViewModelBase<Program>(mediator, messenger)
    {
        public override async Task LoadDataAsync(bool isReload)
        {
            Models = await _mediator.Send(new Shared.Commands.Common.GetAllCommand<Program>(isReload));
        }
    }
}
