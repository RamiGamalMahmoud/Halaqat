using Halaqat.Data;
using Halaqat.Shared;
using Halaqat.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Halaqat.Features.Management.Cities
{
    internal class Repository : RepositoryBase<City, CityDataModel>
    {
        public Repository(IAppDbContextFactory appDbContextFactory) : base(appDbContextFactory)
        {
        }

        public override async Task<Result<City>> Create(CityDataModel dataModel)
        {
            using (AppDbContext dbContext = _dbContextFactory.CreateAppDbContext())
            {
                City city = new City() { Name = dataModel.Name };
                dbContext.Cities.Add(city);

                try
                {
                    await dbContext.SaveChangesAsync();
                    _entities.Add(city);
                    return new Result<City>(city, true, null);
                }
                catch (Exception)
                {
                    return new Result<City>(null, false, "");
                }
            }
        }

        public override async Task<IEnumerable<City>> GetAll(bool reload)
        {
            using (AppDbContext dbContext = _dbContextFactory.CreateAppDbContext())
            {
                if (!_isLoaded || reload)
                {
                    IEnumerable<City> cities = await dbContext.Cities.ToListAsync();
                    SetEntities(cities);
                }
                return _entities;
            }
        }

        public override Task<Result> Remove(City model)
        {
            throw new NotImplementedException();
        }

        public override async Task<Result> Update(CityDataModel dataModel)
        {
            using (AppDbContext dbContext = _dbContextFactory.CreateAppDbContext())
            {
                City stored = await dbContext.Cities.FindAsync(dataModel.Model.Id);
                stored.Name = dataModel.Name;
                dbContext.Cities.Update(stored);
                try
                {
                    await dbContext.SaveChangesAsync();
                    dataModel.Update();
                    return Result.Success;
                }
                catch (Exception)
                {
                    return new Result();
                }
            }
        }
    }
}
