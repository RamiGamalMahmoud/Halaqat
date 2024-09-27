using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Halaqat.Shared.Models;

namespace Halaqat.Features.Employees.Editor
{
    partial class EditorViewModelBase
    {
        [RelayCommand(CanExecute = nameof(CanInsertPhone))]
        private void InsertPhone()
        {
            DataModel.Phones.Add(new Phone() { Number = PhoneNumber });
            PhoneNumber = "";
        }

        [RelayCommand]
        private void RemovePhone(Phone phone) => DataModel.Phones.Remove(phone);

        private bool CanInsertPhone() => !string.IsNullOrWhiteSpace(PhoneNumber);

        [ObservableProperty]
        private string _phoneNumber;
    }
}
