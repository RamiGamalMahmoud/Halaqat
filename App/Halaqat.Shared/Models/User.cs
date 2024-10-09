using System;

namespace Halaqat.Shared.Models
{
    public class User : ModelBase
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime DateCreated { get; set; }

        public bool IsActive { get; set; }
    }
}
