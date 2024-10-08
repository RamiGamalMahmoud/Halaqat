using Halaqat.Shared;
using Halaqat.Shared.Commands;
using Halaqat.Shared.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Halaqat.Features.Programs.CommandHandlers
{
    internal class CreateCommandHandler(Repository repository) : IRequestHandler<Shared.Commands.Common.CreateModelCommand<Program, ProgramDataModel>, Result<Program>>
    {
        public async Task<Result<Program>> Handle(Common.CreateModelCommand<Program, ProgramDataModel> request, CancellationToken cancellationToken)
        {
            return await repository.Create(request.DataModel);
        }
    }
}
