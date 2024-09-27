using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
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
            await _mediator.Send(new Shared.Commands.Common.RemoveModelCommand<TModel>(model));
        }

        public DoBusyWork DoBusyWork { get; } = new DoBusyWork();

        protected bool CanDoModelAction(TModel model) => model is not null;
        protected readonly IMediator _mediator = mediator;
        protected readonly IMessenger _messenger = messenger;
    }
}
