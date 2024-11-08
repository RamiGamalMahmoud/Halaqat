using Halaqat.Shared.Models;
using System.Collections.Generic;
using System.Linq;

namespace Halaqat.Services
{
    public static class ProgramDayItemService
    {
        public static string SamorizeItems(IEnumerable<ProgramDayItem> items)
        {
            if (items.Count() == 1)
            {
                return items.First().ToString();
            }
            if (items.Count() > 2)
            {
                ProgramDayItem firstItem = items.FirstOrDefault();
                ProgramDayItem lastItem = items.LastOrDefault();
                return $"من {firstItem.Sorah.Name} إلى {lastItem.Sorah.Name}";
            }

            return string.Join(", ", items.Select(x => x.Sorah.Name));
        }
    }
}
