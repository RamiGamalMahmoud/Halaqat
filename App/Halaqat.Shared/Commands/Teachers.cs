using Halaqat.Shared.Models;
using MediatR;

namespace Halaqat.Shared.Commands
{
    public static class Teachers
    {
        public record GetLoggedInTeacherCommand(int UserId) : IRequest<Result<Teacher>>;
    }
}
