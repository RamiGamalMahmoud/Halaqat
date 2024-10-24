using CommunityToolkit.Mvvm.Messaging;
using Halaqat.Shared.Commands;
using Halaqat.Shared.Models;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Halaqat.Features.Management.Cities.CommandHandlers
{
    internal class ShowEditCommandHandler(IServiceProvider services) : IRequestHandler<Shared.Commands.Common.ShowEditModelViewCommand<City>>
    {
        public Task Handle(Common.ShowEditModelViewCommand<City> request, CancellationToken cancellationToken)
        {
            IMediator mediator = services.GetRequiredService<IMediator>();
            IMessenger messenger = services.GetRequiredService<IMessenger>();

            Editory.ViewModel viewModel = new Editory.UpdateViewModel(mediator, messenger, request.Model);
            Editory.View view = new Editory.View(viewModel);
            view.ShowDialog();
            return Task.CompletedTask;
        }
    }
}
