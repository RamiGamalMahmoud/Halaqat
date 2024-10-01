using Halaqat.Shared.Models;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Halaqat.Features.Students.CommandHandlers
{

    internal class SearchCommandHandler(Repository repository) : IRequestHandler<Shared.Commands.Students.Search, IEnumerable<Student>>
    {
        public async Task<IEnumerable<Student>> Handle(Shared.Commands.Students.Search request, CancellationToken cancellationToken)
        {
            return await repository.GetByName(request.Name);
        }
    }
}
