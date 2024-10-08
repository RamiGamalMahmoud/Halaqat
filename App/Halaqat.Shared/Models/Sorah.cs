using System.Collections.ObjectModel;

namespace Halaqat.Shared.Models
{
    public class Sorah : ModelBase
    {
        public string Name { get; set; }

        public Collection<Verse> Verses { get; } = [];
    }
}
