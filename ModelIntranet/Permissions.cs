using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Com.Powergrid.Intranet.Model
{
    public class Permissions
    {
        public int PermissionId { get; set; }
        public String PermissionName { get; set; }
        public String PermissionLink { get; set; }
        public String PermissionTo { get; set; }
        public int SiteId { get; set; }
    }
}
