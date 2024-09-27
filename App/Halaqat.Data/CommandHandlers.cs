using Halaqat.Shared.Commands;
using Halaqat.Shared.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Halaqat.Data
{
    internal class GetAllGendersCommandHandlers(IAppDbContextFactory dbContextFactory) : IRequestHandler<Shared.Commands.Common.GetAllCommand<Gender>, IEnumerable<Gender>>
    {
        public async Task<IEnumerable<Gender>> Handle(Common.GetAllCommand<Gender> request, CancellationToken cancellationToken)
        {
            using (AppDbContext dbContext = dbContextFactory.CreateAppDbContext())
            {
                return await dbContext.Set<Gender>().ToListAsync();
            }
        }
    }
}
