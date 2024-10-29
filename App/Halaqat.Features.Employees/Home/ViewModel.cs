using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Halaqat.Shared.Models;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Halaqat.Features.Employees.Home
{
    internal partial class ViewModel(IMediator mediator, IMessenger messenger) : ObservableObject
    {
        [RelayCommand]
        public async Task LoadDataAsync(bool reload )
        {
            _allEmployees = await mediator.Send(new Shared.Commands.Common.GetAllCommand<Employee>(reload));
            Employees = _allEmployees;
            JobTitles = await mediator.Send(new Shared.Commands.Common.GetAllCommand<JobTitle>(reload));
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

        [RelayCommand]
        private void ShowAll()
        {
            JobTitle = null;
            SearchTerm = null;
        }

        partial void OnJobTitleChanged(JobTitle oldValue, JobTitle newValue)
        {
            Employees = _allEmployees.Where(x => newValue is null || x.JobTitle == newValue);
        }

        partial void OnSearchTermChanged(string oldValue, string newValue)
        {
            if(newValue is null || string.IsNullOrEmpty(newValue))
            {
                Employees = _allEmployees;
                return;
            }
            Employees = _allEmployees.Where(x => x.Name.Contains(newValue));
        }

        private bool CanPerformEmployeeAction(Employee employee) => employee is not null;


        private IEnumerable<Employee> _allEmployees;

        [ObservableProperty]
        private IEnumerable<Employee> _employees;

        [ObservableProperty]
        private IEnumerable<JobTitle> _jobTitles;

        [ObservableProperty]
        private JobTitle _jobTitle;

        [ObservableProperty]
        private string _searchTerm;
    }
}
