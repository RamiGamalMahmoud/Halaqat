using CommunityToolkit.Mvvm.Messaging;
using Halaqat.Shared.Commands;
using Halaqat.Shared.Models;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Halaqat.Features.Programs.CommandHandlers
{
    internal class ShowEditCommandHandler(IServiceProvider services) : IRequestHandler<Shared.Commands.Common.ShowEditModelViewCommand<Program>>
    {
        public Task Handle(Common.ShowEditModelViewCommand<Program> request, CancellationToken cancellationToken)
        {
            IMediator mediator = services.GetRequiredService<IMediator>();
            IMessenger messenger = services.GetRequiredService<IMessenger>();
            Editor.ViewModel viewModel = new Editor.UpdateViewModel(mediator, messenger, request.Model);
            Editor.View view = new Editor.View(viewModel, messenger);
            view.ShowDialog();
            return Task.CompletedTask;
        }
    }
}
