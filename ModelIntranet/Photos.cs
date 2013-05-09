using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Com.Powergrid.Intranet.Model
{
    public class Photos
    {
        public int GalleryId { get; set; }
        public String PictureUrl { get; set; }
        public String AltText { get; set; }
        public String UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public int Status { get; set; }
    }
}
