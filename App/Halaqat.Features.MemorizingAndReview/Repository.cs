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

        public async Task<IEnumerable<ProgramDay>> GetProgramDayAppreciation(Student student)
        {
            using (AppDbContext dbContext = dbContextFactory.CreateAppDbContext())
            {
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

                    .Include(x => x.ProgramDayAppreciations.Where(a => a.Student.Id == student.Id))
                    .ThenInclude(x => x.Appreciation)
                    .Where(x => x.Program == student.Program)

                    .ToListAsync();
                return programDays;
            }
        }

        public async Task Update(ProgramDayViewModel programDayViewModel)
        {
            using (AppDbContext dbContext = dbContextFactory.CreateAppDbContext())
            {
                ProgramDay stored = await dbContext
                    .ProgramDays
                    .Where(x => x.Id == programDayViewModel.ProgramDay.Id)
                    .FirstOrDefaultAsync();

                IEnumerable<ProgramDayAppreciation> programDayAppreciations = programDayViewModel
                    .ProgramDayMemorizingItemViewModel.NewProgramDayAppreciations
                    .Concat(programDayViewModel.ProgramDayReviewItemViewModel.NewProgramDayAppreciations);

                IEnumerable<ProgramDayAppreciation> programDayAppreciationsEntries = programDayAppreciations
                    .Select(x =>
                    {
                        ProgramDayAppreciation programDayAppreciation = new ProgramDayAppreciation
                        {
                            ProgramDayId = x.ProgramDay.Id,
                            AppreciationId = x.Appreciation.Id,
                            ProgramDayItemTypeId = x.ProgramDayItemType.Id,
                            StudentId = programDayViewModel.Student.Id,
                            TeacherId = programDayViewModel.Teacher.Id,
                            DateAppreciated = x.DateAppreciated
                        };

                        return programDayAppreciation;
                    });

                dbContext.Set<ProgramDayAppreciation>().AddRange(programDayAppreciationsEntries);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
