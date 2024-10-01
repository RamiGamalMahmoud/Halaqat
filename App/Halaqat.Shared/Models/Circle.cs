using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.ObjectModel;

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
            DateCreated = DateTime.Now;
        }

        public Collection<Student> Students { get; } = [];

        public DateTime DateCreated { get => _dateCreated; private set => SetProperty(ref _dateCreated, value); }
        private DateTime _dateCreated;

        public int? TeacherId { get; set; }
        public Teacher Teacher { get => _teacher; set => SetProperty(ref _teacher, value); }
        private Teacher _teacher;

        [ObservableProperty]
        private string _name;
    }
}
