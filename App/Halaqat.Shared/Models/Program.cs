using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace Halaqat.Shared.Models
{
    [ObservableObject]
    public partial class Program : ModelBase
    {
        [ObservableProperty]
        private string _name;

        [ObservableProperty]
        private int _expectedDuration;

        [ObservableProperty]
        private string _notes;

        public Collection<ProgramDay> ProgramDays { get; } = [];
    }
}
