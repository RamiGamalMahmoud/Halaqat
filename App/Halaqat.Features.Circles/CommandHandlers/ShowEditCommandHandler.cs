using CommunityToolkit.Mvvm.Messaging;
using Halaqat.Features.Circles.Editor;
using Halaqat.Shared.Commands;
using Halaqat.Shared.Models;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Halaqat.Features.Circles.CommandHandlers
{
    internal class ShowEditCommandHandler(IServiceProvider services) : IRequestHandler<Shared.Commands.Common.ShowEditModelViewCommand<Circle>>
    {
        public Task Handle(Common.ShowEditModelViewCommand<Circle> request, CancellationToken cancellationToken)
        {
            IMediator mediator = services.GetRequiredService<IMediator>();
            IMessenger messenger = services.GetRequiredService<IMessenger>();

            ViewModel viewModel = new UpdateViewModel(mediator, messenger, request.Model);
            View view = new View(viewModel, messenger);
            view.ShowDialog();
            return Task.CompletedTask;
        }
    }
}
