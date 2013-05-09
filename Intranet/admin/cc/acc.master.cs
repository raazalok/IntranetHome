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

public partial class admin_cc_accmaster : System.Web.UI.MasterPage
{
    public Employee emp;

  
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            emp = (Employee) Session["Emp"];
            String footer= String.Format(Resources.IHome.CopyRight, DateTime.Now.Year);
            l4.Text = footer;
            aFo.Attributes.Add("title", footer);
            SetDetails();
        }
        catch (Exception)
        {
            Response.Redirect("../../login.aspx");
        }    
    }

    protected void SetDetails()
    {
        lm.Text = BllUtility.GetMenu((int)Regions.CC, new HttpContextCacheAdapter(), Languages.English);
        ltm.Text = BllUtility.GetMarquee((int)Regions.CC, new HttpContextCacheAdapter());
        la.Text = BllUtility.GetEmployeePermissionsByUser(emp);
    }
}
