using System.Collections.ObjectModel;

namespace Halaqat.Shared.Models
{
    public partial class Teacher : Employee
    {
        public Collection<Circle> Circles { get; } = [];
    }
}
