using Halaqat.Shared;
using Halaqat.Shared.Commands;
using Halaqat.Shared.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Halaqat.Features.Management.AcademicQualifications.CommandHandlers
{
    internal class CreateCommandHandler(Repository repository) : 
        IRequestHandler<Shared.Commands.Common.CreateModelCommand<AcademicQualification, AcademicQualificationDataModel>, Result<AcademicQualification>>
    {
        public async Task<Result<AcademicQualification>> Handle(Common.CreateModelCommand<AcademicQualification, AcademicQualificationDataModel> request, CancellationToken cancellationToken)
        {
            return await repository.Create(request.DataModel);
        }
    }
}
