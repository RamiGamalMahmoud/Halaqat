using CommunityToolkit.Mvvm.ComponentModel;
using System;

namespace Halaqat.Shared.Common
{
    public partial class SelectableObject<T>(T value, bool isSelected = false, Action action = null) : ObservableObject
    {
        [ObservableProperty]
        private bool _isSelected = isSelected;
        public T Value { get; } = value;

        partial void OnIsSelectedChanged(bool oldValue, bool newValue)
        {
            action?.Invoke();
        }

    }
}
