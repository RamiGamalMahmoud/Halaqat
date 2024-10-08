using Halaqat.Shared;
using Halaqat.Shared.Commands;
using Halaqat.Shared.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Halaqat.Features.Students.CommandHandlers
{
    internal class RemoveStudentCommandHandler(Repository repository) : IRequestHandler<Common.RemoveModelCommand<Student>, Result>
    {
        public async Task<Result> Handle(Common.RemoveModelCommand<Student> request, CancellationToken cancellationToken)
        {
            return await repository.Remove(request.Model);
        }
    }
}
