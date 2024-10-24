using CommunityToolkit.Mvvm.ComponentModel;
using Halaqat.Shared.Models;
using System.ComponentModel.DataAnnotations;

namespace Halaqat.Features.Management.AcademicQualifications
{
    internal partial class AcademicQualificationDataModel : ObservableValidator
    {
        public AcademicQualificationDataModel(AcademicQualification model)
        {
            if (model is not null)
            {
                Model = model;
                Name = model.Name;
            }

            ValidateAllProperties();
        }

        public void Update()
        {
            Model.Name = Name;
        }

        public bool IsValid => !HasErrors;

        [ObservableProperty]
        [Required(ErrorMessage = "حقل مطلوب")]
        [NotifyDataErrorInfo]
        [NotifyPropertyChangedFor(nameof(IsValid))]
        private string _name;
        public AcademicQualification Model { get; }
    }
}
