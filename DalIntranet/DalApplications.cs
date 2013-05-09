using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace Com.Powergrid.Intranet.Dal
{
    public class DalApplications
    {
        private const String IntranetConString = "IntranetConString";
        private const String EmpConString = "EMPDETConString";

        public static DataSet GetApplicationListBySiteId(int siteId)
        {
            var db = DatabaseFactory.CreateDatabase(IntranetConString);
            const String sqlCmd = "IGetApplicationListBySiteId";
            var cmd = db.GetStoredProcCommand(sqlCmd);
            db.AddInParameter(cmd, "@siteId", DbType.Int32, siteId);
            var ds = new DataSet();
            ds = db.ExecuteDataSet(cmd);
            return ds;
        }

        public static void SetApplication(String applicationNameEn, String applicationNameHi, int siteId, String url, String updatedBy, int status)
        {
            var db = DatabaseFactory.CreateDatabase(IntranetConString);
            const String sqlCmd = "ISetApplication";
            var cmd = db.GetStoredProcCommand(sqlCmd);
               db.AddInParameter(cmd, "@ApplicationNameEn", DbType.String, applicationNameEn);
               db.AddInParameter(cmd, "@ApplicationNameHi", DbType.String, applicationNameHi);
               db.AddInParameter(cmd, "@siteId", DbType.Int32, siteId);
               db.AddInParameter(cmd, "@Url", DbType.String, url);
               db.AddInParameter(cmd, "@UpdatedBy", DbType.String, updatedBy);
            db.AddInParameter(cmd, "@Status", DbType.Int32, status);
            db.ExecuteNonQuery(cmd);
        }
    }
}
