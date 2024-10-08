using Halaqat.Shared.Commands;
using Halaqat.Shared.Models;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Halaqat.Features.Programs.CommandHandlers
{
    internal class GetAllSorahsCommandHandler(Repository repository) : IRequestHandler<Shared.Commands.Common.GetAllCommand<Sorah>, IEnumerable<Sorah>>
    {
        public async Task<IEnumerable<Sorah>> Handle(Common.GetAllCommand<Sorah> request, CancellationToken cancellationToken)
        {
            return await repository.GetSorahs();
        }
    }
}
