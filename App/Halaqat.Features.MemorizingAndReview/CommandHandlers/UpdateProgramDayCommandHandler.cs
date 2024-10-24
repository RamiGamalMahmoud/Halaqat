using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Halaqat.Features.MemorizingAndReview.CommandHandlers
{
    internal static class UpdateProgramDay
    {
        public record Command(ProgramDayItemViewModel ProgramDayItemViewModel) : IRequest;
        internal class Handler(Repository repository) : IRequestHandler<Command>
        {
            public async Task Handle(Command request, CancellationToken cancellationToken)
            {
                await repository.Update(request.ProgramDayItemViewModel);
            }
        }
    }
}
