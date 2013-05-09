<%@ WebHandler Language="C#" Class="vcardqr" %>

using System;
using System.Web;

public class vcardqr : IHttpHandler {
    
    public void ProcessRequest (HttpContext context)
    {
       
        string web = "http://chart.apis.google.com/chart?chs=200x200&cht=qr&chld=|0&chl=Alok";
        context.Response.ContentType = "image/png";
        context.Response.Redirect(web);
        //context.Response.Write("Hello World");
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}