using CommunityToolkit.Mvvm.Messaging;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading;
using System.Threading.Tasks;
using static Halaqat.Shared.Commands.MemorizingAndReviewCommands;

namespace Halaqat.Features.MemorizingAndReview.CommandHandlers
{
    internal class ShowStudentMemorizingReviewTableCommandHandler(IServiceProvider services) : IRequestHandler<ShowMemorizingAndReviewViewCommand>
    {
        public Task Handle(ShowMemorizingAndReviewViewCommand request, CancellationToken cancellationToken)
        {
            IMediator mediator = services.GetRequiredService<IMediator>();
            IMessenger messenger = services.GetRequiredService<IMessenger>();
            ViewModel viewModel = new ViewModel(request.Student, request.Teacher, mediator, messenger);
            View view = new View(viewModel);
            view.Show();
            return Task.CompletedTask;
        }
    }
}
