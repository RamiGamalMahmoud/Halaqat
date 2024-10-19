using Halaqat.Data;
using Halaqat.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Halaqat.Features.MemorizingAndReview
{
    internal class Repository(IAppDbContextFactory dbContextFactory)
    {
        public async Task<IEnumerable<Appreciation>> GetAppreciations()
        {
            using (AppDbContext dbContext = dbContextFactory.CreateAppDbContext())
            {
                return await dbContext.Set<Appreciation>().ToListAsync();
            }
        }
    }
}
