using CommunityToolkit.Mvvm.Messaging;
using Halaqat.Shared.Commands;
using Halaqat.Shared.Models;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Halaqat.Features.Students.CommandHandlers
{
    internal class ShowCreateStudentCommandHandler(IServiceProvider services) : IRequestHandler<Common.ShowCreateModelViewCommand<Student>>
    {
        public Task Handle(Common.ShowCreateModelViewCommand<Student> request, CancellationToken cancellationToken)
        {
            IMediator mediator = services.GetRequiredService<IMediator>();
            IMessenger messenger = services.GetRequiredService<IMessenger>();
            Editor.CreateViewModel viewModel = new Editor.CreateViewModel(mediator, messenger);
            Editor.View view = new Editor.View(viewModel, messenger);
            view.ShowDialog();
            return Task.CompletedTask;
        }
    }
}
