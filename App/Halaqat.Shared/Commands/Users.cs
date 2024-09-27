using Halaqat.Shared.Models;
using MediatR;

namespace Halaqat.Shared.Commands
{
    public static class Users
    {
        public record GetUserByUserNameAndPassword(string UserName, string Password) : IRequest<Result<User>>;
    }
}
