using CommunityToolkit.Mvvm.ComponentModel;
using System;

namespace Halaqat.Shared.Models
{
    [ObservableObject]
    public partial class ProgramDayAppreciation : ModelBase
    {
        public int ProgramDayId { get; set; }
        [ObservableProperty]
        private ProgramDay _programDay;

        public int AppreciationId { get; set; }
        [ObservableProperty]
        private Appreciation _appreciation;

        public int ProgramDayItemTypeId { get; set; }
        [ObservableProperty]
        private ProgramDayItemType _programDayItemType;

        public int? TeacherId { get; set; }
        [ObservableProperty]
        private Teacher _teacher;

        public int StudentId { get; set; }
        public Student Student { get; set; }

        public DateTime DateAppreciated { get; set; }
    }
}
