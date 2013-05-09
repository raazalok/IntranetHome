<%@ WebHandler Language="C#" Class="Upload" %>

using System;
using System.Web;
using System.IO;
using Com.Powergrid.Intranet.Bll;
using Com.Powergrid.Intranet.Model;

public class Upload : IHttpHandler, System.Web.SessionState.IRequiresSessionState
{

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";
        context.Response.Expires = -1;
        try
        {
            Employee emp = (Employee)HttpContext.Current.Session["emp"];
            HttpPostedFile postedFile = context.Request.Files["Filedata"];
            Gallery g=new Gallery();

            BllPhotoGallery.SetPhotoGallery(g);
            
            string tempPath = Utility.GetImageFolder(emp.IRegion) + @"/2";
            string savepath = context.Server.MapPath(tempPath);
            string filename = postedFile.FileName;
            if (!Directory.Exists(savepath))
                Directory.CreateDirectory(savepath);

            postedFile.SaveAs(savepath + @"\" + filename);
            context.Response.Write(tempPath + "/" + filename);
            context.Response.StatusCode = 200;
        }
        catch (Exception ex)
        {
            context.Response.Write("Error: " + ex.Message);
        }
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }
}