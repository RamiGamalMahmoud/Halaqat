using Halaqat.Shared.Models;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Halaqat.Features.Employees.CommandHandlers
{

    internal class GetEmployeesByNameCommandHandler(Repository repository) : IRequestHandler<Shared.Commands.Employees.GetByName, IEnumerable<Employee>>
    {
        public async Task<IEnumerable<Employee>> Handle(Shared.Commands.Employees.GetByName request, CancellationToken cancellationToken)
        {
            return await repository.GetByName(request.Name);
        }
    }
}
