using MediatR;

namespace Halaqat.Shared.Commands
{
    public static class Database
    {
        public record BackupCommand : IRequest;
        public record RestoreCommand : IRequest<Result>;
    }
}
