<%@ Application Language="C#" %>
<%@ Import Namespace="log4net" %>
<%@ Import Namespace="log4net.Config" %>

<script runat="server">
    private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    void Application_Start(object sender, EventArgs e) 
    {
        // Code that runs on application startup
        XmlConfigurator.Configure();
    }
    
    void Application_End(object sender, EventArgs e) 
    {
        //  Code that runs on application shutdown
    }
        
    void Application_Error(object sender, EventArgs e) 
    { 
        Exception ex = Server.GetLastError();
        Log.Debug("++ " + " Exception: " + ex + " IP: " + HttpContext.Current.Request.UserHostAddress);
        //Log.Debug("++++++++++++++++++++++++++++");
        //{
        //    Context.ClearError();
        //    Response.Write("Application_Error" + "<br/>");
        //    Response.Write("<b>Error Msg:</b>" + ex.Message + "<br/>" + "<b>End Error Msg<b/>");
        //}
    }

    void Session_Start(object sender, EventArgs e) 
    {
        // Code that runs when a new session is started
        //Response.Write("Session_Start" + "<br/>");

    }

    void Session_End(object sender, EventArgs e) 
    {
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.
        //Response.Write("Session_End" + "<br/>");

    }
       
</script>
