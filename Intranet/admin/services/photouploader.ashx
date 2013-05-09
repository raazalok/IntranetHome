<%@ WebHandler Language="C#" Class="photouploader" %>

using System;
using System.Web;

public class photouploader : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        context.Response.Write("Hello World");
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}