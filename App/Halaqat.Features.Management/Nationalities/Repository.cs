using Halaqat.Data;
using Halaqat.Shared;
using Halaqat.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Halaqat.Features.Management.Nationalities
{
    internal class Repository(IAppDbContextFactory appDbContextFactory) : RepositoryBase<Nationality, NationalityDataModel>(appDbContextFactory)
    {
        public override Task<Result<Nationality>> Create(NationalityDataModel dataModel)
        {
            throw new NotImplementedException();
        }

        public override async Task<IEnumerable<Nationality>> GetAll(bool reload)
        {
            using (AppDbContext dbContext = _dbContextFactory.CreateAppDbContext())
            {
                if(!_isLoaded || reload)
                {
                    IEnumerable<Nationality> nationalities = await dbContext.Nationalities.ToListAsync();
                    SetEntities(nationalities);
                }
                return _entities;
            }
        }

        public override Task<Result> Remove(Nationality model)
        {
            throw new NotImplementedException();
        }

        public override Task<Result> Update(NationalityDataModel dataModel)
        {
            throw new NotImplementedException();
        }
    }
}
