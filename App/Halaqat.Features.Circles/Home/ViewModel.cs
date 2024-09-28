using CommunityToolkit.Mvvm.Messaging;
using Halaqat.Shared.Common;
using Halaqat.Shared.Models;
using MediatR;
using System.Threading.Tasks;

namespace Halaqat.Features.Circles.Home
{
    internal partial class ViewModel(IMediator mediator, IMessenger messenger) : HomeViewModelBase<Circle>(mediator, messenger)
    {
        public override async Task LoadDataAsync(bool isReload)
        {
            Models = await _mediator.Send(new Shared.Commands.Common.GetAllCommand<Circle>(false));
        }
    }
}
