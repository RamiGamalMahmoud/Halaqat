using CommunityToolkit.Mvvm.ComponentModel;

namespace Halaqat.Shared.Models
{
    [ObservableObject]
    public partial class Address : ModelBase
    {
        [ObservableProperty]
        private string _street;

        [ObservableProperty]
        private string _district;

        public int CityId { get; set; }
        public City City { get => _city; set => SetProperty(ref _city, value); }
        private City _city;

    }
}
