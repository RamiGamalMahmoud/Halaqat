using CommunityToolkit.Mvvm.Messaging;
using Halaqat.Shared.Common;
using Halaqat.Shared.Models;
using MediatR;
using System.Threading.Tasks;

namespace Halaqat.Features.Circles.Editor
{
    internal abstract class ViewModel : ViewModelBase<CircleDataModel>
    {
        protected ViewModel(IMediator mediator, IMessenger messenger, Circle model) : base(mediator, messenger)
        {
            DataModel = new CircleDataModel(model);
            HasChangesObject = new HasChangesObject(SaveCommand.NotifyCanExecuteChanged);
            DataModel.PropertyChanged += DataModel_PropertyChanged;
        }

        public override bool CanSave() => HasChangesObject.HasChanges && DataModel.IsValid;

        public override Task LoadDataAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}
