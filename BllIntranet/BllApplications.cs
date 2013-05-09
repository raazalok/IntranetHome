using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Com.Powergrid.Intranet.Dal;
using Com.Powergrid.Intranet.Model;
using Com.Powergrid.Intranet.Utility;

namespace Com.Powergrid.Intranet.Bll
{
   public class BllApplications
    {
       public static List<Applications> GetApplicationsBySiteId(int siteId, ICacheStorage adapter)
       {
           String storageKey = String.Format("Applications_{0}", siteId);
           List<Applications> applicationsList = adapter.Retrieve<List<Applications>>(storageKey);

           if (applicationsList == null)
           {
               var ds = DalApplications.GetApplicationListBySiteId(siteId);
               applicationsList = BindModel.GetApplications(ds.Tables[0]);
               if (applicationsList != null && applicationsList.Count != 0)
                   adapter.Store(storageKey, applicationsList);
               return applicationsList;
           }
           return applicationsList;
       }

       public static void SetApplications(Applications app)
       {
           DalApplications.SetApplication(app.ApplicationNameEn,app.ApplicationNameHi,app.SiteId,app.Url,app.UpdatedBy,app.Status);
       }
    }
}
