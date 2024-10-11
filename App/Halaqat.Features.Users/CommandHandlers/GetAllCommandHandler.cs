using Halaqat.Shared.Commands;
using Halaqat.Shared.Models;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Halaqat.Features.Users.CommandHandlers
{
    internal class GetAllCommandHandler(Repository repository) : IRequestHandler<Shared.Commands.Common.GetAllCommand<User>, IEnumerable<User>>
    {
        public async Task<IEnumerable<User>> Handle(Common.GetAllCommand<User> request, CancellationToken cancellationToken)
        {
            return await repository.GetAll(request.Reload);
        }
    }
}
