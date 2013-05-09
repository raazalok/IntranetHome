using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Com.Powergrid.Intranet.Bll;
using Com.Powergrid.Intranet.Model;
using Com.Powergrid.Intranet.Utility;

public partial class user_cc_cc : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lm.Text = BllUtility.GetMenu(Regions.CC, new HttpContextCacheAdapter(), Languages.English);
        ltm.Text = BllUtility.GetMarquee(Regions.CC, new HttpContextCacheAdapter());
    }
}
