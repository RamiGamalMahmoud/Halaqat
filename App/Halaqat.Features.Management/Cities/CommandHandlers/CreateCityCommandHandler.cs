using Halaqat.Shared;
using Halaqat.Shared.Commands;
using Halaqat.Shared.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Halaqat.Features.Management.Cities.CommandHandlers
{
    internal class CreateCityCommandHandler(Repository repository) : IRequestHandler<Shared.Commands.Common.CreateModelCommand<City, CityDataModel>, Result<City>>
    {
        public async Task<Result<City>> Handle(Common.CreateModelCommand<City, CityDataModel> request, CancellationToken cancellationToken)
        {
            return await repository.Create(request.DataModel);
        }
    }
}
