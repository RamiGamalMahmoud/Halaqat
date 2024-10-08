using Halaqat.Shared.Commands;
using Halaqat.Shared.Models;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Halaqat.Features.Programs.CommandHandlers
{
    internal class GetProgramDayItemTypesCommandHandler(Repository repository) : IRequestHandler<Shared.Commands.Common.GetAllCommand<ProgramDayItemType>, IEnumerable<ProgramDayItemType>>
    {
        public async Task<IEnumerable<ProgramDayItemType>> Handle(Common.GetAllCommand<ProgramDayItemType> request, CancellationToken cancellationToken)
        {
            return await repository.GetProgramDayItemTypes(false);
        }
    }
}
