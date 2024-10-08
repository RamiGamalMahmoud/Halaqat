using CommunityToolkit.Mvvm.ComponentModel;
using Halaqat.Shared.Models;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Specialized;

namespace Halaqat.Features.Students
{
    internal partial class StudentDataModel : ObservableValidator
    {
        public StudentDataModel(Student model)
        {
            if(model is null)
            {
                DateCreated = DateOnly.FromDateTime(DateTime.Now);
            }
            else
            {
                Model = model;
                Name = model.Name;
                DateOfBirth = model.DateOfBirth;
                DateCreated = model.DateCreated;
                Address = model.Address;
                City = model.Address.City;
                District = model.Address.District;
                Street = Address.Street;
                Circle = model.Circle;
                Phones = new ObservableCollection<Phone>(model.Phones);
                Gender = model.Gender;
                Program = model.Program;
            }

            Phones.CollectionChanged += Phones_CollectionChanged;
            ValidateAllProperties();
        }

        private void Phones_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            OnPropertyChanged();
        }

        public void UpdateModel(Student model)
        {
            model.Name = Name;
            model.Address.City = City;
            model.Address.District = District;
            model.Address.Street = Street;
            model.Gender = Gender;
            model.Circle = Circle;
            model.Phones.Clear();
            model.DateOfBirth =(DateTime) DateOfBirth;
            model.Program = Program;

            foreach (Phone phone in Phones)
            {
                model.Phones.Add(phone);
            }
        }

        public Student Model { get; }

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
        private DateOnly _dateCreated;

        [ObservableProperty]
        [Required(ErrorMessage = "حقل مطلوب")]
        [NotifyDataErrorInfo]
        [NotifyPropertyChangedFor(nameof(IsValid))]
        private DateTime? _dateOfBirth = null;

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

        [ObservableProperty]
        [Required(ErrorMessage = "حقل مطلوب")]
        [NotifyDataErrorInfo]
        [NotifyPropertyChangedFor(nameof(IsValid))]
        private Circle _circle;

        [ObservableProperty]
        private Program _program;
        public ObservableCollection<Phone> Phones { get; } = [];
    }
}
