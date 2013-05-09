using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Com.Powergrid.Intranet.Bll;
using Com.Powergrid.Intranet.Model;
using Com.Powergrid.Intranet.Utility;

/// <summary>
/// Summary description for Utiliy
/// </summary>
public class Utility
{
    public static void SetUiCulture(DropDownList dl)
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(dl.SelectedValue);
        CultureInfo cultureInfo = new CultureInfo(dl.SelectedValue);
        Thread.CurrentThread.CurrentUICulture = cultureInfo;
    }

    public static String GetIpAddress()
    {
        HttpContext context = HttpContext.Current;
        string sIPAddress = context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
        if (string.IsNullOrEmpty(sIPAddress))
        {
            return context.Request.ServerVariables["REMOTE_ADDR"];
        }
        string[] ipArray = sIPAddress.Split(new Char[] { ',' });
        return ipArray[0];
    }

    public static String GetImageFolder(Regions region)
    {
        //const string basic = @"~/ifd/gallery/";
        string basic = String.Empty;
        switch (region)
        {
            case Regions.CC:
                return basic + Enum.GetName(typeof(Regions), Regions.CC);
            case Regions.NR1:
                return basic + Enum.GetName(typeof(Regions), Regions.NR1);
            case Regions.NR2:
                return basic + Enum.GetName(typeof(Regions), Regions.NR2);
            case Regions.WR1:
                return basic + Enum.GetName(typeof(Regions), Regions.WR1);
            case Regions.WR2:
                return basic + Enum.GetName(typeof(Regions), Regions.WR2);
            case Regions.SR1:
                return basic + Enum.GetName(typeof(Regions), Regions.SR1);
            case Regions.SR2:
                return basic + Enum.GetName(typeof(Regions), Regions.SR2);
            case Regions.ER1:
                return basic + Enum.GetName(typeof(Regions), Regions.ER1);
            case Regions.ER2:
                return basic + Enum.GetName(typeof(Regions), Regions.ER2);
            case Regions.NER:
                return basic + Enum.GetName(typeof(Regions), Regions.NER);
            case Regions.POSCC:
                return basic + Enum.GetName(typeof(Regions), Regions.POSCC);
            case Regions.NRLDC:
                return basic + Enum.GetName(typeof(Regions), Regions.NRLDC);
            case Regions.NERLDC:
                return basic + Enum.GetName(typeof(Regions), Regions.NERLDC);
            case Regions.SRLDC:
                return basic + Enum.GetName(typeof(Regions), Regions.SRLDC);
            case Regions.WRLDC:
                return basic + Enum.GetName(typeof(Regions), Regions.WRLDC);
            case Regions.ERLDC:
                return basic + Enum.GetName(typeof(Regions), Regions.ERLDC);
            default:
                return basic + Enum.GetName(typeof(Regions), Regions.INVALID);
        }
    }

    public static String GetImageFolder(int siteId)
    {
        switch (siteId)
        {
            case 1:
                return Enum.GetName(typeof(Regions), Regions.CC);
            case 2:
                return Enum.GetName(typeof (Regions), Regions.NR1);
            case 3:
                return Enum.GetName(typeof (Regions), Regions.SR1);
            case 4:
                return Enum.GetName(typeof (Regions), Regions.POSCC);
            case 5:
                return  Enum.GetName(typeof(Regions), Regions.SR2);
            case 6:
                return  Enum.GetName(typeof(Regions), Regions.NER);
            case 7:
                return  Enum.GetName(typeof(Regions), Regions.WR1);
            case 8:
                return  Enum.GetName(typeof(Regions), Regions.WR2);
            case 9:
                return  Enum.GetName(typeof(Regions), Regions.ER1);
            case 10:
                return  Enum.GetName(typeof(Regions), Regions.ER2);
            case 11:
                return  Enum.GetName(typeof(Regions), Regions.NR2);
            case 12:
                return  Enum.GetName(typeof(Regions), Regions.NRLDC);
            case 13:
                return  Enum.GetName(typeof(Regions), Regions.NERLDC);
            case 14:
                return  Enum.GetName(typeof(Regions), Regions.WRLDC);
            case 15:
                return  Enum.GetName(typeof(Regions), Regions.ERLDC);
            case 16:
                return  Enum.GetName(typeof(Regions), Regions.SRLDC);
            default:
                return  Enum.GetName(typeof(Regions), Regions.INVALID);
        }
    }

    public static void RedirectToHome(Regions region)
    {
        HttpResponse Response = HttpContext.Current.Response;

        switch (region)
        {
            case Regions.CC:
                Response.Redirect("user/cc");
                break;
            case Regions.NR1:
                Response.Redirect("user/nr1");
                break;
            case Regions.NR2:
                Response.Redirect("user/nr2");
                break;
            case Regions.ER1:
                Response.Redirect("user/er1");
                break;
            case Regions.ER2:
                Response.Redirect("user/er2");
                break;
            case Regions.WR1:
                Response.Redirect("user/wr1");
                break;
            case Regions.WR2:
                Response.Redirect("user/wr2");
                break;
            case Regions.SR1:
                Response.Redirect("user/sr1");
                break;
            case Regions.SR2:
                Response.Redirect("user/sr2");
                break;
            case Regions.NER:
                Response.Redirect("user/ner");
                break;
            case Regions.POSCC:
                Response.Redirect("user/poscc");
                break;
            case Regions.NRLDC:
                Response.Redirect("user/nrldc");
                break;
            case Regions.NERLDC:
                Response.Redirect("user/nerldc");
                break;
            case Regions.WRLDC:
                Response.Redirect("user/wrldc");
                break;
            case Regions.SRLDC:
                Response.Redirect("user/srldc");
                break;
            case Regions.ERLDC:
                Response.Redirect("user/erldc");
                break;
        }
    }

    public static void BindAdminRegionsDropDown(String empNo, Roles role, ICacheStorage adapter, DropDownList d)
    {
        d.DataSource = BllAdmin.GetRegionsByRights(empNo, role, adapter);
        d.DataTextField = "Value";
        d.DataValueField = "Key";
        d.DataBind();
    }

    public static String FormatDate(DateTime d)
    {
        return d.ToString("ddd. d MMM yyyy");
    }

    public static String FormatDateWithTime(DateTime d)
    {
        return d.ToString("ddd. MMM d yyyy HH:mm:s");
    }

    
}