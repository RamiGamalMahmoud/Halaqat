using Halaqat.Shared;
using Halaqat.Shared.Commands;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Halaqat.Features.Management.AcademicQualifications.CommandHandlers
{
    internal class UpdateCommandHandler(Repository repository) :
        IRequestHandler<Shared.Commands.Common.UpdateModelCommand<AcademicQualificationDataModel>, Result>
    {
        public async Task<Result> Handle(Common.UpdateModelCommand<AcademicQualificationDataModel> request, CancellationToken cancellationToken)
        {
            return await repository.Update(request.DataModel);
        }
    }
}
