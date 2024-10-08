using Halaqat.Shared;
using Halaqat.Shared.Commands;
using Halaqat.Shared.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Halaqat.Features.Students.CommandHandlers
{
    internal class CreateStudentCommandHandler(Repository repository) : IRequestHandler<Common.CreateModelCommand<Student, StudentDataModel>, Result<Student>>
    {
        public async Task<Result<Student>> Handle(Common.CreateModelCommand<Student, StudentDataModel> request, CancellationToken cancellationToken)
        {
            return await repository.Create(request.DataModel);
        }
    }
}
