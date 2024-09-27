using FluentAssertions;
using Halaqat.Features.Employees.Editor;
using Halaqat.Shared.Models;

namespace Halaqat.Tests.Features.Employees
{
    public class UpdateViewModelTests
    {
        [Fact]
        public void SaveCommandCanExecute_ShouldBeFalse_AfterInit()
        {
            Employee employee = new Employee
            {
                Name = "name",

                Address = new Shared.Models.Address(),

                AcademicQualification = new Shared.Models.AcademicQualification(),

                JobTitle = new Shared.Models.JobTitle()
            };

            Halaqat.Features.Employees.Editor.UpdateViewModel viewModel = new UpdateViewModel(null, null, employee);

            viewModel.SaveCommand.CanExecute(null).Should().BeFalse();
        }

        [Fact]
        public void SaveCommandCanExecute_ShouldBeTrue_AfterNameChanged()
        {
            Halaqat.Features.Employees.Editor.UpdateViewModel viewModel = new UpdateViewModel(null, null, GetEmployee());
            viewModel.DataModel.Name = "new name";

            viewModel.SaveCommand.CanExecute(null).Should().BeTrue();
        }

        private Employee GetEmployee()
        {
            return new Employee
            {
                Name = "name",

                Address = new Shared.Models.Address(),

                AcademicQualification = new Shared.Models.AcademicQualification(),

                JobTitle = new Shared.Models.JobTitle()
            };
        }
    }
}
