using Halaqat.Shared.Commands;
using Halaqat.Shared.Models;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Halaqat.Features.Management.Nationalities.CommandHandlers
{
    internal class GetAllCommandHandler(Repository repository) : IRequestHandler<Shared.Commands.Common.GetAllCommand<Nationality>, IEnumerable<Nationality>>
    {
        public async Task<IEnumerable<Nationality>> Handle(Common.GetAllCommand<Nationality> request, CancellationToken cancellationToken)
        {
            return await repository.GetAll(request.Reload);
        }
    }
}
