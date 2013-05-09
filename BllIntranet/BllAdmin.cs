using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Com.Powergrid.Intranet.Dal;
using Com.Powergrid.Intranet.Model;
using Com.Powergrid.Intranet.Utility;
using System.Data;


namespace Com.Powergrid.Intranet.Bll
{
    public class BllAdmin
    {
        public static List<Permissions> GetPermissionsByUser(String empNo, ICacheStorage adapter)
        {
            String storageKey = String.Format("Permission_{0}", empNo);
            List<Permissions> pList = adapter.Retrieve<List<Permissions>>(storageKey);

            if (pList == null)
            {
                var ds = DalAdmin.GetPermissionByUser(empNo);
                pList = BindModel.GetPermissions(ds.Tables[0]);
                if (pList != null && pList.Count != 0)
                    adapter.Store(storageKey, pList);
                return pList;
            }
            return pList;
        }

        public static List<EmployeePermissions> GetEmployeePermissionsByUser(String empNo, ICacheStorage adapter)
        {
            String storageKey = String.Format("Site_Permission_{0}", empNo);
            List<EmployeePermissions> epList = adapter.Retrieve<List<EmployeePermissions>>(storageKey);

            if (epList == null)
            {
                var ds = DalAdmin.GetPermissionByUser(empNo);
                epList = BindModel.GetEmployeePermissionsByUser(ds.Tables[0]);
                if (epList != null && epList.Count != 0)
                    adapter.Store(storageKey, epList);
                return epList;
            }
            return epList;
        }

        public static Dictionary<int, String> GetRegionsByRights(String empNo, Roles role, ICacheStorage adapter)
        {
            List<EmployeePermissions> permission = GetEmployeePermissionsByUser(empNo, adapter);
            if (permission == null)
                return null;
            Dictionary<int,String> rights=new Dictionary<int, string>();
            foreach (var p in permission)
            {
                if(p.Roles==role && !rights.ContainsKey(p.SiteId))
                {
                    rights.Add(p.SiteId,p.SiteName);
                }
            }
            return rights;
        }
    }
}
