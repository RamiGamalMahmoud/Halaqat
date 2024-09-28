using Halaqat.Shared;
using Halaqat.Shared.Commands;
using Halaqat.Shared.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Halaqat.Features.Circles.CommandHandlers
{
    internal class CreateCommandHandler(Repository repository) : IRequestHandler<Shared.Commands.Common.CreateModelCommand<Circle, CircleDataModel>, Result<Circle>>
    {
        public async Task<Result<Circle>> Handle(Common.CreateModelCommand<Circle, CircleDataModel> request, CancellationToken cancellationToken)
        {
            return await repository.Create(request.DataModel);
        }
    }
}
