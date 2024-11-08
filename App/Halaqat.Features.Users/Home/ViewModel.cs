using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Halaqat.Shared.Common;
using Halaqat.Shared.Models;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Halaqat.Features.Users.Home
{
    internal partial class ViewModel : HomeViewModelBase<User>
    {
        public ViewModel(IMediator mediator, IMessenger messenger) : base(mediator, messenger)
        {
            Privileges = _messenger.Send(new Shared.Messages.Users.GetUsersPrivilegesRequestMessage());
            messenger.Register<Shared.Messages.Common.EntityUpdatedMessage<User>>(this, async (r, m) => await LoadDataAsync(true));
        }
        public override async Task LoadDataAsync(bool isReload)
        {
            _all = await _mediator.Send(new Shared.Commands.Common.GetAllCommand<User>(isReload));
            Models = _all.Where(x => x.IsActive);
        }

        protected override void OnSearch()
        {
            Models = string.IsNullOrEmpty(SearchTerm) ? _all : _all.Where(x => x.UserName.Contains(SearchTerm));
        }

        [RelayCommand]
        private Task ShowAllUsers()
        {
            Models = _all;
            return Task.CompletedTask;
        }

        [RelayCommand]
        private Task ShowActiveUsers()
        {
            Models = _all.Where(x => x.IsActive);
            return Task.CompletedTask;
        }

        [RelayCommand]
        private Task ShowInActiveUsers()
        {
            Models = _all.Where(x => !x.IsActive);
            return Task.CompletedTask;
        }
    }
}
