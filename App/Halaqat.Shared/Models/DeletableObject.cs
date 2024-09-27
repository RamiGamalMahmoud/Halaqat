using System;

namespace Halaqat.Shared.Models
{
    public class DeletableObject : ModelBase
    {
        public DateTime? DateDeleted { get; set; }
        public bool IsDeleted { get; set; } = false;

        public void Delete()
        {
            DateDeleted = DateTime.Now;
            IsDeleted = true;
        }

        public void Restore()
        {
            DateDeleted = null;
            IsDeleted = false;
        }
    }
}
