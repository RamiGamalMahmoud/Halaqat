using Halaqat.Shared;
using Halaqat.Shared.Commands;
using Halaqat.Shared.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Halaqat.Features.Employees.Teachers.CommandHandlers
{
    internal class CreateCommandHandler(Repository repository) : IRequestHandler<Shared.Commands.Common.CreateModelCommand<Teacher, EmployeeViewModel>, Result<Teacher>>
    {
        public async Task<Result<Teacher>> Handle(Common.CreateModelCommand<Teacher, EmployeeViewModel> request, CancellationToken cancellationToken)
        {
            return await repository.Create(request.DataModel);
        }
    }
}
