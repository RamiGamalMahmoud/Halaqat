using CommunityToolkit.Mvvm.ComponentModel;
using System;

namespace Halaqat.Shared.Models
{
    [ObservableObject]
    public partial class Circle : DeletableObject
    {
        private Circle()
        {

        }

        public Circle(string name)
        {
            Name = name;
        }
        public DateTime DateCreated { get => _dateCreated; private set => SetProperty(ref _dateCreated, value); }
        private DateTime _dateCreated;

        [ObservableProperty]
        private string _name;
    }
}
