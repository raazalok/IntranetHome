using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Com.Powergrid.Intranet.Model
{
    public class Applications
    {
        public int ApplicationId { get; set; }
        public String ApplicationNameEn { get; set; }
        public String ApplicationNameHi { get; set; }
        public int SiteId { get; set; }
        public String Url { get; set; }
        public int Status { get; set; }
        public int SortOrder { get; set; }
        public String UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}
