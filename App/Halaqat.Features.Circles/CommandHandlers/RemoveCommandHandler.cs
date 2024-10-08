using Halaqat.Shared;
using Halaqat.Shared.Commands;
using Halaqat.Shared.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Halaqat.Features.Circles.CommandHandlers
{
    internal class RemoveCommandHandler(Repository repository) : IRequestHandler<Shared.Commands.Common.RemoveModelCommand<Circle>, Result>
    {
        public async Task<Result> Handle(Common.RemoveModelCommand<Circle> request, CancellationToken cancellationToken)
        {
            return await repository.Remove(request.Model);
        }
    }
}
