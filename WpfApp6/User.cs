using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WpfApp6
{
    public partial class User
    {
        public User()
        {
            Catalog = new HashSet<Catalog>();
        }

        public long Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public long Storage { get; set; }
        public long MaxStorage { get; set; }

        public virtual ICollection<Catalog> Catalog { get; set; }
    }
}
