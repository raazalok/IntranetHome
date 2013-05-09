using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace Com.Powergrid.Intranet.Dal
{
    public class DalEmployee
    {
        private const String IntranetConString = "IntranetConString";
        private const String EmpConString = "EMPDETConString";

        
        public static DataSet GetLogin(String empNo, String password)
        {
            var db = DatabaseFactory.CreateDatabase(EmpConString);
            const String sqlCmd = "IGetUserLogin";
            var cmd = db.GetStoredProcCommand(sqlCmd);
            db.AddInParameter(cmd, "@empNo", DbType.String, empNo);
            db.AddInParameter(cmd, "@password", DbType.String, password);
            var ds= new DataSet();
            ds = db.ExecuteDataSet(cmd);
            return ds;
        }

        public static DataSet GetEmployeeDetail(String empNo)
        {
            var db = DatabaseFactory.CreateDatabase(EmpConString);
            const String sqlCmd = "IGetUserDetail";
            var cmd = db.GetStoredProcCommand(sqlCmd);
            db.AddInParameter(cmd, "@empNo", DbType.String, empNo);
            var ds = new DataSet();
            ds = db.ExecuteDataSet(cmd);
            return ds;
        }
    }
}
