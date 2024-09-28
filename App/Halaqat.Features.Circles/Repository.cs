using Halaqat.Data;
using Halaqat.Shared;
using Halaqat.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Halaqat.Features.Circles
{
    internal class Repository(IAppDbContextFactory appDbContextFactory) : RepositoryBase<Circle, CircleDataModel>(appDbContextFactory)
    {
        public override async Task<IEnumerable<Circle>> GetAll(bool reload)
        {
            using (AppDbContext dbContext = _dbContextFactory.CreateAppDbContext())
            {
                if(!_isLoaded || reload)
                {
                    IEnumerable<Circle> circles = await dbContext.Circles.ToListAsync();
                    SetEntities(circles);
                }

                return _entities;
            }
        }

        public override Task<Result<Circle>> Create(CircleDataModel dataModel)
        {
            throw new System.NotImplementedException();
        }

        public override Task<Result> Update(CircleDataModel dataModel)
        {
            throw new System.NotImplementedException();
        }

        public override Task<Result> Remove(Circle circle)
        {
            throw new System.NotImplementedException();
        }
    }
}
