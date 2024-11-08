using Halaqat.Shared;
using Halaqat.Shared.Commands;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Halaqat.Features.Settings.CommandHandlers
{
    internal static class DatabaseCommandHandlers
    {
        public class BackupCommandHandler(DatabaseOperations databaseOperations) : IRequestHandler<Shared.Commands.Database.BackupCommand>
        {
            public async Task Handle(Database.BackupCommand request, CancellationToken cancellationToken)
            {
                await databaseOperations.Backup();
            }
        }

        public class RestoreCommandHandler(DatabaseOperations databaseOperations) : IRequestHandler<Shared.Commands.Database.RestoreCommand, Result>
        {
            public async Task<Result> Handle(Database.RestoreCommand request, CancellationToken cancellationToken)
            {
                return await databaseOperations.Restore();
            }
        }
    }
}
