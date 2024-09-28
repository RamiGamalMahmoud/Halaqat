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
    internal class GetAllJobTitlesCommandHandler(IAppDbContextFactory dbContextFactory) : IRequestHandler<Common.GetAllCommand<JobTitle>, IEnumerable<JobTitle>>
    {
        public async Task<IEnumerable<JobTitle>> Handle(Common.GetAllCommand<JobTitle> request, CancellationToken cancellationToken)
        {
            using (AppDbContext dbContext = dbContextFactory.CreateAppDbContext())
            {
                return await dbContext.JobTitles.ToListAsync();
            }
        }
    }
}
