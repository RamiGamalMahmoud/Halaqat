using Halaqat.Shared.Models;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Halaqat.Features.Employees.CommandHandlers
{
    internal class GetTeachersCommandHandlers(Repository repository) : IRequestHandler<Shared.Commands.Employees.GetTeachersCommand, IEnumerable<Employee>>
    {
        public Task<IEnumerable<Employee>> Handle(Shared.Commands.Employees.GetTeachersCommand request, CancellationToken cancellationToken)
        {
            return repository.GetTeachers();
        }
    }
}
