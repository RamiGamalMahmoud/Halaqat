using Halaqat.Shared.Commands;
using Halaqat.Shared.Models;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Halaqat.Features.Students.CommandHandlers
{
    internal class GetEducationalStatgesCommandHandler(Repository repository) : 
        IRequestHandler<Shared.Commands.Common.GetAllCommand<EducationalStage>, IEnumerable<EducationalStage>>
    {
        public async Task<IEnumerable<EducationalStage>> Handle(Common.GetAllCommand<EducationalStage> request, CancellationToken cancellationToken)
        {
            return await repository.GetEducationalStagesAsync();
        }
    }
}
