using CommunityToolkit.Mvvm.ComponentModel;
using Halaqat.Shared.Common;
using Halaqat.Shared.Models;
using System;
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
            }
        }

        public override void Update(Circle model)
        {
            throw new NotImplementedException();
        }

        [ObservableProperty]
        [Required(ErrorMessage = "حقل مطلوب")]
        [NotifyDataErrorInfo]
        [NotifyPropertyChangedFor(nameof(IsValid))]
        private string _name;

        [ObservableProperty]
        private DateTime _dateCreated;
    }
}
