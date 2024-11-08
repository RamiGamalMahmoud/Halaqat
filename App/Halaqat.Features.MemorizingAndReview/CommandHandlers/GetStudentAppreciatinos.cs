using Halaqat.Shared.Models;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Halaqat.Features.MemorizingAndReview.CommandHandlers
{
    internal static class GetStudentAppreciatinos
    {
        internal record Command(Student Student) : IRequest<IEnumerable<ProgramDay>>;

        internal class Handler(Repository repository) : IRequestHandler<Command, IEnumerable<ProgramDay>>
        {
            public async Task<IEnumerable<ProgramDay>> Handle(Command request, CancellationToken cancellationToken)
            {
                return await repository.GetProgramDayAppreciation(request.Student);
            }
        }
    }
}
