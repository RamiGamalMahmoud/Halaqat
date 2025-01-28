using CommunityToolkit.Mvvm.ComponentModel;
using Halaqat.Shared.Models;

namespace Halaqat.Features.Circles.Home.CircleDetails
{
    internal partial class ViewModel(Circle circle) : ObservableObject
    {
        public Circle Circle { get; } = circle;
    }
}