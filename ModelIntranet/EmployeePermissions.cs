using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Com.Powergrid.Intranet.Model
{
    public class EmployeePermissions
    {
        public int SiteId { get; set; }
        public String SiteName { get; set; }
        public String SiteNameEn { get; set; }
        public String SiteNameHi { get; set; }
        public Sites Parent { get; set; }
        public int ParentId { get; set; }

        public SiteType SiteType { get; set; }
        public int Status { get; set; }
        public int PermissionId { get; set; }
        public String PermissionName { get; set; }
        public Roles Roles { get; set; }
        public String Link { get; set; }
    }
}
