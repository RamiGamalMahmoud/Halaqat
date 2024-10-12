using MediatR;
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
            View view = new View();
            view.Show();
            return Task.CompletedTask;
        }
    }
}
