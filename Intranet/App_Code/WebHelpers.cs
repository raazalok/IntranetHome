using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for WebHelpers
/// </summary>
public class WebHelpers
{
    //
    // Disable button with no secondary JavaScript function call.
    //
    public static void DisableButtonOnClick(Button buttonControl)
    {
        DisableButtonOnClick(buttonControl, string.Empty);
    }

    //
    // Disable button with a JavaScript function call.
    //
    public static void DisableButtonOnClick(Button buttonControl, string clientFunction)
    {
        StringBuilder sb = new StringBuilder(128);

        // If the page has ASP.NET validators on it, this code ensures the
        // page validates before continuing.
        sb.Append("if ( typeof( Page_ClientValidate ) == 'function' ) { ");
        sb.Append("if ( ! Page_ClientValidate() ) { return false; } } ");

        // Disable this button.
        sb.Append("this.disabled = true;");
        sb.Append("this.value  = 'Processing. This may take some time...';");

        // If a secondary JavaScript function has been provided, and if it can be found,
        // call it. Note the name of the JavaScript function to call should be passed without
        // parens.
        if (!String.IsNullOrEmpty(clientFunction))
        {
            sb.AppendFormat("if ( typeof( {0} ) == 'function' ) {{ {0}() }};", clientFunction);
        }

        // GetPostBackEventReference() obtains a reference to a client-side script function 
        // that causes the server to post back to the page (ie this causes the server-side part 
        // of the "click" to be performed).
#pragma warning disable 612,618
        sb.Append(buttonControl.Page.GetPostBackEventReference(buttonControl) + ";");
#pragma warning restore 612,618

        // Add the JavaScript created a code to be executed when the button is clicked.
        buttonControl.Attributes.Add("onclick", sb.ToString());
    }

}