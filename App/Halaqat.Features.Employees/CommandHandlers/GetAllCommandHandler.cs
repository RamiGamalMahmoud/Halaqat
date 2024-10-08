using Halaqat.Shared.Commands;
using Halaqat.Shared.Models;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Halaqat.Features.Employees.CommandHandlers
{
    internal class GetAllCommandHandler(Repository repository) : IRequestHandler<Common.GetAllCommand<Employee>, IEnumerable<Employee>>
    {
        public async Task<IEnumerable<Employee>> Handle(Common.GetAllCommand<Employee> request, CancellationToken cancellationToken)
        {
            return await repository.GetAll(request.Reload);
        }
    }
}
