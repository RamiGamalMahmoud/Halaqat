using Halaqat.Shared.Commands;
using Halaqat.Shared.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Halaqat.Features.MemorizingAndReview.CommandHandlers
{
    internal class GetApprecitionsCommandHandler(Repository repository) : IRequestHandler<Shared.Commands.Common.GetAllCommand<Appreciation>, IEnumerable<Appreciation>>
    {
        public async Task<IEnumerable<Appreciation>> Handle(Common.GetAllCommand<Appreciation> request, CancellationToken cancellationToken)
        {
            return await repository.GetAppreciations();
        }
    }
}
