using CommunityToolkit.Mvvm.ComponentModel;
using System;

namespace Halaqat.Shared.Models
{
    [ObservableObject]
    public partial class ProgramDayAppreciation : ModelBase
    {
        [ObservableProperty]
        private ProgramDay _programDay;

        [ObservableProperty]
        private Appreciation _appreciation;

        [ObservableProperty]
        private ProgramDayItemType _programDayItemType;

        public DateTime DateAppreciated { get; set; }
    }
}
