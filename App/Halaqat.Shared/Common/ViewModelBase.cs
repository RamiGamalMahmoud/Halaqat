using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using MediatR;
using System.ComponentModel;
using System.Threading.Tasks;

namespace Halaqat.Shared.Common
{
    public abstract partial class ViewModelBase<TDataModel>(IMediator mediator, IMessenger messenger) : ObservableValidator
    {
        public string Title { get; protected set; }
        public TDataModel DataModel { get; protected set; }

        [RelayCommand(CanExecute = nameof(CanSave))]
        protected abstract Task Save();
        public abstract Task LoadDataAsync();
        public abstract bool CanSave();
        public HasChangesObject HasChangesObject { get; protected set; }

        protected virtual void DataModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            HasChangesObject.SetHaschanges();
        }

        protected readonly IMediator _mediator = mediator;
        protected readonly IMessenger _messenger = messenger;
    }
}
