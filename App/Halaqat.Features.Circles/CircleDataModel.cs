using CommunityToolkit.Mvvm.ComponentModel;
using Halaqat.Shared.Common;
using Halaqat.Shared.Models;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Halaqat.Features.Circles
{
    internal partial class CircleDataModel : DataModelBase<Circle>
    {
        public CircleDataModel(Circle model) : base(model)
        {
            if(model is not null)
            {
                Name = model.Name;
                DateCreated = model.DateCreated;
                Teacher = model.Teacher;

                foreach(Student student in model.Students)
                {
                    Students.Add(student);
                }
            }
            ValidateAllProperties();
        }

        public override void Update(Circle model)
        {
            model.Name = Name;
            model.Teacher = Teacher;
        }

        [ObservableProperty]
        [Required(ErrorMessage = "حقل مطلوب")]
        [NotifyDataErrorInfo]
        [NotifyPropertyChangedFor(nameof(IsValid))]
        private string _name;

        [ObservableProperty]
        [Required(ErrorMessage = "حقل مطلوب")]
        [NotifyDataErrorInfo]
        [NotifyPropertyChangedFor(nameof(IsValid))]
        private Teacher _teacher;

        public ObservableCollection<Student> Students { get; } = [];

        [ObservableProperty]
        private DateTime _dateCreated;
    }
}
