using Halaqat.Data;
using Halaqat.Shared.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
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

        public async Task<IEnumerable<ProgramDay>> GetProgramDayAppreciation(int studentId)
        {
            using (AppDbContext dbContext = dbContextFactory.CreateAppDbContext())
            {
                Student student = await dbContext
                    .Students
                    .Include(x => x.ProgramDayAppreciations)
                    .Where(x => x.Id == studentId)
                    .FirstOrDefaultAsync();

                IEnumerable<ProgramDay> programDays = await dbContext
                    .ProgramDays

                    .Include(x => x.ProgramDayItems)
                    .ThenInclude(x => x.Sorah)

                    .Include(x => x.ProgramDayItems)
                    .ThenInclude(x => x.ProgramDayItemType)

                    .Include(x => x.ProgramDayItems)
                    .ThenInclude(x => x.VerseFrom)

                    .Include(x => x.ProgramDayItems)
                    .ThenInclude(x => x.VerseTo)

                    .Include(x => x.ProgramDayAppreciations.Where(a => a.Student.Id == studentId))
                    .ThenInclude(x => x.Appreciation)

                    .ToListAsync();
                return programDays;
            }
        }

        public async Task Update(ProgramDayViewModel programDayItemViewModel)
        {
            using (AppDbContext dbContext = dbContextFactory.CreateAppDbContext())
            {
                ProgramDay stored = await dbContext
                    .ProgramDays
                    .Where(x => x.Id == programDayItemViewModel.ProgramDay.Id)
                    .FirstOrDefaultAsync();

                IEnumerable<ProgramDayAppreciation> programDayAppreciations = programDayItemViewModel
                    .ProgramDayMemorizingItemViewModel.ProgramDayAppreciations
                    .Concat(programDayItemViewModel.ProgramDayReviewItemViewModel.ProgramDayAppreciations);

                IEnumerable<EntityEntry<ProgramDayAppreciation>> programDayAppreciationsEntries = programDayAppreciations
                    .Where(x => x.Id == 0)
                    .Select(x =>
                    {
                        EntityEntry<ProgramDayAppreciation> entityEntry = dbContext.Entry<ProgramDayAppreciation>(x);
                        entityEntry.Property("ProgramDayId").CurrentValue = x.ProgramDay.Id;
                        entityEntry.Property("AppreciationId").CurrentValue = x.Appreciation.Id;
                        entityEntry.Property("ProgramDayItemTypeId").CurrentValue = x.ProgramDayItemType.Id;
                        entityEntry.Property("StudentId").CurrentValue = programDayItemViewModel.Student.Id;

                        x.ProgramDay = null;
                        x.Appreciation = null;
                        x.ProgramDayItemType = null;
                        x.Student = null;

                        return entityEntry;
                    });

                dbContext.Set<ProgramDayAppreciation>().AddRange(programDayAppreciationsEntries.Select(x => x.Entity));
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
