using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


public partial class view : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["IntranetConString"].ConnectionString);
        SqlCommand cmd = new SqlCommand("select top 1 contents from IntranetContent order by id desc;", con);
        //cmd.CommandType = CommandType.StoredProcedure;
        //cmd.Parameters.AddWithValue("@SiteID", 1);
        //cmd.Parameters.AddWithValue("@RegionId", 1);
        //cmd.Parameters.AddWithValue("@Contents", CKEditor1.Text);
        //cmd.Parameters.AddWithValue("@Status", 1);
        //cmd.Parameters.AddWithValue("@UpdatedBy", "02236");
        //cmd.Parameters.AddWithValue("@Version", 1);
        
        SqlDataAdapter sd=new SqlDataAdapter(cmd);
        DataTable dt=new DataTable();
        sd.Fill(dt);
        l.Text = dt.Rows[0][0].ToString();
    }
}