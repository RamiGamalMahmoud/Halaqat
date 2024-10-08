using Halaqat.Shared.Models;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Halaqat.Features.Students.CommandHandlers
{
    internal class GetStudentsWithNoCircleCommandHandler(Repository repository) : IRequestHandler<Shared.Commands.Students.GetStudentsWithNoCircleCommand, IEnumerable<Student>>
    {
        public async Task<IEnumerable<Student>> Handle(Shared.Commands.Students.GetStudentsWithNoCircleCommand request, CancellationToken cancellationToken)
        {
            return await repository.GetStudentsWithNoCircle();
        }
    }
}
