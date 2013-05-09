using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Com.Powergrid.Intranet.Model;
using Com.Powergrid.Intranet.Dal;

namespace Com.Powergrid.Intranet.Bll
{
   public class BllGeneric
    {
       public static bool IsValidEmployee(String empNo, String password)
       {
           return false;
       }

       public string ValidateUserAD(Employee emp)
       {
           //DALI.DALEmployee objDALEmployee = new DALI.DALEmployee();
           //return objDALEmployee.ValidateUserAD(objEmployeeInfo);
           return "";
       }

       public static void SetUserLoginDetails(string empNo, string rawUrl, string requestType, string applicationPath, string appRelativeCurrentExecutionFilePath,
            string contentEncoding, int contentLength, string currentExecutionFilePath, bool isLocal, bool isSecureConnection, string path, string pathInfo,
            string physicalApplicationPath, string physicalPath, int totalBytes, string url, string urlReferrer, string userAgent,
            string userHostAddress, string userHostName, string browser, string httpMethod, string filePath)
       {
           DalGeneric.SetUserLoginDetails(empNo, rawUrl, requestType, applicationPath, appRelativeCurrentExecutionFilePath, contentEncoding, contentLength, currentExecutionFilePath, isLocal, isSecureConnection,
           path, pathInfo, physicalApplicationPath, physicalPath, totalBytes, url, urlReferrer, userAgent, userHostAddress, userHostName,
           browser, httpMethod, filePath);
       }
    }
}
