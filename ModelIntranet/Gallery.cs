using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Com.Powergrid.Intranet.Model
{
    public class Gallery
    {
        public int SiteId { get; set; }
        public int GalleryId { get; set; }
        public String GalleryName { get; set; }
        public int Status { get; set; }
        public String UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public bool IsDefault { get; set; }
        public List<Photos> Photos { get; set; } 
    }
}
