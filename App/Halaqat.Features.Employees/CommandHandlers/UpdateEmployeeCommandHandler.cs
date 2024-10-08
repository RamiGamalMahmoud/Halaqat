using Halaqat.Shared;
using Halaqat.Shared.Commands;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Halaqat.Features.Employees.CommandHandlers
{
    internal class UpdateEmployeeCommandHandler(Repository repository) : IRequestHandler<Common.UpdateModelCommand<EmployeeViewModel>, Result>
    {
        public async Task<Result> Handle(Common.UpdateModelCommand<EmployeeViewModel> request, CancellationToken cancellationToken)
        {
            return await repository.Update(request.DataModel);
        }
    }
}
