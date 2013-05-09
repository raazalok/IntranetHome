using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Com.Powergrid.Intranet.Bll;
using Com.Powergrid.Intranet.Model;
using Com.Powergrid.Intranet.Utility;
using Resources;
using log4net;
using log4net.Config;

public partial class admin_controls_addgallery : System.Web.UI.UserControl
{
    public Employee emp;
    public String PhotoGalleryPath = ConfigurationManager.AppSettings["PhotoGalleryPath"];
    private static readonly ILog Log =
        LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

    static admin_controls_addgallery()
    {
        XmlConfigurator.Configure();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            emp = (Employee)Session["Emp"];
            WebHelpers.DisableButtonOnClick(BtnUpload, "showPleaseWait");
            if (!Page.IsPostBack)
            {
                //SetDropDowns();
            }
        }
        catch (Exception)
        {
            Response.Redirect("../../login.aspx");
        }
    }

    protected void BtnShow_Click(object sender, EventArgs e)
    {
        pnlExisting.Visible = true;
        pnlNew.Visible = false;
        pEdit.Visible = false;
        Utility.BindAdminRegionsDropDown(emp.EmpNo, Roles.ADD_PHOTO_GALLERY, new HttpContextCacheAdapter(), dSitesEx);
    }

    protected void BtnShowExisting_Click(object sender, EventArgs e)
    {
        int siteId = Convert.ToInt32(dSitesEx.SelectedValue);
        gExisting.DataSource = BllPhotoGallery.GetGalleryListBySiteId(siteId, new NullObjectCache());
        gExisting.DataBind();
    }

    protected void BtnNew_Click(object sender, EventArgs e)
    {
        pnlExisting.Visible = false;
        pnlNew.Visible = true;
        pEdit.Visible = false;
        Utility.BindAdminRegionsDropDown(emp.EmpNo, Roles.ADD_PHOTO_GALLERY, new HttpContextCacheAdapter(), dSites);
    }

    protected void BtnEdit_Click(object sender, EventArgs e)
    {
        pnlExisting.Visible = false;
        pnlNew.Visible = false;
        pEdit.Visible = true;
        Utility.BindAdminRegionsDropDown(emp.EmpNo, Roles.ADD_PHOTO_GALLERY, new HttpContextCacheAdapter(), dEdit);
    }

    protected void gExisting_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            HyperLink hView = (HyperLink)e.Row.Cells[1].Controls[1];
            hView.Text = IHome.View;
            hView.Target = "_blank";
            hView.NavigateUrl = "../" + Utility.GetImageFolder(emp.IRegion) + "/viewgallery.aspx" + QueryStringModule.Encrypt("e=" + e.Row.Cells[3].Text);
            //String status = e.Row.Cells[5].Text;
            //hView.NavigateUrl = "../" + Utility.GetImageFolder(emp.IRegion) + "/viewgallery.aspx?" +("e=" + e.Row.Cells[3].Text);
            String status = e.Row.Cells[5].Text;
            e.Row.Cells[5].Text = status == "1" ? IHome.Active : IHome.InActive;
            e.Row.Cells[7].Text = Utility.FormatDateWithTime(Convert.ToDateTime(e.Row.Cells[7].Text));
            bool isDefault = Convert.ToBoolean(e.Row.Cells[8].Text);
            e.Row.Cells[8].Text = isDefault ? IHome.Yes : IHome.No;
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

    protected void BtnUpload_Click(object sender, EventArgs e)
    {
        div5.Visible = true;
        Gallery g = new Gallery();
        g.SiteId = Convert.ToInt32(dSites.SelectedValue);
        g.GalleryName = tGalleryName.Text.Trim();
        g.Status = 1;
        g.UpdatedBy = emp.EmpNo;
        g.IsDefault = chkMakeDefault.Checked;
        HttpFileCollection uploadFilCol = Request.Files;
        bool containsFile = false;

        for (int i = 0; i < uploadFilCol.Count; i++)
        {
            HttpPostedFile file = uploadFilCol[i];
            string fileName = Path.GetFileName(file.FileName);
            if (fileName != string.Empty)
            {
                containsFile = true;
                break;
            }
        }

        if (!containsFile)
            return;
        int galleryId = BllPhotoGallery.SetPhotoGallery(g);
        List<Photos> pList = new List<Photos>();

        String regionSite =
            Utility.GetImageFolder(
                BllMenu.GetActiveSites(new HttpContextCacheAdapter()).First(x => x.SiteId == g.SiteId).SuperParentId);

        String folder = ConfigurationManager.AppSettings["PhotoGalleryPath"] + regionSite + @"/" + g.SiteId + @"/" +
                        galleryId.ToString(CultureInfo.InvariantCulture);
        String folderF = folder + @"/";
        bool isExists = Directory.Exists(Server.MapPath(folder));
        if (!isExists)
            Directory.CreateDirectory(Server.MapPath(folder));

        for (int i = 0; i < uploadFilCol.Count; i++)
        {
            HttpPostedFile file = uploadFilCol[i];
            string fileExt = Path.GetExtension(file.FileName).ToLower();
            string fileName = Path.GetFileName(file.FileName);
            if (fileName != string.Empty)
            {
                try
                {
                    if (fileExt == ".jpg" || fileExt == ".gif" || fileExt == ".bmp" || fileExt == ".jpeg" ||
                        fileExt == ".png")
                    {
                        file.SaveAs(Server.MapPath(folderF) + fileName);
                        Photos p = new Photos();
                        p.GalleryId = galleryId;
                        p.PictureUrl = fileName;
                        p.UpdatedBy = emp.EmpNo;
                        p.Status = 1;

                        if (i == 0)
                        {
                            Image1.ImageUrl = folderF + fileName;
                            p.AltText = t1.Value;
                        }
                        if (i == 1)
                        {
                            Image2.ImageUrl = folderF + fileName;
                            p.AltText = t2.Value;
                        }
                        if (i == 2)
                        {
                            Image3.ImageUrl = folderF + fileName;
                            p.AltText = t3.Value;
                        }
                        if (i == 3)
                        {
                            Image4.ImageUrl = folderF + fileName;
                            p.AltText = t4.Value;
                        }
                        if (i == 4)
                        {
                            Image5.ImageUrl = folderF + fileName;
                            p.AltText = t5.Value;
                        }
                        if (i == 5)
                        {
                            Image6.ImageUrl = folderF + fileName;
                            p.AltText = t6.Value;
                        }
                        if (i == 6)
                        {
                            Image7.ImageUrl = folderF + fileName;
                            p.AltText = t7.Value;
                        }
                        if (i == 7)
                        {
                            Image8.ImageUrl = folderF + fileName;
                            p.AltText = t8.Value;
                        }
                        if (i == 8)
                        {
                            Image9.ImageUrl = folderF + fileName;
                            p.AltText = t9.Value;
                        }
                        if (i == 9)
                        {
                            Image10.ImageUrl = folderF + fileName;
                            p.AltText = t10.Value;
                        }
                        pList.Add(p);
                    }
                }
                catch (Exception ex)
                {
                    Log.Error("Add Gallery: Error in Image Upload EmpNo: " + emp.EmpNo + " : " + ex.Message + " : " +
                              ex.TargetSite + " : " + ex.StackTrace);
                    RegisterErrorScript();
                }
            }
        }

        try
        {
            BllPhotoGallery.SetGalleryPhotoList(pList);
            RegisterSuccessScript();
        }
        catch (Exception ex)
        {
            BllPhotoGallery.RemovePhotoGallery(g.GalleryId);
            RegisterErrorScript();
        }
    }

    protected void gEdit_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            String status = e.Row.Cells[5].Text;
            e.Row.Cells[5].Text = status == "1" ? IHome.Active : IHome.InActive;
            e.Row.Cells[7].Text = Utility.FormatDateWithTime(Convert.ToDateTime(e.Row.Cells[7].Text));
        }
    }

    protected void BShowEdit_Click(object sender, EventArgs e)
    {
        ShowEdit();
        fieldS.Visible = false;
        gPhotos.Visible = false;
    }

    protected void CheckedChanged(object sender, EventArgs e)
    {
        CheckBox c = (CheckBox)sender;
        //GridView gview = (GridView) c.Parent.Parent.Parent.Parent;
        GridViewRow grow = (GridViewRow)c.Parent.Parent;
        int siteId = Convert.ToInt32(grow.Cells[2].Text);
        int gallerId = Convert.ToInt32(grow.Cells[3].Text);
        BllPhotoGallery.SetDefaultPhotoGallery(siteId, gallerId);
        ShowEdit();
    }

    protected void ShowEdit()
    {
        int siteId = Convert.ToInt32(dEdit.SelectedValue);
        gEdit.DataSource = BllPhotoGallery.GetGalleryListBySiteId(siteId, new NullObjectCache());
        gEdit.DataBind();
    }

    protected void gEdit_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataKey galleryId = gEdit.SelectedDataKey;
        int siteId = (int)galleryId.Values[0];
        ViewState["SiteId"] = siteId;
        ViewState["GalleryId"] = (int)galleryId.Values[1];
        gPhotos.DataSource = BllPhotoGallery.GetAllPhotoListByGalleryId((int)galleryId.Values[1], new NullObjectCache());
        gPhotos.DataBind();
        fieldS.Visible = true;
        gPhotos.Visible = true;
    }

    protected void gPhotos_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            ImageButton b = (ImageButton)e.Row.FindControl("ib1");
            int siteId = (int)ViewState["SiteId"];
            String regionSite =
             Utility.GetImageFolder(
                 BllMenu.GetActiveSites(new HttpContextCacheAdapter()).First(x => x.SiteId == siteId).SuperParentId);
            String url = PhotoGalleryPath + regionSite + @"/" + siteId + @"/" + (int)ViewState["GalleryId"] + @"/";
            b.ImageUrl = url + e.Row.Cells[4].Text;

            String status = e.Row.Cells[5].Text;
            if (status == "1")
            {
                e.Row.Cells[5].Text = IHome.Active;
                e.Row.BackColor = ColorCode.GridActive;
            }
            else
            {
                e.Row.Cells[5].Text = IHome.InActive;
                e.Row.BackColor = ColorCode.GridInActive;
            }
            e.Row.Cells[7].Text = Utility.FormatDateWithTime(Convert.ToDateTime(e.Row.Cells[7].Text));
        }
    }

    protected void ChkBlockChanged(object sender, EventArgs e)
    {
        CheckBox c = (CheckBox)sender;
        GridViewRow grow = (GridViewRow)c.Parent.Parent;

        int galleryId = Convert.ToInt32(ViewState["GalleryId"]);
        String pictureUrl = grow.Cells[4].Text;
        int status = c.Checked ? 1 : 0;
        BllPhotoGallery.SetPhotoFromGalleryPhotoList(emp.EmpNo, galleryId, pictureUrl, status);
        gPhotos.DataSource = BllPhotoGallery.GetAllPhotoListByGalleryId((int)ViewState["GalleryId"], new NullObjectCache());
        gPhotos.DataBind();
    }

    protected void BtnUploadSingle_Click(object sender, EventArgs e)
    {
        HttpPostedFile file = fNew.PostedFile;
        if (file != null)
        {
            String extension = Path.GetExtension(file.FileName);
            string fileExt = extension.ToLower();
            string fileName = Path.GetFileName(file.FileName);
            if (fileName != string.Empty)
            {
                try
                {
                    if (fileExt == ".jpg" || fileExt == ".gif" || fileExt == ".bmp" || fileExt == ".jpeg" ||
                        fileExt == ".png")
                    {
                        List<Photos> pList = new List<Photos>();
                        Photos p = new Photos();
                        p.Status = 1;
                        p.UpdatedBy = emp.EmpNo;
                        p.AltText = t11.Value;
                        p.GalleryId = (int)ViewState["GalleryId"];
                        p.PictureUrl = fNew.PostedFile.FileName;
                        int siteId = (int)ViewState["SiteId"];
                        String regionSite = Utility.GetImageFolder(BllMenu.GetActiveSites(new HttpContextCacheAdapter()).First(x => x.SiteId == siteId).SuperParentId);

                        String folder = ConfigurationManager.AppSettings["PhotoGalleryPath"] + regionSite + @"/" + siteId + @"/" + p.GalleryId.ToString(CultureInfo.InvariantCulture);
                        String folderF = folder + @"/";
                        file.SaveAs(Server.MapPath(folderF) + fileName);
                        pList.Add(p);
                        BllPhotoGallery.SetGalleryPhotoList(pList);
                        RegisterSuccessScript();
                    }
                }
                catch (Exception ex)
                {
                    Log.Error("Add Single Image Error: EmpNo: " + emp.EmpNo + "Exception: " + ex.Message);
                    RegisterErrorScript();
                }
            }
        }
    }

    public  void RegisterErrorScript()
    {
        StringBuilder sbr = new StringBuilder();
        sbr.Append(@"<script type='text/javascript'>");
        sbr.Append(@"alert('Some Error Occurred.");
        sbr.Append(@"</script>");
        if (!Page.ClientScript.IsClientScriptBlockRegistered("Error"))
        {
            Page.ClientScript.RegisterStartupScript(GetType(), "Error", sbr.ToString());
        }
    }

    public void RegisterSuccessScript()
    {
        StringBuilder sbr = new StringBuilder();
        sbr.Append(@"<script type='text/javascript'>");
        sbr.Append(@"alert('Success.");
        sbr.Append(@"</script>");
        if (!Page.ClientScript.IsClientScriptBlockRegistered("Success"))
        {
            Page.ClientScript.RegisterStartupScript(GetType(), "Success", sbr.ToString());
        }
    }
}