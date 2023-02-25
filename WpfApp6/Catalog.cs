using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WpfApp6
{
    public partial class Catalog
    {
        public Catalog()
        {
            Video = new HashSet<Video>();
        }
        public long Id { get; set; }
        public string Name { get; set; }
        public double TotalSize { get; set; }
        public long UserId { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<Video> Video { get; set; }
    }
}
