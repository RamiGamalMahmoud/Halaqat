using Halaqat.Shared;
using Halaqat.Shared.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Halaqat.Features.Users.CommandHandlers
{
    internal class GetUserByUserNameAndPasswordCommandHandler(Repository repository) : IRequestHandler<Shared.Commands.Users.GetUserByUserNameAndPassword, Result<User>>
    {
        public async Task<Result<User>> Handle(Shared.Commands.Users.GetUserByUserNameAndPassword request, CancellationToken cancellationToken)
        {
            return await repository.GetByUserNameAndPassword(request.UserName, request.Password);
        }
    }
}
