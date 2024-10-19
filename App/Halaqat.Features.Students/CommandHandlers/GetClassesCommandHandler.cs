using Halaqat.Shared.Commands;
using Halaqat.Shared.Models;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Halaqat.Features.Students.CommandHandlers
{
    internal class GetClassesCommandHandler(Repository repository) : 
        IRequestHandler<Shared.Commands.Common.GetAllCommand<Class>, IEnumerable<Class>>
    {
        public async Task<IEnumerable<Class>> Handle(Common.GetAllCommand<Class> request, CancellationToken cancellationToken)
        {
            return await repository.GetClassAsync();
        }
    }
}
