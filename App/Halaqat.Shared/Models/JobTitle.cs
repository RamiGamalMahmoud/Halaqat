using CommunityToolkit.Mvvm.ComponentModel;
using System;

namespace Halaqat.Shared.Models
{
    [ObservableObject]
    public partial class JobTitle : ModelBase
    {
        [ObservableProperty]
        private string _name;

        [ObservableProperty]
        private DateTime _dateCreated;
    }
}
