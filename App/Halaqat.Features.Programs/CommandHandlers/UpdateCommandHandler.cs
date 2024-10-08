using Halaqat.Shared;
using Halaqat.Shared.Commands;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Halaqat.Features.Programs.CommandHandlers
{
    internal class UpdateCommandHandler(Repository repository) : IRequestHandler<Shared.Commands.Common.UpdateModelCommand<ProgramDataModel>, Result>
    {
        public async Task<Result> Handle(Common.UpdateModelCommand<ProgramDataModel> request, CancellationToken cancellationToken)
        {
            return await repository.Update(request.DataModel);
        }
    }
}
