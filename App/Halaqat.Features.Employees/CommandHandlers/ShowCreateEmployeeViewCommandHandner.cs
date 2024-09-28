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
    internal class ShowCreateEmployeeViewCommandHandner(IServiceProvider services) : IRequestHandler<Common.ShowCreateModelViewCommand<Employee>>
    {
        public Task Handle(Common.ShowCreateModelViewCommand<Employee> request, CancellationToken cancellationToken)
        {
            IMessenger messenger = services.GetRequiredService<IMessenger>();
            EditorViewModelBase viewModel = services.GetRequiredService<CreateViewModel>();
            View view = new View(viewModel, messenger);
            view.ShowDialog();
            return Task.CompletedTask;
        }
    }
}
