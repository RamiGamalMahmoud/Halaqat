using CommunityToolkit.Mvvm.ComponentModel;
using Halaqat.Shared.Common;
using Halaqat.Shared.Models;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Halaqat.Features.Programs
{
    internal partial class ProgramDataModel : DataModelBase<Program>
    {
        public ProgramDataModel(Program model) : base(model)
        {
            if (model is not null)
            {
                Name = model.Name;
                ExpectedDuration = model.ExpectedDuration;
                Notes = model.Notes;
                ProgramDays = new ObservableCollection<ProgramDay>(model.ProgramDays);
            }

            ProgramDays.CollectionChanged += ProgramDays_CollectionChanged;

            ValidateAllProperties();
        }

        private void ProgramDays_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            OnPropertyChanged();
        }

        public override void Update(Program model = null)
        {
            Program modelToUpdated = model is null ? Model : model;
            modelToUpdated.Name = Name;
            modelToUpdated.ExpectedDuration = (int)ExpectedDuration;
            modelToUpdated.Notes = Notes;

            modelToUpdated.ProgramDays.Clear();
            foreach (ProgramDay programDay in ProgramDays)
            {
                modelToUpdated.ProgramDays.Add(programDay);
            }
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
        [Range(1, 5000, ErrorMessage = "error")]
        private int? _expectedDuration;

        [ObservableProperty]
        private string _notes;

        [ObservableProperty]
        private ObservableCollection<ProgramDay> _programDays = [];
    }
}
