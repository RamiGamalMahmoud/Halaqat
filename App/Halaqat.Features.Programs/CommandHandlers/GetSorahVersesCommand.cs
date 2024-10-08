using Halaqat.Shared.Models;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Halaqat.Features.Programs.CommandHandlers
{
    internal static class GetSorahVersesCommand
    {
        public record Command(int SorahId) : IRequest<IEnumerable<Verse>>;

        internal class Handler(Repository repository) : IRequestHandler<Command, IEnumerable<Verse>>
        {
            public async Task<IEnumerable<Verse>> Handle(Command request, CancellationToken cancellationToken)
            {
                return await repository.GetVerses(request.SorahId);
            }
        }
    }
}
