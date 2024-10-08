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
    internal class GetAllCitiesCommandHandler(IAppDbContextFactory dbContextFactory) : IRequestHandler<Common.GetAllCommand<City>, IEnumerable<City>>
    {
        public async Task<IEnumerable<City>> Handle(Common.GetAllCommand<City> request, CancellationToken cancellationToken)
        {
            using (AppDbContext dbContext = dbContextFactory.CreateAppDbContext())
            {
                return await dbContext.Cities.ToListAsync();
            }
        }
    }
}
