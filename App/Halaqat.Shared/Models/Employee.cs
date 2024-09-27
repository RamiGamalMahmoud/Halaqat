using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.ObjectModel;

namespace Halaqat.Shared.Models
{
    [ObservableObject]
    public partial class Employee : DeletableObject
    {
        [ObservableProperty]
        private string _name;

        [ObservableProperty]
        private DateTime _dateCreated;

        public int JobTitleId { get; set; }
        public JobTitle JobTitle { get => _jobTitle; set => SetProperty(ref _jobTitle, value); }
        private JobTitle _jobTitle;

        public int AcademicQualificationId { get; set; }
        public AcademicQualification AcademicQualification { get => _academicQualification; set => SetProperty(ref _academicQualification, value); }
        private AcademicQualification _academicQualification;

        public int AddressId { get; set; }
        public Address Address
        {
            get => _address;
            set => SetProperty(ref _address, value);
        }
        private Address _address;

        public int? GenderId { get; set; }
        public Gender Gender { get => _gender; set => SetProperty(ref _gender, value); }
        private Gender _gender;

        public Collection<Phone> Phones { get; } = [];

    }
}
