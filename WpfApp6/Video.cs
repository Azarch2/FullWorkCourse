using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WpfApp6
{
    public partial class Video
    {
        public long Id { get; set; }
        public string Resolution { get; set; }
        public long Size { get; set; }
        public string Format { get; set; }
        public string Name { get; set; }
        public string Time { get; set; }
        public string Preview { get; set; }
        public long CatalogId { get; set; } 
        public byte[] VideoData { get; set; }

        public virtual Catalog Catalog { get; set; }
        public virtual AuthorOfVideo AuthorOfVideo { get; set; }
        public virtual PlaceOfVideo PlaceOfVideo { get; set; }
    }
}
