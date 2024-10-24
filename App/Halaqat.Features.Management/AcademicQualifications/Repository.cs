using Halaqat.Data;
using Halaqat.Shared;
using Halaqat.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Halaqat.Features.Management.AcademicQualifications
{
    internal class Repository(IAppDbContextFactory appDbContextFactory) :
        RepositoryBase<AcademicQualification, AcademicQualificationDataModel>(appDbContextFactory)
    {
        public override async Task<Result<AcademicQualification>> Create(AcademicQualificationDataModel dataModel)
        {
            using (AppDbContext dbContext = _dbContextFactory.CreateAppDbContext())
            {
                AcademicQualification academicQualification = new AcademicQualification() { Name = dataModel.Name };
                dbContext.AcademicQualifications.Add(academicQualification);

                try
                {
                    await dbContext.SaveChangesAsync();
                    _entities.Add(academicQualification);
                    return new Result<AcademicQualification>(academicQualification, true, null);
                }
                catch (Exception)
                {
                    return new Result<AcademicQualification>(null, false, "");
                }
            }
        }

        public override async Task<IEnumerable<AcademicQualification>> GetAll(bool reload)
        {
            using (AppDbContext dbContext = _dbContextFactory.CreateAppDbContext())
            {
                if (!_isLoaded || reload)
                {
                    IEnumerable<AcademicQualification> academicQualifications = await dbContext.AcademicQualifications.ToListAsync();
                    SetEntities(academicQualifications);
                }
                return _entities;
            }
        }

        public override Task<Result> Remove(AcademicQualification model)
        {
            throw new NotImplementedException();
        }

        public override async Task<Result> Update(AcademicQualificationDataModel dataModel)
        {
            using (AppDbContext dbContext = _dbContextFactory.CreateAppDbContext())
            {
                AcademicQualification stored = await dbContext.AcademicQualifications.FindAsync(dataModel.Model.Id);
                stored.Name = dataModel.Name;
                dbContext.AcademicQualifications.Update(stored);

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
