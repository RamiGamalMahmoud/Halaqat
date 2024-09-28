using Halaqat.Shared.Models;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Halaqat.Features.Circles.CommandHandlers
{
    internal class SearchCommadnHandler(Repository repository) : IRequestHandler<Shared.Commands.Circles.SearchByName, IEnumerable<Circle>>
    {
        public async Task<IEnumerable<Circle>> Handle(Shared.Commands.Circles.SearchByName request, CancellationToken cancellationToken)
        {
            return await repository.SearchByName(request.Name);
        }
    }
}
