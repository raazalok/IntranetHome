using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Com.Powergrid.Intranet.Bll;
using Com.Powergrid.Intranet.Model;
using Com.Powergrid.Intranet.Utility;

public partial class user_cc_department : System.Web.UI.Page
{
    private Employee emp;
    private int SiteId;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            emp = (Employee)Session["Emp"];
            if(!Page.IsPostBack)
            {
                SetMenus(Convert.ToInt32(EncDec.UrlDecode(Request.QueryString["d"])));
            }
        }
        catch (Exception ex)
        {
            //Response.Redirect("../../login.aspx");
            Response.Write(ex.Message);
        }
    }

    protected void SetMenus(int siteId)
    {
        if (Page.Master != null)
        {
            Literal lMyApplications = (Literal)Page.Master.FindControl("lma");
            if (lMyApplications != null)
            {
                lMyApplications.Text = BllUtility.GetApplications(siteId, Languages.Hindi, (emp.EmpNo), new NullObjectCache());
            }

            Literal lm = (Literal)Page.Master.FindControl("lm");
            lm.Text = BllUtility.GetMenu(siteId, new NullObjectCache(), Languages.English);

            Literal ltm = (Literal)Page.Master.FindControl("ltm");
            ltm.Text = BllUtility.GetMarquee(siteId, new NullObjectCache());
        }
    }
}