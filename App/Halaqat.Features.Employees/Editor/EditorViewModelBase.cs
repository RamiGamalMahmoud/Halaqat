using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using Halaqat.Shared.Common;
using Halaqat.Shared.Models;
using MediatR;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Halaqat.Features.Employees.Editor
{
    internal abstract partial class EditorViewModelBase : ViewModelBase<EmployeeViewModel>
    {
        protected EditorViewModelBase(IMediator mediator, IMessenger messenger, Employee model) : base(mediator, messenger)
        {
            DataModel = new EmployeeViewModel(model);
            HasChangesObject = new HasChangesObject(SaveCommand.NotifyCanExecuteChanged);
            DataModel.PropertyChanged += DataModel_PropertyChanged;
        }

        public override bool CanSave() => HasChangesObject.HasChanges && DataModel.IsValid;

        public override async Task LoadDataAsync()
        {
            AcademicQualifications = await _mediator.Send(new Shared.Commands.Common.GetAllCommand<AcademicQualification>(false));
            JobTitles = await _mediator.Send(new Shared.Commands.Common.GetAllCommand<JobTitle>(false));
            Cities = await _mediator.Send(new Shared.Commands.Common.GetAllCommand<City>(false));
            Genders = await _mediator.Send(new Shared.Commands.Common.GetAllCommand<Gender>(false));
        }

        [ObservableProperty]
        private IEnumerable<AcademicQualification> _academicQualifications;

        [ObservableProperty]
        private IEnumerable<JobTitle> _jobTitles;

        [ObservableProperty]
        private IEnumerable<City> _cities;

        [ObservableProperty]
        private IEnumerable<Gender> _genders;
    }
}
