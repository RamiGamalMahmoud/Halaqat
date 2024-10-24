using Halaqat.Shared.Commands;
using Halaqat.Shared.Models;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Halaqat.Features.Management.AcademicQualifications.CommandHandlers
{
    internal class GetAllCommandHandler(Repository repository) : 
        IRequestHandler<Shared.Commands.Common.GetAllCommand<AcademicQualification>, IEnumerable<AcademicQualification>>
    {
        public async Task<IEnumerable<AcademicQualification>> Handle(Common.GetAllCommand<AcademicQualification> request, CancellationToken cancellationToken)
        {
            return await repository.GetAll(request.Reload);
        }
    }
}
