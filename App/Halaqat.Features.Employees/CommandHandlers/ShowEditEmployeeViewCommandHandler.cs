using CommunityToolkit.Mvvm.Messaging;
using Halaqat.Features.Employees.Editor;
using Halaqat.Shared.Commands;
using Halaqat.Shared.Models;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Halaqat.Features.Employees.CommandHandlers
{
    internal class ShowEditEmployeeViewCommandHandler(IServiceProvider services) : IRequestHandler<Common.ShowEditModelViewCommand<Employee>>
    {
        public Task Handle(Common.ShowEditModelViewCommand<Employee> request, CancellationToken cancellationToken)
        {
            IMediator mediator = services.GetRequiredService<IMediator>();
            IMessenger messenger = services.GetRequiredService<IMessenger>();
            EditorViewModelBase viewModel = new UpdateViewModel(mediator, messenger, request.Model);
            View view = new View(viewModel, messenger);
            view.ShowDialog();
            return Task.CompletedTask;
        }
    }
}
