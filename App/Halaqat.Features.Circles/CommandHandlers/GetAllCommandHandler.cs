using Halaqat.Shared.Commands;
using Halaqat.Shared.Models;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Halaqat.Features.Circles.CommandHandlers
{
    internal class GetAllCommandHandler(Repository repository) : IRequestHandler<Shared.Commands.Common.GetAllCommand<Circle>, IEnumerable<Circle>>
    {
        public async Task<IEnumerable<Circle>> Handle(Common.GetAllCommand<Circle> request, CancellationToken cancellationToken)
        {
            return await repository.GetAll(request.Reload);
        }
    }
}
