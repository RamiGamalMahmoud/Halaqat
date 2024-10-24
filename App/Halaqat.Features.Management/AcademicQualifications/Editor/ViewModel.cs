using CommunityToolkit.Mvvm.Messaging;
using Halaqat.Shared.Common;
using Halaqat.Shared.Models;
using MediatR;
using System.Threading.Tasks;

namespace Halaqat.Features.Management.AcademicQualifications.Editor
{
    internal abstract class ViewModel : ViewModelBase<AcademicQualificationDataModel>
    {
        protected ViewModel(IMediator mediator, IMessenger messenger, AcademicQualification model) : base(mediator, messenger)
        {
            DataModel = new AcademicQualificationDataModel(model);
            HasChangesObject = new HasChangesObject(SaveCommand.NotifyCanExecuteChanged);
            DataModel.PropertyChanged += DataModel_PropertyChanged;
        }

        public override Task LoadDataAsync()
        {
            return Task.CompletedTask;
        }

        public override bool CanSave() => HasChangesObject.HasChanges && DataModel.IsValid;
    }
}
