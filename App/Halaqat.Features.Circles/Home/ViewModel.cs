using CommunityToolkit.Mvvm.Messaging;
using Halaqat.Shared.Common;
using Halaqat.Shared.Models;
using MediatR;
using System.Threading.Tasks;

namespace Halaqat.Features.Circles.Home
{
    internal class ViewModel(IMediator mediator, IMessenger messenger) : HomeViewModelBase<Circle>(mediator, messenger)
    {
        public override Task LoadDataAsync(bool isReload)
        {
            return Task.CompletedTask;
        }
    }
}
