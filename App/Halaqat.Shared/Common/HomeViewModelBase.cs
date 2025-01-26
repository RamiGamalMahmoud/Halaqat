using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Halaqat.Shared.Models;
using MediatR;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Halaqat.Shared.Common
{
    public abstract partial class HomeViewModelBase<TModel>(IMediator mediator, IMessenger messenger) : ObservableObject where TModel : class
    {
        [ObservableProperty]
        private IEnumerable<TModel> _models;

        [RelayCommand]
        public abstract Task LoadDataAsync(bool isReload);

        [ObservableProperty]
        private string _searchTerm;

        [RelayCommand]
        protected async Task ShowCreate()
        {
            await _mediator.Send(new Shared.Commands.Common.ShowCreateModelViewCommand<TModel>());
        }

        [RelayCommand(CanExecute = nameof(CanDoModelAction))]
        protected async Task ShowEdit(TModel model)
        {
            await _mediator.Send(new Shared.Commands.Common.ShowEditModelViewCommand<TModel>(model));
        }

        [RelayCommand(CanExecute = nameof(CanDoModelAction))]
        protected async Task Remove(TModel model)
        {
            bool result = await _mediator.Send(new Shared.Commands.Common.ConfirmCommand("هل تريد حذف هذا العنصر؟"));
            if (!result) return;
            await _mediator.Send(new Shared.Commands.Common.RemoveModelCommand<TModel>(model));
        }

        partial void OnSearchTermChanged(string oldValue, string newValue)
        {
             OnSearch();
        }

        protected virtual void OnSearch()
        {
        }

        public Privileges Privileges { get; protected set; }

        public DoBusyWork DoBusyWork { get; } = new DoBusyWork();

        protected bool CanDoModelAction(TModel model) => model is not null;
        protected IEnumerable<TModel> _all;
        protected readonly IMediator _mediator = mediator;
        protected readonly IMessenger _messenger = messenger;
    }
}
