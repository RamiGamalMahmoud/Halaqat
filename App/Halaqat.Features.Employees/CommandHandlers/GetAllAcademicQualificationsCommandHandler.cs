using Halaqat.Data;
using Halaqat.Shared.Commands;
using Halaqat.Shared.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Halaqat.Features.Employees.CommandHandlers
{
    internal class GetAllAcademicQualificationsCommandHandler(IAppDbContextFactory dbContextFactory) : IRequestHandler<Common.GetAllCommand<AcademicQualification>, IEnumerable<AcademicQualification>>
    {
        public async Task<IEnumerable<AcademicQualification>> Handle(Common.GetAllCommand<AcademicQualification> request, CancellationToken cancellationToken)
        {
            using (AppDbContext dbContext = dbContextFactory.CreateAppDbContext())
            {
                return await dbContext.AcademicQualifications.ToListAsync();
            }
        }
    }
}
