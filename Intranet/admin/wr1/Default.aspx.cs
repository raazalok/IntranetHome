using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        div5.Visible = true;
        HttpFileCollection uploadFilCol = Request.Files;
        for (int i = 0; i < uploadFilCol.Count; i++)
        {
            HttpPostedFile file = uploadFilCol[i];
            string fileExt = Path.GetExtension(file.FileName).ToLower();
            string fileName = Path.GetFileName(file.FileName);
            if (fileName != string.Empty)
            {
                try
                {
                    if (fileExt == ".jpg" || fileExt == ".gif" || fileExt == ".bmp" || fileExt == ".jpeg" || fileExt == ".png")
                    {
                        file.SaveAs(Server.MapPath("~/Images/") + fileName);

                        if (i == 0)
                        {
                            Image1.ImageUrl = "~/Images/" + fileName;
                        }
                        if (i == 1)
                        {
                            Image2.ImageUrl = "~/Images/" + fileName;
                        }
                        if (i == 2)
                        {
                            Image3.ImageUrl = "~/Images/" + fileName;
                        }
                        if (i == 3)
                        {
                            Image4.ImageUrl = "~/Images/" + fileName;
                        }
                        if (i == 4)
                        {
                            Image5.ImageUrl = "~/Images/" + fileName;
                        }
                        if (i == 5)
                        {
                            Image6.ImageUrl = "~/Images/" + fileName;
                        }
                        if (i == 6)
                        {
                            Image7.ImageUrl = "~/Images/" + fileName;
                        }
                        if (i == 7)
                        {
                            Image8.ImageUrl = "~/Images/" + fileName;
                        }
                        if (i == 8)
                        {
                            Image9.ImageUrl = "~/Images/" + fileName;
                        }
                        if (i == 9)
                        {
                            Image10.ImageUrl = "~/Images/" + fileName;
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }

    protected void ButtonMore_Click(object sender, EventArgs e)
    {
        if (ButtonMore.Text == "Only five")
        {
            div2.Visible = false;
            ButtonMore.Text = "Add 10 Photos";
            div4.Visible = false;
        }
        else if (ButtonMore.Text == "Add 10 Photos")
        {
            div2.Visible = true;
            ButtonMore.Text = "Only five";
            div4.Visible = true;
        }
    }
}