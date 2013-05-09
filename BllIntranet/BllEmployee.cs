using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Linq;
using System.Text;
using Com.Powergrid.Intranet.Dal;
using Com.Powergrid.Intranet.Model;
using Com.Powergrid.Intranet.Utility;

namespace Com.Powergrid.Intranet.Bll
{
    public class BllEmployee
    {
        public static bool ValidateUserThroughAD(string empNo, string password)
        {
            string msg = string.Empty;
            try
            {
                const string ldapPath = "LDAP://192.168.1.1/CN=glpi,CN=users,DC=powergrid,DC=net";
                var userIo = new DirectoryEntry(ldapPath);
                if (IsUserInAD(empNo, ldapPath, userIo, password))
                {
                    userIo.Username = empNo;
                    userIo.Password = password;
                    userIo.RefreshCache();
                    msg = "VALIDATED";
                }
                else
                {
                    msg = "VALIDATED";
                }
            }
            catch (Exception)
            {
                msg = "WRONG";
            }
            return msg == "VALIDATED";
        }

        public static bool IsUserInAD(string empNo, string ldapPath, DirectoryEntry userIo, string password)
        {
            userIo.AuthenticationType = AuthenticationTypes.Secure;
            userIo.Username = empNo;
            userIo.Password = password;
            var deSearcher = new DirectorySearcher(userIo) { Filter = string.Format("(SAMAccountName={0})", empNo) };
            deSearcher.PropertiesToLoad.Add("cn");
            var sResult = deSearcher.FindOne();
            return sResult == null;
        }

        public static Employee GetLogin(String empNo, String password, ICacheStorage adapter)
        {
            var ds = DalEmployee.GetLogin(empNo, password);
            if (ds != null && ds.Tables.Count!=0)
            {
                Employee emp = BindModel.GetEmployee(ds.Tables[0]);
                emp.EPermissions = BllAdmin.GetEmployeePermissionsByUser(empNo, adapter);
                return emp;
            }
            return null;
        }

        public static Employee GetEmployeeDetail(String empNo, ICacheStorage adapter)
        {
            var ds = DalEmployee.GetEmployeeDetail(empNo);
            if (ds != null)
            {
                Employee emp = BindModel.GetEmployee(ds.Tables[0]);
                emp.EPermissions = BllAdmin.GetEmployeePermissionsByUser(empNo, adapter);
                return emp;
            }
            return null;
        }
    }
}
