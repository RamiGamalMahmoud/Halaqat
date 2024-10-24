using Halaqat.Data;
using Halaqat.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
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

        public async Task Update(ProgramDayItemViewModel programDayItemViewModel)
        {
            using (AppDbContext dbContext = dbContextFactory.CreateAppDbContext())
            {
                ProgramDay stored = await dbContext
                    .ProgramDays
                    .Where(x => x.Id == programDayItemViewModel.ProgramDay.Id)
                    .FirstOrDefaultAsync();


            }
        }
    }
}
