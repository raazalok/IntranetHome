using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Com.Powergrid.Intranet.Bll;
using Com.Powergrid.Intranet.Model;
using Com.Powergrid.Intranet.Utility;
using Resources;
using log4net;
using log4net.Config;

public partial class admin_cc_addgallery : System.Web.UI.Page
{
    public Employee emp;
    public String UiCulture;
    private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

    static admin_cc_addgallery()
        {
            XmlConfigurator.Configure();
        }
    protected override void InitializeCulture()
    {
        if (HttpContext.Current.Session != null && HttpContext.Current.Session["CultureName"] is string)
        {
            UiCulture = (String)HttpContext.Current.Session["CultureName"];
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(UiCulture);
        }
        base.InitializeCulture();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            emp = (Employee)Session["Emp"];
            if (!Page.IsPostBack)
            {
         //       SetDropDowns();
            }
        }
        catch (Exception)
        {
            Response.Redirect("../../login.aspx");
        }
    }

    
}