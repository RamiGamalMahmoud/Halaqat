using FluentAssertions;
using Halaqat.Features.Employees.Editor;

namespace Halaqat.Tests.Features.Employees
{
    public class CreateVieModelTests
    {
        [Fact]
        public void ViewModel_CanNotExecute_AfterInit()
        {
            Halaqat.Features.Employees.Editor.CreateViewModel viewModel = new CreateViewModel(null, null);
            Assert.False( viewModel.SaveCommand.CanExecute(null));
        }

        [Fact]
        public void SaveCommandCanExecute_ShouldBeTrue_AfterNameChanged()
        {
            Halaqat.Features.Employees.Editor.CreateViewModel viewModel = new CreateViewModel(null, null);

            viewModel.DataModel.Name = "name";

            viewModel.DataModel.Address = new Shared.Models.Address();

            viewModel.DataModel.AcademicQualification = new Shared.Models.AcademicQualification();

            viewModel.DataModel.JobTitle = new Shared.Models.JobTitle();

            viewModel.CanSave().Should().BeTrue();
            viewModel.DataModel.IsValid.Should().BeTrue();
            viewModel.SaveCommand.CanExecute(null).Should().BeTrue();
            viewModel.HasChangesObject.HasChanges.Should().BeTrue();
        }

    }
}
