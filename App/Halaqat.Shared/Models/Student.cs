using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Halaqat.Shared.Models
{
    [ObservableObject]
    public partial class Student : DeletableObject
    {
        private Student()
        {
            
        }

        public Student(string name, DateTime dateOfBirth, Address address, Gender gender, ICollection<Phone> phones)
        {
            Name = name;
            DateOfBirth = dateOfBirth;
            Address = address;
            Gender = gender;
            Phones = phones;
        }

        [ObservableProperty]
        private string _name;

        [ObservableProperty]
        private DateTime _dateOfBirth;

        [ObservableProperty]
        private DateOnly _dateCreated;

        public int AddressId { get; set; }
        public Address Address
        {
            get => _address;
            set => SetProperty(ref _address, value);
        }
        private Address _address;

        public int GenderId { get; set; }
        public Gender Gender { get => _gender; set => SetProperty(ref _gender, value); }
        private Gender _gender;

        public int? CircleId { get; set; }
        public Circle Circle { get => _circle; set => SetProperty(ref _circle, value); }
        private Circle _circle;

        public int? ProgramId { get; set; }
        public Program Program { get => _program; set => SetProperty(ref _program, value); }
        private Program _program;

        public EducationalStage EducationalStage { get => _educationalStage; set => SetProperty(ref _educationalStage, value); }
        private EducationalStage _educationalStage;

        public Class Class { get => _class; set => SetProperty(ref _class, value); }
        private Class _class;

        public ICollection<Phone> Phones { get; private set; } = [];
        public Collection<ProgramDayAppreciation> ProgramDayAppreciations { get; } = [];
    }
}
