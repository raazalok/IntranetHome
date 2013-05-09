using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Com.Powergrid.Intranet.Bll;
using Com.Powergrid.Intranet.Model;
using Com.Powergrid.Intranet.Utility;

public partial class user_cc_Default : System.Web.UI.Page
{
    private Employee emp;
   
   protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            emp = (Employee)Session["Emp"];
            SetMenus();
        }
        catch (Exception)
        {
            Response.Redirect("../../login.aspx");
        }
    }

    protected void SetMenus()
    {
        if (Page.Master != null)
        {
            Literal lMyApplications = (Literal) Page.Master.FindControl("lma");
            if (lMyApplications != null)
            {
                lMyApplications.Text = BllUtility.GetApplications((int)Regions.CC, emp.Language, (emp.EmpNo), new NullObjectCache());
            }

            Literal lm = (Literal)Page.Master.FindControl("lm");
            lm.Text = BllUtility.GetMenu((int)Regions.CC, new HttpContextCacheAdapter(), emp.Language);

            Literal ltm = (Literal)Page.Master.FindControl("ltm");
            ltm.Text = BllUtility.GetMarquee((int)Regions.CC, new HttpContextCacheAdapter());
        }
    }
}