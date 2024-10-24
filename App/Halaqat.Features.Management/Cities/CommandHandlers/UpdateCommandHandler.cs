using Halaqat.Shared;
using Halaqat.Shared.Commands;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Halaqat.Features.Management.Cities.CommandHandlers
{
    internal class UpdateCommandHandler(Repository repository) : IRequestHandler<Shared.Commands.Common.UpdateModelCommand<CityDataModel>, Result>
    {
        public async Task<Result> Handle(Common.UpdateModelCommand<CityDataModel> request, CancellationToken cancellationToken)
        {
            return await repository.Update(request.DataModel);
        }
    }
}
