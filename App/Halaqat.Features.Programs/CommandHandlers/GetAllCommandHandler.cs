using Halaqat.Shared.Commands;
using Halaqat.Shared.Models;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Halaqat.Features.Programs.CommandHandlers
{
    internal class GetAllCommandHandler(Repository repository) : IRequestHandler<Shared.Commands.Common.GetAllCommand<Program>, IEnumerable<Program>>
    {
        public Task<IEnumerable<Program>> Handle(Common.GetAllCommand<Program> request, CancellationToken cancellationToken)
        {
            return repository.GetAll(request.Reload);
        }
    }
}
