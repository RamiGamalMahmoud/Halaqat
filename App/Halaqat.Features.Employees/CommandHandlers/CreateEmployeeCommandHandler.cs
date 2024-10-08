using Halaqat.Shared;
using Halaqat.Shared.Commands;
using Halaqat.Shared.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Halaqat.Features.Employees.CommandHandlers
{
    internal class CreateEmployeeCommandHandler(Repository repository) : IRequestHandler<Common.CreateModelCommand<Employee, EmployeeViewModel>, Result<Employee>>
    {
        public async Task<Result<Employee>> Handle(Common.CreateModelCommand<Employee, EmployeeViewModel> request, CancellationToken cancellationToken)
        {
            return await repository.Create(request.DataModel);
        }
    }
}
