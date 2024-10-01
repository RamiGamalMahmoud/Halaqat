using Halaqat.Data;
using Halaqat.Shared;
using Halaqat.Shared.Common;
using Halaqat.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Halaqat.Features.Circles
{
    internal class Repository(IAppDbContextFactory appDbContextFactory) : RepositoryBase<Circle, CircleDataModel>(appDbContextFactory)
    {
        public override async Task<IEnumerable<Circle>> GetAll(bool reload)
        {
            using (AppDbContext dbContext = _dbContextFactory.CreateAppDbContext())
            {
                if (!_isLoaded || reload)
                {
                    IEnumerable<Circle> circles = await dbContext
                        .Circles
                        .Include(x => x.Teacher)
                        .Include(x => x.Students)
                        .Where(x => !x.IsDeleted)
                        .ToListAsync();
                    SetEntities(circles);
                }

                return _entities;
            }
        }

        public async Task<IEnumerable<Circle>> SearchByName(string searchTerm)
        {
            if (_entities is not null)
            {
                return _entities
                    .Where(x => !x.IsDeleted)
                    .Where(x => x.Name.Contains(searchTerm));
            }

            using (AppDbContext dbContext = _dbContextFactory.CreateAppDbContext())
            {
                return await dbContext
                    .Circles
                    .Include(x => x.Teacher)
                    .Include(x => x.Students)
                    .Where(x => !x.IsDeleted)
                    .Where(x => x.Name.Contains(searchTerm)).ToListAsync();
            }
        }

        public override async Task<Result<Circle>> Create(CircleDataModel dataModel)
        {
            using (AppDbContext dbContext = _dbContextFactory.CreateAppDbContext())
            {
                Circle circle = new Circle(dataModel.Name)
                {
                    TeacherId = dataModel.Teacher.Id,
                };

                IEnumerable<int> selectedIds = dataModel.Students.Select(x => x.Id);
                IEnumerable<Student> students = await dbContext.Students.Where(x => selectedIds.Contains(x.Id)).ToListAsync();

                foreach(Student student in students)
                {
                    circle.Students.Add(student);
                }

                dbContext.Circles.Add(circle);
                await dbContext.SaveChangesAsync();
                _entities.Add(circle);
                dataModel.Update(circle);
                return new Result<Circle>(circle, true, null);
            }
        }

        public override async Task<Result> Update(CircleDataModel dataModel)
        {
            using (AppDbContext dbContext = _dbContextFactory.CreateAppDbContext())
            {
                Circle stored = await dbContext.Circles
                    .Include(x => x.Students)
                    .SingleOrDefaultAsync(x => x == dataModel.Model);

                IEnumerable<int> studentsToKeepIds = dataModel.Students.Select(x => x.Id);
                IEnumerable<Student> studentsToKeep = await dbContext.Students.Where(x => studentsToKeepIds.Contains(x.Id)).ToListAsync();
                stored.Students.Clear();

                foreach(Student student in studentsToKeep)
                {
                    stored.Students.Add(student);
                }

                stored.Name = dataModel.Name;
                stored.TeacherId = dataModel.Teacher.Id;

                dbContext.Circles.Update(stored);
                try
                {
                    await dbContext.SaveChangesAsync();
                    dataModel.Update(dataModel.Model);
                    return Result.Success;
                }
                catch (System.Exception)
                {
                    return new Result("");
                }
            }
        }

        public override async Task<Result> Remove(Circle circle)
        {
            using (AppDbContext dbContext = _dbContextFactory.CreateAppDbContext())
            {
                Circle stored = await dbContext.Circles.FindAsync(circle.Id);
                stored.IsDeleted = true;
                stored.DateDeleted = DateTime.Now;

                dbContext.Circles.Update(stored);
                try
                {
                    await dbContext.SaveChangesAsync();
                    _entities.Remove(circle);
                    return Result.Success;
                }
                catch (System.Exception)
                {
                    return new Result("");
                }
            }
        }
    }
}
