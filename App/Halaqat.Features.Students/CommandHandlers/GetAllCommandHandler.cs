using Halaqat.Shared.Commands;
using Halaqat.Shared.Models;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Halaqat.Features.Students.CommandHandlers
{
    internal class GetAllCommandHandler(Repository repository) : IRequestHandler<Common.GetAllCommand<Student>, IEnumerable<Student>>
    {
        public async Task<IEnumerable<Student>> Handle(Common.GetAllCommand<Student> request, CancellationToken cancellationToken)
        {
            return await repository.GetAll(request.Reload);
        }
    }
}
