using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Halaqat.Shared.Models;
using MediatR;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Halaqat.Features.Employees.Home
{
    internal partial class ViewModel(IMediator mediator, IMessenger messenger) : ObservableObject
    {
        [RelayCommand]
        public async Task LoadDataAsync(bool reload )
        {
            Employees = await mediator.Send(new Shared.Commands.Common.GetAllCommand<Employee>(reload));
        }

        [RelayCommand]
        private async Task ShowCreate()
        {
            await mediator.Send(new Shared.Commands.Common.ShowCreateModelViewCommand<Employee>());
        }

        [RelayCommand(CanExecute = nameof(CanPerformEmployeeAction))]
        private async Task Update(Employee employee)
        {
            await mediator.Send(new Shared.Commands.Common.ShowEditModelViewCommand<Employee>(employee));
        }

        [RelayCommand(CanExecute = nameof(CanPerformEmployeeAction))]
        private async Task Remove(Employee employee)
        {
            await mediator.Send(new Shared.Commands.Common.RemoveModelCommand<Employee>(employee));
            messenger.Send(new Shared.Messages.Notifications.SuccessNotification());
        }

        async partial void OnSearchTermChanged(string oldValue, string newValue)
        {
            if(newValue is null || string.IsNullOrEmpty(newValue))
            {
                Employees = await mediator.Send(new Shared.Commands.Common.GetAllCommand<Employee>(false));
                return;
            }
            Employees = await mediator.Send(new Shared.Commands.Employees.GetByName(newValue));
        }

        private bool CanPerformEmployeeAction(Employee employee) => employee is not null;


        [ObservableProperty]
        private IEnumerable<Employee> _employees;

        [ObservableProperty]
        private string _searchTerm;
    }
}
