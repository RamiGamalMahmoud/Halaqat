using Halaqat.Shared;
using Halaqat.Shared.Commands;
using Halaqat.Shared.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Halaqat.Features.Users.CommandHandlers
{
    internal class CreateCommandHandler(Repository repository) : IRequestHandler<Shared.Commands.Common.CreateModelCommand<User, UserDataModel>, Result<User>>
    {
        public async Task<Result<User>> Handle(Common.CreateModelCommand<User, UserDataModel> request, CancellationToken cancellationToken)
        {
            return await repository.Create(request.DataModel);
        }
    }
}
