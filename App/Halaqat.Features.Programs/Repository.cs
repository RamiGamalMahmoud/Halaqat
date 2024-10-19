using Halaqat.Data;
using Halaqat.Shared;
using Halaqat.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Halaqat.Features.Programs
{
    internal class Repository(IAppDbContextFactory appDbContextFactory) : RepositoryBase<Program, ProgramDataModel>(appDbContextFactory)
    {
        public override async Task<Result<Program>> Create(ProgramDataModel dataModel)
        {
            using (AppDbContext dbContext = _dbContextFactory.CreateAppDbContext())
            {
                Program program = new Program()
                {
                    Name = dataModel.Name,
                    ExpectedDuration = (int)dataModel.ExpectedDuration,
                    Notes = dataModel.Notes
                };

                foreach (ProgramDay item in dataModel.ProgramDays)
                {
                    program.ProgramDays.Add(item);
                }

                dbContext.Programs.Update(program);

                await dbContext.SaveChangesAsync();
                _entities?.Add(program);
                return new Result<Program>(program, true, null);
            }
        }

        public override async Task<IEnumerable<Program>> GetAll(bool reload)
        {
            if (!_isLoaded || reload)
            {
                using (AppDbContext dbContext = _dbContextFactory.CreateAppDbContext())
                {
                    IEnumerable<Program> programs = await dbContext
                        .Programs
                        
                        .Include(x => x.ProgramDays)
                        .ThenInclude(x => x.ProgramDayItems)
                        .ThenInclude(x => x.Sorah)
                        
                        .Include(x => x.ProgramDays)
                        .ThenInclude(x => x.ProgramDayItems)
                        .ThenInclude(x => x.ProgramDayItemType)

                        .Include(x => x.ProgramDays)
                        .ThenInclude(x => x.ProgramDayItems)
                        .ThenInclude(x => x.VerseFrom)

                        .Include(x => x.ProgramDays)
                        .ThenInclude(x => x.ProgramDayItems)
                        .ThenInclude(x => x.VerseTo)

                        .Include(x => x.ProgramDays)
                        .ThenInclude(x => x.ProgramDayAppreciations)
                        .ThenInclude(x => x.Appreciation)

                        .ToListAsync();
                    SetEntities(programs);
                }
            }
            return _entities;
        }

        public async Task<Program> Get(int id)
        {
            using (AppDbContext dbContext = _dbContextFactory.CreateAppDbContext())
            {
                return await dbContext
                    .Programs

                    .Include(x => x.ProgramDays)
                    .ThenInclude(x => x.ProgramDayItems)
                    .ThenInclude(x => x.Sorah)

                    .Include(x => x.ProgramDays)
                    .ThenInclude(x => x.ProgramDayItems)
                    .ThenInclude(x => x.ProgramDayItemType)

                    .Include(x => x.ProgramDays)
                    .ThenInclude(x => x.ProgramDayItems)
                    .ThenInclude(x => x.VerseFrom)

                    .Include(x => x.ProgramDays)
                    .ThenInclude(x => x.ProgramDayItems)
                    .ThenInclude(x => x.VerseTo)

                    .Include(x => x.ProgramDays)
                    .ThenInclude(x => x.ProgramDayAppreciations)
                    .ThenInclude(x => x.Appreciation)

                    .Where(x => x.Id == id)
                    .FirstOrDefaultAsync();
            }
        }

        public async Task<IEnumerable<ProgramDayItemType>> GetProgramDayItemTypes(bool reload)
        {
            using (AppDbContext dbContext = _dbContextFactory.CreateAppDbContext())
            {
                if (_programDayItemTypes is null || reload)
                {
                    _programDayItemTypes = await dbContext.Set<ProgramDayItemType>().ToListAsync();
                }

                return _programDayItemTypes;
            }
        }

        public async Task<IEnumerable<Sorah>> GetSorahs()
        {
            using (AppDbContext dbContext = _dbContextFactory.CreateAppDbContext())
            {
                _sorahs ??= await dbContext.Sorahs.Include(x => x.Verses).ToListAsync();

                return _sorahs;
            }
        }

        public async Task<IEnumerable<Verse>> GetVerses(int sorahId)
        {
            using (AppDbContext dbContext = _dbContextFactory.CreateAppDbContext())
            {
                return await dbContext
                    .Verses
                    .Include(x => x.Sorah)
                    .Where(x => x.Sorah.Id == sorahId)
                    .ToListAsync();
            }
        }

        public override Task<Result> Remove(Program model)
        {
            return new Task<Result>(() => Result.Success);
        }

        public override async Task<Result> Update(ProgramDataModel dataModel)
        {
            using (AppDbContext dbContext = _dbContextFactory.CreateAppDbContext())
            {
                Program stored = await dbContext
                    .Programs
                    .Include(x => x.ProgramDays)
                    .Where(x => x.Id == dataModel.Model.Id)
                    .FirstOrDefaultAsync();

                IEnumerable<ProgramDay> newDays = dataModel.ProgramDays.Where(x => x.Id == 0);

                foreach (ProgramDay newDay in newDays)
                {
                    stored.ProgramDays.Add(newDay);
                }

                stored.Name = dataModel.Name;
                stored.ExpectedDuration = (int)dataModel.ExpectedDuration;
                stored.Notes = dataModel.Notes;

                dbContext.Programs.Update(stored);
                await dbContext.SaveChangesAsync();
                dataModel.Update();
                return Result.Success;
            }
        }

        private IEnumerable<Sorah> _sorahs;
        private IEnumerable<ProgramDayItemType> _programDayItemTypes;
    }
}
