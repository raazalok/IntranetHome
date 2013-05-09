using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace Com.Powergrid.Intranet.Dal
{
    public class DalMenu
    {
        private const String IntranetConString = "IntranetConString";
        
        public static DataTable GetActiveMenuByUser(int siteId)
        {
            var ds = new DataSet();
            var db = DatabaseFactory.CreateDatabase(IntranetConString);
            const string sqlCommand = "IGetActiveMenuBySite";
            var dbCommand = db.GetStoredProcCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@siteId", DbType.Int32, siteId);
            ds = db.ExecuteDataSet(dbCommand);
            return ds.Tables[0];
        }

        public static DataTable GetActiveMarqueeBySite(int siteId)
        {
            var ds = new DataSet();
            var db = DatabaseFactory.CreateDatabase(IntranetConString);
            const string sqlCommand = "IGetMarqueeBySite";
            var dbCommand = db.GetStoredProcCommand(sqlCommand);
            db.AddInParameter(dbCommand, "@siteId", DbType.Int32, siteId);
            ds = db.ExecuteDataSet(dbCommand);
            return ds.Tables[0];
        }

        public static DataTable GetActiveSites()
        {
            var ds = new DataSet();
            var db = DatabaseFactory.CreateDatabase(IntranetConString);
            const string sqlCommand = "IGetActiveSites";
            var dbCommand = db.GetStoredProcCommand(sqlCommand);
            ds = db.ExecuteDataSet(dbCommand);
            return ds.Tables[0];
        }
    }
}
