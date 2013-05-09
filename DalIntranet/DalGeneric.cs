using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.DirectoryServices;
using Com.Powergrid.Intranet.Model;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace Com.Powergrid.Intranet.Dal
{
    public class DalGeneric
    {
        private const String IntranetConString = "IntranetConString";
        private const String EmpConString = "EMPDETConString";

        public DataTable GetAvailableCultures()
        {
            DataSet ds = new DataSet();
            Database db = DatabaseFactory.CreateDatabase(IntranetConString);
            const string sqlCommand = "IGetCultureList";
            var dbCommand = db.GetStoredProcCommand(sqlCommand);
            ds = db.ExecuteDataSet(dbCommand);
            return ds.Tables[0];
        }

        public static void SetUserLoginDetails(string empNo, string rawUrl, string requestType, string applicationPath, string appRelativeCurrentExecutionFilePath,
               string contentEncoding, int contentLength, string currentExecutionFilePath, bool isLocal, bool isSecureConnection,
               string path, string pathInfo, string physicalApplicationPath, string physicalPath, int totalBytes, string url, string urlReferrer,
               string userAgent, string userHostAddress, string userHostName, string browser, string httpMethod, string filePath)
        {
            Database db = DatabaseFactory.CreateDatabase(IntranetConString);
            const string sqlCommand = "ISetUserLoginDetails";
            var dbcommand = db.GetStoredProcCommand(sqlCommand);
            db.AddInParameter(dbcommand, "@EmpNo", DbType.String, empNo);
            db.AddInParameter(dbcommand, "@RawUrl", DbType.String, rawUrl);
            db.AddInParameter(dbcommand, "@RequestType", DbType.String, requestType);
            db.AddInParameter(dbcommand, "@ApplicationPath", DbType.String, applicationPath);

            db.AddInParameter(dbcommand, "@AppRelativeCurrentExecutionFilePath", DbType.String, appRelativeCurrentExecutionFilePath);
            db.AddInParameter(dbcommand, "@ContentEncoding", DbType.String, contentEncoding);

            db.AddInParameter(dbcommand, "@ContentLength", DbType.Int32, contentLength);
            db.AddInParameter(dbcommand, "@CurrentExecutionFilePath", DbType.String, currentExecutionFilePath);

            db.AddInParameter(dbcommand, "@IsLocal", DbType.Boolean, isLocal);
            db.AddInParameter(dbcommand, "@IsSecureConnection", DbType.Boolean, isSecureConnection);

            db.AddInParameter(dbcommand, "@Path", DbType.String, path);
            db.AddInParameter(dbcommand, "@PathInfo", DbType.String, pathInfo);

            db.AddInParameter(dbcommand, "@PhysicalApplicationPath", DbType.String, physicalApplicationPath);
            db.AddInParameter(dbcommand, "@PhysicalPath", DbType.String, physicalPath);

            db.AddInParameter(dbcommand, "@TotalBytes", DbType.Int32, totalBytes);
            db.AddInParameter(dbcommand, "@Url", DbType.String, url);

            db.AddInParameter(dbcommand, "@UrlReferrer", DbType.String, urlReferrer);
            db.AddInParameter(dbcommand, "@UserAgent", DbType.String, userAgent);

            db.AddInParameter(dbcommand, "@UserHostAddress", DbType.String, userHostAddress);
            db.AddInParameter(dbcommand, "@UserHostName", DbType.String, userHostName);

            db.AddInParameter(dbcommand, "@WebBrowser", DbType.String, browser);
            db.AddInParameter(dbcommand, "@HttpMethod", DbType.String, httpMethod);

            db.AddInParameter(dbcommand, "@FilePath", DbType.String, filePath);
            db.AddInParameter(dbcommand, "@LoggedIn", DbType.DateTime, DateTime.Now);
            db.ExecuteNonQuery(dbcommand);
        }
    }
}
