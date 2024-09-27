using CommunityToolkit.Mvvm.ComponentModel;

namespace Halaqat.Shared.Models
{
    [ObservableObject]
    public partial class Gender : ModelBase
    {
        private Gender()
        {
            
        }

        public Gender(string name)
        {
            Name = name;
        }

        [ObservableProperty]
        private string _name;
    }
}
