using Halaqat.Data;
using Halaqat.Shared;
using Halaqat.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Halaqat.Features.Employees
{
    internal class Repository(IAppDbContextFactory dbContextFactory) : RepositoryBase<Employee, EmployeeViewModel>(dbContextFactory)
    {
        public async Task<IEnumerable<Employee>> GetByName(string name)
        {
            if (_entities is not null)
            {
                return _entities.Where(x => x.Name.Contains(name));
            }

            using (AppDbContext dbContext = _dbContextFactory.CreateAppDbContext())
            {
                IEnumerable<Employee> employees = await dbContext
                    .Employees
                    .Include(x => x.Gender)
                    .Include(x => x.AcademicQualification)
                    .Include(x => x.JobTitle)
                    .Include(x => x.Address)
                    .ThenInclude(x => x.City)
                    .Include(x => x.Phones)
                    .Where(x => !x.IsDeleted)
                    .Where(x => x.Name.Contains(name))
                    .ToArrayAsync();

                return employees;
            }
        }

        public override async Task<IEnumerable<Employee>> GetAll(bool reload)
        {
            if (!_isLoaded || reload)
            {
                using (AppDbContext dbContext = _dbContextFactory.CreateAppDbContext())
                {
                    IEnumerable<Employee> employees = await dbContext
                        .Employees
                        .Include(x => x.Gender)
                        .Include(x => x.AcademicQualification)
                        .Include(x => x.JobTitle)
                        .Include(x => x.Address)
                        .ThenInclude(x => x.City)
                        .Include(x => x.Phones)
                        .Include(x => x.User)
                        .Where(x => !x.IsDeleted)
                        .ToArrayAsync();
                    SetEntities(employees);
                }
            }

            return _entities;
        }

        public override async Task<Result<Employee>> Create(EmployeeViewModel dataModel)
        {
            using (AppDbContext dbContext = _dbContextFactory.CreateAppDbContext())
            {
                User user = null;
                if (dataModel.UserName is not null && dataModel.Password is not null)
                {
                    user = new User()
                    {
                        UserName = dataModel.UserName,
                        Password = dataModel.Password,
                        DateCreated = dataModel.DateCreated,
                        IsActive = true
                    };
                }

                Employee employee = new Employee()
                {
                    Name = dataModel.Name,
                    DateCreated = dataModel.DateCreated,
                    AcademicQualificationId = dataModel.AcademicQualification.Id,
                    JobTitleId = dataModel.JobTitle.Id,
                    GenderId = dataModel.Gender.Id,
                    Address = new Address()
                    {
                        CityId = dataModel.City.Id,
                        District = dataModel.District,
                        Street = dataModel.Street
                    },
                    User = user
                };

                foreach (Phone phone in dataModel.Phones)
                {
                    employee.Phones.Add(phone);
                }

                dbContext.Employees.Add(employee);
                await dbContext.SaveChangesAsync();

                dataModel.UpdateModel(employee);

                _entities.Add(employee);
                return new Result<Employee>(employee, true, null);
            }
        }

        public override async Task<Result> Update(EmployeeViewModel dataModel)
        {
            using (AppDbContext dbContext = _dbContextFactory.CreateAppDbContext())
            {
                Address address = await dbContext.Addresses.FindAsync(dataModel.Address.Id);

                IEnumerable<int> phonesIds = dataModel.Phones.Select(x => x.Id).Where(x => x > 0);
                IEnumerable<Phone> newPhones = dataModel.Phones.Where(x => x.Id == 0);
                IEnumerable<Phone> oldPhones = dbContext.Set<Phone>().Where(x => phonesIds.Contains(x.Id));
                IEnumerable<Phone> phones = newPhones.Concat(oldPhones);

                Employee storedEmployee = await dbContext
                    .Employees
                    .Include(x => x.Phones)
                    .Include(x => x.User)
                    .Where(x => x.Id == dataModel.Model.Id)
                    .FirstOrDefaultAsync();

                if(!string.IsNullOrEmpty(dataModel.UserName) && !string.IsNullOrEmpty(dataModel.Password))
                {
                    if(storedEmployee.User is not null)
                    {
                        storedEmployee.User.UserName = dataModel.UserName;
                        storedEmployee.User.Password = dataModel.Password;
                        storedEmployee.User.IsActive = dataModel.IsActive;
                    }

                    else
                    {
                        User user = new User()
                        {
                            UserName = dataModel.UserName,
                            Password = dataModel.Password,
                            DateCreated = dataModel.DateCreated,
                            IsActive = dataModel.IsActive
                        };

                        storedEmployee.User = user;
                    }
                }

                address.CityId = dataModel.City.Id;
                address.District = dataModel.District;
                address.Street = dataModel.Street;

                storedEmployee.Phones.Clear();
                foreach (Phone phone in phones)
                {
                    storedEmployee.Phones.Add(phone);
                }

                storedEmployee.Name = dataModel.Name;
                storedEmployee.AcademicQualificationId = dataModel.AcademicQualification.Id;
                storedEmployee.JobTitleId = dataModel.JobTitle.Id;
                storedEmployee.GenderId = dataModel.Gender.Id;
                storedEmployee.DateCreated = dataModel.DateCreated;

                dbContext.Employees.Update(storedEmployee);
                await dbContext.SaveChangesAsync();
                dataModel.UpdateModel(dataModel.Model);
            }

            return await Task.FromResult(new Result(true, ""));
        }

        public override async Task<Result> Remove(Employee employee)
        {
            using (AppDbContext dbContext = _dbContextFactory.CreateAppDbContext())
            {
                Employee stored = await dbContext.Employees.FindAsync(employee.Id);
                stored.Delete();
                await dbContext.SaveChangesAsync();
                _entities.Remove(employee);
                return Result.Success;
            }
        }

        public async Task<IEnumerable<Employee>> GetTeachers()
        {
            if (_entities is not null)
            {
                return _entities.Where(x => x.JobTitle.Name == "معلم");
            }

            using (AppDbContext dbContext = _dbContextFactory.CreateAppDbContext())
            {
                IEnumerable<Employee> employees = await dbContext
                    .Employees
                    .Include(x => x.Gender)
                    .Include(x => x.AcademicQualification)
                    .Include(x => x.JobTitle)
                    .Include(x => x.Address)
                    .ThenInclude(x => x.City)
                    .Include(x => x.Phones)
                    .Where(x => !x.IsDeleted)
                    .Where(x => x.JobTitle.Name == "معلم")
                    .ToArrayAsync();

                return employees;
            }
        }
    }
}
