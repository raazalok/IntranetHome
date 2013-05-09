using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class _Default : System.Web.UI.Page
{
    protected override void OnLoad(EventArgs e)
    {
        CKFinder.FileBrowser _FileBrowser = new CKFinder.FileBrowser();
        _FileBrowser.BasePath = "/intranet/ckfinder/";
        _FileBrowser.SetupCKEditor(CKEditor1);

    }
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void BtnSubmit_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["IntranetConString"].ConnectionString);
        SqlCommand cmd = new SqlCommand("ISetIntranetContent", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@SiteID", 1);
        cmd.Parameters.AddWithValue("@RegionId", 1);
        cmd.Parameters.AddWithValue("@Contents", CKEditor1.Text);
        cmd.Parameters.AddWithValue("@Status", 1);
        cmd.Parameters.AddWithValue("@UpdatedBy", "02236");
        cmd.Parameters.AddWithValue("@Version", 1);
        if(con.State==ConnectionState.Closed)
        {
            con.Open();
        }
        cmd.ExecuteNonQuery();
        if (con.State == ConnectionState.Open)
        {
            con.Close();
        }
    }
}