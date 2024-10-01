using Halaqat.Shared;
using Halaqat.Shared.Commands;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Halaqat.Features.Students.CommandHandlers
{
    internal class UpdateStudentCommandHandler(Repository repository) : IRequestHandler<Common.UpdateModelCommand<StudentDataModel>, Result>
    {
        public async Task<Result> Handle(Common.UpdateModelCommand<StudentDataModel> request, CancellationToken cancellationToken)
        {
            return await repository.Update(request.DataModel);
        }
    }
}
