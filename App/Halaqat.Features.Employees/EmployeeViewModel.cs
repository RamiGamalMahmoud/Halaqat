using CommunityToolkit.Mvvm.ComponentModel;
using Halaqat.Shared.Models;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Halaqat.Features.Employees
{
    internal partial class EmployeeViewModel : ObservableValidator
    {
        public EmployeeViewModel(Employee model)
        {
            if(model is null)
            {
                Model = new Employee();
                DateCreated = DateTime.Now;
            }

            else
            {
                Model = model;
                Name = model.Name;
                AcademicQualification = model.AcademicQualification;
                JobTitle = model.JobTitle;
                DateCreated = model.DateCreated;
                Address = model.Address;
                City = model.Address.City;
                District = model.Address.District;
                Street = Address.Street;
                Phones = new ObservableCollection<Phone>(model.Phones);
                Gender = model.Gender;

            }
            Phones.CollectionChanged += Phones_CollectionChanged;
            ValidateAllProperties();
        }

        private void Phones_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            OnPropertyChanged();
        }

        public void UpdateModel(Employee model)
        {
            model.Name = Name;
            model.Address.City = City;
            model.Address.District = District;
            model.Address.Street = Street;
            model.AcademicQualification = AcademicQualification;
            model.JobTitle = JobTitle;
            model.Gender = Gender;
            model.Phones.Clear();

            foreach(Phone phone in Phones)
            {
                model.Phones.Add(phone);
            }
        }

        public bool IsValid => !HasErrors;

        [ObservableProperty]
        [Required(ErrorMessage = "حقل مطلوب")]
        [NotifyDataErrorInfo]
        [NotifyPropertyChangedFor(nameof(IsValid))]
        private string _name;

        [ObservableProperty]
        [Required(ErrorMessage = "حقل مطلوب")]
        [NotifyDataErrorInfo]
        [NotifyPropertyChangedFor(nameof(IsValid))]
        private DateTime _dateCreated;

        [ObservableProperty]
        [Required(ErrorMessage = "حقل مطلوب")]
        [NotifyDataErrorInfo]
        [NotifyPropertyChangedFor(nameof(IsValid))]
        private AcademicQualification _academicQualification;

        [ObservableProperty]
        [Required(ErrorMessage = "حقل مطلوب")]
        [NotifyDataErrorInfo]
        [NotifyPropertyChangedFor(nameof(IsValid))]
        private JobTitle _jobTitle;

        [ObservableProperty]
        private Address _address;

        [ObservableProperty]
        [Required(ErrorMessage = "حقل مطلوب")]
        [NotifyDataErrorInfo]
        [NotifyPropertyChangedFor(nameof(IsValid))]
        private City _city;

        [ObservableProperty]
        [Required(ErrorMessage = "حقل مطلوب")]
        [NotifyDataErrorInfo]
        [NotifyPropertyChangedFor(nameof(IsValid))]
        private string _district;

        [ObservableProperty]
        [Required(ErrorMessage = "حقل مطلوب")]
        [NotifyDataErrorInfo]
        [NotifyPropertyChangedFor(nameof(IsValid))]
        private string _street;

        [ObservableProperty]
        [Required(ErrorMessage = "حقل مطلوب")]
        [NotifyDataErrorInfo]
        [NotifyPropertyChangedFor(nameof(IsValid))]
        private Gender _gender;

        public ObservableCollection<Phone> Phones { get; } = [];

        public Employee Model { get; }
    }
}
