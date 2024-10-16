using Halaqat.Shared;
using Halaqat.Shared.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Halaqat.Features.Employees.Teachers.CommandHandlers
{
    internal class GetLoggedInTeacherCommandHandler(Repository repository) : IRequestHandler<Shared.Commands.Teachers.GetLoggedInTeacherCommand, Result<Teacher>>
    {
        public async Task<Result<Teacher>> Handle(Shared.Commands.Teachers.GetLoggedInTeacherCommand request, CancellationToken cancellationToken)
        {
            return await repository.GetLoggedInTeacher(request.UserId);
        }
    }
}
