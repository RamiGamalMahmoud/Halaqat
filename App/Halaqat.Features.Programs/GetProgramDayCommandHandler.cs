using Halaqat.Shared.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Halaqat.Features.Programs
{
    internal class GetProgramDayCommandHandler(Repository repository) : IRequestHandler<Shared.Commands.Programs.GetProgram, Program>
    {
        public async Task<Program> Handle(Shared.Commands.Programs.GetProgram request, CancellationToken cancellationToken)
        {
            return await repository.Get(request.Id);
        }
    }
}
