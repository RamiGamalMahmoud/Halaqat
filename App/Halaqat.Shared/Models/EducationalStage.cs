using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace Halaqat.Shared.Models
{
    [ObservableObject]
    public partial class EducationalStage : ModelBase
    {
        [ObservableProperty]
        private string _name;

        public Collection<Class> Classes { get; } = [];
    }
}
