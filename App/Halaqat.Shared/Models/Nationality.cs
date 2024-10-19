﻿using CommunityToolkit.Mvvm.ComponentModel;

namespace Halaqat.Shared.Models
{
    [ObservableObject]
    public partial class Nationality : ModelBase
    {
        [ObservableProperty]
        private string _name;
    }
}
