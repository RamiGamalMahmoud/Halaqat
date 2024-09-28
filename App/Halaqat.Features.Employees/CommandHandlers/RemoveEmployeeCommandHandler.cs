using Halaqat.Shared;
using Halaqat.Shared.Commands;
using Halaqat.Shared.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Halaqat.Features.Employees.CommandHandlers
{
    internal class RemoveEmployeeCommandHandler(Repository repository) : IRequestHandler<Common.RemoveModelCommand<Employee>, Result>
    {
        public async Task<Result> Handle(Common.RemoveModelCommand<Employee> request, CancellationToken cancellationToken)
        {
            return await repository.Remove(request.Model);
        }
    }
}
