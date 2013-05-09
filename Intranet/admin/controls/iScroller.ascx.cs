using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Com.Powergrid.Intranet.Bll;
using Com.Powergrid.Intranet.Model;
using Com.Powergrid.Intranet.Utility;
using Resources;

public partial class admin_controls_iScroller : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        GetGallery(Convert.ToInt32(Request.QueryString["e"]));
    }

    protected void GetGallery(int galleryId)
    {
        List<Photos> photos = BllPhotoGallery.GetPhotoListByGalleryId(galleryId, new NullObjectCache());
        if (photos != null)
        {
            int siteId = BllPhotoGallery.GetSiteIdByGalleryId(galleryId);
            String regionSite =
            Utility.GetImageFolder(
                BllMenu.GetActiveSites(new HttpContextCacheAdapter()).First(x => x.SiteId == siteId).SuperParentId);

            lm.Text = GetMarkup(photos, regionSite, siteId);
            RegisterScript();
        }
        else
        {
            lm.Text = IHome.No_Photo_For_Current_Gallery;
        }
    }

    protected void RegisterScript()
    {
        StringBuilder sbr = new StringBuilder();
        sbr.Append(@"<script type='text/javascript'>");
        //sbr.Append("alert('hi')");
        sbr.Append(@"$(document).ready(function () {");
        sbr.Append(@"Galleria.configure({");
        sbr.Append(@"carousel: false,");
        sbr.Append(@"imageCrop: false,");
        sbr.Append(@"overlayOpacity: 0.2,");
        sbr.Append(@"youtube: {");
        sbr.Append(@"modestbranding: 1,");
        sbr.Append(@"autohide: 1,");
        sbr.Append(@"color: 'white',");
        sbr.Append(@"hd: 1,");
        sbr.Append(@"rel: 0,");
        sbr.Append(@"showinfo: 0}});");
        sbr.Append("Galleria.run('#galleria', { autoplay: true });");
        sbr.Append("});");
        sbr.Append(@"</script>");
        if (!Page.ClientScript.IsClientScriptBlockRegistered("gall"))
        {
            Page.ClientScript.RegisterStartupScript(GetType(), "gall", sbr.ToString());
        }
    }

    protected String GetMarkup(List<Photos> photos,String region,int siteId)
    {
        StringBuilder sbr = new StringBuilder();
        sbr.Append("<div id='galleria' style='height: 400px;'>");
        foreach (var p in photos)
        {
            sbr.Append("<a href='");
            sbr.Append(@"../../ifd/Gallery/");
            sbr.Append(region);
            sbr.Append(@"/");
            sbr.Append(siteId);
            sbr.Append(@"/");
            sbr.Append(p.GalleryId);
            sbr.Append(@"/");
            sbr.Append(p.PictureUrl);
            sbr.Append("'>");
            sbr.Append("<img data-title='");
            sbr.Append(p.AltText);
            sbr.Append("' data-description='");
            sbr.Append(p.AltText);
            sbr.Append("' src='");
            sbr.Append(@"../../ifd/Gallery/");
            sbr.Append(region);
            sbr.Append(@"/");
            sbr.Append(siteId);
            sbr.Append(@"/");
            sbr.Append(p.GalleryId);
            sbr.Append(@"/");
            sbr.Append(p.PictureUrl);
            sbr.Append(@"'/>");
            sbr.Append(@"</a>");
        }
        sbr.Append(@"</div>");
        return sbr.ToString();
    }
}
