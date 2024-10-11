using CommunityToolkit.Mvvm.Messaging;
using Halaqat.Shared.Common;
using Halaqat.Shared.Models;
using MediatR;
using System.Threading.Tasks;

namespace Halaqat.Features.Users.Editor
{
    internal abstract class ViewModel : ViewModelBase<UserDataModel>
    {
        public ViewModel(IMediator mediator, IMessenger messenger, User model) : base(mediator, messenger)
        {
            DataModel = new UserDataModel(model);
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
