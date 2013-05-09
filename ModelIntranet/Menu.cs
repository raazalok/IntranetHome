using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Com.Powergrid.Intranet.Model
{
    public class Menu
    {
        public int MenuId { get; set; }
        public String TextEnglish { get; set; }
        public String TextHindi { get; set; }
        public int? ParentId { get; set; }
        public bool Status { get; set; }
        public String UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public int? MenuOrder { get; set; }
        public String MenuLink { get; set; }
        //public SiteType SiteType { get; set; }
        public int MenuLevel { get; set; }
        public bool IsAdded { get; set; }
        public int RegionId { get; set; }
        public bool IsVisibleToOther { get; set; }
        public int LinkSiteId { get; set; }
    }
}
