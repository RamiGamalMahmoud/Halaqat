using Halaqat.Shared.Commands;
using Halaqat.Shared.Models;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Halaqat.Features.Employees.Teachers.CommandHandlers
{
    internal class GetAllCommandHandler(Repository repository) : IRequestHandler<Shared.Commands.Common.GetAllCommand<Teacher>, IEnumerable<Teacher>>
    {
        public async Task<IEnumerable<Teacher>> Handle(Common.GetAllCommand<Teacher> request, CancellationToken cancellationToken)
        {
            return await repository.GetAll(request.Reload);
        }
    }
}
