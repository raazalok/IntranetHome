using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Com.Powergrid.Intranet.Model
{
    public class Sites
    {
        public int SiteId { get; set; }
        public String SiteName { get; set; }
        public String SiteNameEn { get; set; }
        public String SIteNameHi { get; set; }
        public Sites Parent { get; set; }
        public int ParentId { get; set; }
        public SiteType SiteType { get; set; }
        public int Status { get; set; }
        public int SuperParentId { get; set; }
        public String UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}
