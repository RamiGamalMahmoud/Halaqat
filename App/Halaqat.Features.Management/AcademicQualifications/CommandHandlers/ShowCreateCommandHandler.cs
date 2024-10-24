using CommunityToolkit.Mvvm.Messaging;
using Halaqat.Features.Management.AcademicQualifications.Editor;
using Halaqat.Shared.Commands;
using Halaqat.Shared.Models;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Halaqat.Features.Management.AcademicQualifications.CommandHandlers
{
    internal class ShowCreateCommandHandler(IServiceProvider services) : IRequestHandler<Shared.Commands.Common.ShowCreateModelViewCommand<AcademicQualification>>
    {
        public Task Handle(Common.ShowCreateModelViewCommand<AcademicQualification> request, CancellationToken cancellationToken)
        {
            IMediator mediator = services.GetRequiredService<IMediator>();
            IMessenger messenger = services.GetRequiredService<IMessenger>();

            ViewModel viewModel = new CreateViewModel(mediator, messenger);
            View view = new View(viewModel, messenger);
            view.ShowDialog();

            return Task.CompletedTask;
        }
    }
}
