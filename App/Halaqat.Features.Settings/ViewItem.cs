using CommunityToolkit.Mvvm.ComponentModel;
using System;

namespace Halaqat.Features.Settings
{
    internal partial class ViewItem(string title, Action action, bool isSelected = false) : ObservableObject
    {
        public string Title { get; } = title;
        public Action Action { get; } = action;

        public bool IsSelected { get => _isSelected; private set => SetProperty(ref _isSelected, value); }
        private bool _isSelected = isSelected;

        public void InvokeAction()
        {
            Select();
            Action?.Invoke();
        }

        public void Select() => IsSelected = true;
        public void DeSelect() => IsSelected = false;
    }
}
