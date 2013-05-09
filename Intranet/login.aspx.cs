using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Com.Powergrid.Intranet.Bll;
using Com.Powergrid.Intranet.Model;
using Com.Powergrid.Intranet.Utility;

public partial class login : System.Web.UI.Page
{
    protected override void InitializeCulture()
    {
        if (Request.Form["dL"] != null)
        {
            String language = Request.Form["dL"];
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);
            HttpContext.Current.Session["CultureName"] = language;
        }
        
        base.InitializeCulture();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        l4.Text = String.Format(Resources.IHome.CopyRight, DateTime.Now.Year);
        if (!Page.IsPostBack)
        {
            CheckForLoggedInData();
        }
    }

    protected void LoginButton_Click(object sender, EventArgs e)
    {
        Employee emp = BllEmployee.GetLogin(tUserName.Text, tPassword.Text, new HttpContextCacheAdapter());
        if (emp != null)
        {
            HttpContext.Current.Session.Add("Emp", emp);
            //Keeping user signed in for 5 hours
            if (chkr.Checked)
                SetCookie(emp.EmpNo);
            //Login the user details
            LoginAudit(emp.EmpNo);
            Utility.RedirectToHome(emp.IRegion);
        }
    }


    protected void LoginAudit(string empNo)
    {
        HttpContext context = HttpContext.Current;
        BllGeneric.SetUserLoginDetails(empNo, context.Request.RawUrl, context.Request.RequestType, context.Request.ApplicationPath,
                                           context.Request.AppRelativeCurrentExecutionFilePath,
                                           Convert.ToString(context.Request.ContentEncoding), context.Request.ContentLength,
                                           context.Request.CurrentExecutionFilePath, context.Request.IsLocal, context.Request.IsSecureConnection,
                                           context.Request.Path, context.Request.PathInfo, context.Request.PhysicalApplicationPath,
                                           context.Request.PhysicalPath, context.Request.TotalBytes, Convert.ToString(context.Request.Url),
                                           Convert.ToString(context.Request.UrlReferrer), context.Request.UserAgent,
                                           Utility.GetIpAddress(), context.Request.UserHostName,
                                           context.Request.Browser.Browser, context.Request.HttpMethod, context.Request.FilePath);
    }

    protected void CheckForLoggedInData()
    {
        HttpCookie pid = Request.Cookies["powergridid"];
        if (pid != null)
        {
            Employee emp = BllEmployee.GetEmployeeDetail(EncDec.RSADecrypt(pid.Value),new HttpContextCacheAdapter());
            HttpContext.Current.Session.Add("Emp", emp);
            LoginAudit(emp.EmpNo);
            Utility.RedirectToHome(emp.IRegion);
        }
    }

    protected void SetCookie(String empNo)
    {
        HttpCookie pid = new HttpCookie("powergridid");
        pid.Value = EncDec.RSAEncrypt(empNo);
        pid.HttpOnly = true;
        pid.Expires = DateTime.Now.AddHours(5);
        Response.Cookies.Add(pid);
    }

    


}