using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Halaqat.Services;
using Halaqat.Shared;
using Halaqat.Shared.Models;
using MediatR;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Halaqat.Auth.Login
{
    internal partial class ViewModel : ObservableValidator
    {
        public ViewModel(IMediator mediator, IMessenger messenger)
        {
            ValidateAllProperties();
            _mediator = mediator;
            _messenger = messenger;
#if DEBUG
            UserName = "admin";
            Password = "admin";
#endif
        }

        [ObservableProperty]
        [Required(ErrorMessage = "حقل مطلوب")]
        [NotifyCanExecuteChangedFor(nameof(LoginCommand))]
        [NotifyDataErrorInfo]
        private string _userName;

        [ObservableProperty]
        [Required(ErrorMessage = "حقل مطلوب")]
        [NotifyCanExecuteChangedFor(nameof(LoginCommand))]
        [NotifyDataErrorInfo]
        private string _password;

        private bool CanLogin() => !HasErrors;

        [RelayCommand(CanExecute = nameof(CanLogin))]
        private async Task Login()
        {
            using(BusyWorkRunner.CreateBusyWork(DoBusyWork))
            {
                Result<User> result = await _mediator.Send(new Shared.Commands.Users.GetUserByUserNameAndPassword(UserName, Password));
                if(result.IsSuccess)
                {
                    _messenger.Send(new Messages.Users.LoginSucceded(result.Value));
                }
                else
                {
                    _messenger.Send(new Messages.Users.LoginFailed());
                }
            }
        }

        public DoBusyWork DoBusyWork { get; } = new DoBusyWork();
        private readonly IMediator _mediator;
        private readonly IMessenger _messenger;
    }
}
