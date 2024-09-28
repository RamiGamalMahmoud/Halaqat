using CommunityToolkit.Mvvm.Messaging;
using Halaqat.Shared.Models;
using MediatR;
using System;
using System.Threading.Tasks;

namespace Halaqat.Features.Circles.Editor
{
    internal class UpdateViewModel(IMediator mediator, IMessenger messenger, Circle model) : ViewModel(mediator, messenger, model)
    {
        protected override Task Save()
        {
            throw new NotImplementedException();
        }
    }
}
