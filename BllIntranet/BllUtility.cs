using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Com.Powergrid.Intranet.Model;
using Com.Powergrid.Intranet.Utility;
using Menu = Com.Powergrid.Intranet.Model.Menu;

namespace Com.Powergrid.Intranet.Bll
{
    public class BllUtility
    {
        //Get all the child of a parent menu item

        private static List<Menu> GetChildItems(Menu parentMenu, List<Menu> menuList)
        {
            return menuList.Where(x => x.ParentId == parentMenu.MenuId).OrderBy(x => x.MenuOrder).ToList();
        }

        private static void AddOnClickOnNoLink(HtmlTextWriter writer, Menu menu)
        {
            switch (menu.MenuLink)
            {
                case "#":
                    writer.AddAttribute(HtmlTextWriterAttribute.Onclick, "javascript:return false;");
                    writer.AddAttribute(HtmlTextWriterAttribute.Href, menu.MenuLink);
                    break;
                default:
                    if (menu.LinkSiteId!=-1)
                    {
                        writer.AddAttribute(HtmlTextWriterAttribute.Href, menu.MenuLink + "?d=" + BllEncryption.UrlEncode(menu.LinkSiteId.ToString(CultureInfo.InvariantCulture)));    
                    }
                    else
                    {
                        writer.AddAttribute(HtmlTextWriterAttribute.Href, menu.MenuLink);
                    }
                    break;
            }
        }

        private static void AddChild(HtmlTextWriter writer, Menu parentMenu, List<Menu> menuList, Languages language)
        {
            List<Menu> childItems = menuList.Where(x => x.IsAdded == false && x.ParentId == parentMenu.MenuId).ToList();
            if (childItems.Count == 0)
                return;
            writer.RenderBeginTag(HtmlTextWriterTag.Ul); // 1
            for (int i = 0; i < childItems.Count; i++)
            {
                if (!childItems[i].IsAdded)
                {
                    writer.RenderBeginTag(HtmlTextWriterTag.Li); // 2
                    AddOnClickOnNoLink(writer, childItems[i]);
                    writer.RenderBeginTag(HtmlTextWriterTag.A); //3
                    writer.Write(language == Languages.Hindi ? childItems[i].TextHindi : childItems[i].TextEnglish);
                    writer.RenderEndTag(); // End of tag 3
                    childItems[i].IsAdded = true;
                    AddChild(writer, childItems[i], menuList, language);
                    writer.RenderEndTag(); // End of tag 2
                }
            }
            writer.RenderEndTag(); // End of tag 1
        }

        public static String GetMenu(int siteId, ICacheStorage adapter, Languages language)
        {
            List<Menu> menuList = BllMenu.GetMenu(siteId, adapter);
            StringWriter stringWriter = new StringWriter();
            using (HtmlTextWriter writer = new HtmlTextWriter(stringWriter))
            {
                writer.RenderBeginTag(HtmlTextWriterTag.Ul); // 1
                for (int i = 0; i < menuList.Count; i++)
                {
                    if (!menuList[i].IsAdded)
                    {
                        writer.RenderBeginTag(HtmlTextWriterTag.Li); // 2
                        AddOnClickOnNoLink(writer, menuList[i]);
                        writer.RenderBeginTag(HtmlTextWriterTag.A); //3
                        writer.Write(language == Languages.Hindi ? menuList[i].TextHindi : menuList[i].TextEnglish);
                        writer.RenderEndTag(); // End of tag 3
                        menuList[i].IsAdded = true;

                        AddChild(writer, menuList[i], menuList, language);
                        writer.RenderEndTag(); // End of tag 2
                    }
                }
                writer.RenderEndTag(); //End of Ul tag 1
            }

            foreach (Menu t in menuList)
            {
                t.IsAdded = false;
            }
            return stringWriter.ToString();
        }

        public static Regions GetRegion(String region)
        {
            switch (region)
            {
                case "CC":
                    return Regions.CC;
                case "NR1":
                case "NR-I":
                case "NR 1":
                    return Regions.NR1;
                case "NR2":
                case "NR-II":
                case "NR 2":
                    return Regions.NR2;
                case "ER1":
                case "ER-I":
                case "ER 1":
                    return Regions.ER1;
                case "ER2":
                case "ER-II":
                case "ER 2":
                    return Regions.ER2;
                case "WR1":
                case "WR-I":
                case "WR 1":
                    return Regions.WR1;
                case "WR2":
                case "WR-II":
                case "WR 2":
                    return Regions.WR2;
                case "SR1":
                case "SR-I":
                case "SR 1":
                    return Regions.SR1;
                case "SR2":
                case "SR-II":
                case "SR 2":
                    return Regions.SR2;
                case "NER":
                    return Regions.NER;
                case "NLDC":
                    return Regions.POSCC;
                case "NRLDC":
                    return Regions.NRLDC;
                case "ERLDC":
                    return Regions.ERLDC;
                case "NERLDC":
                    return Regions.NERLDC;
                case "WRLDC":
                    return Regions.WRLDC;
                case "SRLDC":
                    return Regions.SRLDC;
                default:
                    return Regions.INVALID;
            }
        }

        public static MaritalStatus GetMaritalStatus(String mars)
        {
            switch (mars.ToUpper())
            {
                case "MARRIED":
                    return MaritalStatus.MARRIED;
                case "SINGLE":
                case "UNMARRIED":
                    return MaritalStatus.SINGLE;
                case "WIDOW":
                    return MaritalStatus.WIDOW;
                case "WIDOWER":
                    return MaritalStatus.WIDOWER;
                case "DIVORCEE":
                    return MaritalStatus.DIVORCEE;
                default:
                    return MaritalStatus.SINGLE;

            }
        }

        public static String GetMarquee(int siteId, ICacheStorage adapter)
        {
            List<Marquee> marqueeList = BllMenu.GetMarquee(siteId, adapter);
            if (marqueeList == null)
                return String.Empty;
            StringWriter stringWriter = new StringWriter();
            using (HtmlTextWriter writer = new HtmlTextWriter(stringWriter))
            {
                writer.AddAttribute(HtmlTextWriterAttribute.Class, "js-hidden");
                writer.AddAttribute(HtmlTextWriterAttribute.Id, "js-news");
                writer.RenderBeginTag(HtmlTextWriterTag.Ul); // 1
                foreach (Marquee t in marqueeList)
                {
                    writer.AddAttribute(HtmlTextWriterAttribute.Class, "news-item");
                    writer.RenderBeginTag(HtmlTextWriterTag.Li); // 2
                    writer.Write(t.DisplayText);
                    writer.RenderEndTag(); // End of tag 2
                }
                writer.RenderEndTag(); //End of Ul tag 1
            }
            return stringWriter.ToString();
        }

        public static String GetEmployeePermissionsByUser(Employee emp)
        {
            Dictionary<String, String> permissions = new Dictionary<string, string>();
            if (emp.EPermissions == null)
                return String.Empty;
            foreach (var e in emp.EPermissions)
            {
                if (!permissions.ContainsKey(e.Link))
                    permissions.Add(e.Link, e.PermissionName);
            }
            StringBuilder sbr = new StringBuilder();
            sbr.Append(@"<div style='border: 1px solid #000;'>");
            sbr.Append(@"<ul>");
            foreach (var p in permissions)
            {
                sbr.Append(@"<li>");
                sbr.Append(@"<a href='");
                sbr.Append(p.Key);
                sbr.Append(@"'>");
                sbr.Append(p.Value);
                sbr.Append(@"</a>");
                sbr.Append(@"</li>");
            }
            sbr.Append(@"</ul></div>");
            return sbr.ToString();
        }

        public static Roles GetRole(int permissionId)
        {
            switch (permissionId)
            {
                case 1:
                    return Roles.ADD_PHOTO_GALLERY;
                case 2:
                    return Roles.ADD_MENU;
                default:
                    return Roles.INVALID_ROLE;
            }
        }

        public static SiteType GetSiteType(int siteType)
        {
            switch (siteType)
            {
                case 1:
                    return SiteType.CORPORATE_INTRANET;
                case 2:
                    return SiteType.REGIONAL_INTRANET;
                case 3:
                    return SiteType.SUB_STATION;
                case 4:
                    return SiteType.CORPORATE_DEPARTMENT;
                case 5:
                    return SiteType.REGIONAL_DEPARTMENT;
                default:
                    return SiteType.INVALID_TYPE;
            }
        }

        public static String GetApplications(int site, Languages language, String encEmpNo, ICacheStorage adapter)
        {
            List<Applications> applications = BllApplications.GetApplicationsBySiteId(site, adapter);
            if (applications == null)
                return String.Empty;

            StringBuilder sbr = new StringBuilder();
            sbr.Append(@"<div style='border: 1px solid #000;'>");
            sbr.Append(@"<ul>");
            foreach (var a in applications)
            {
                sbr.Append(@"<li>");
                sbr.Append(@"<a href='");
                sbr.Append(a.Url);
                sbr.Append(@"?en=");
                sbr.Append(encEmpNo);
                sbr.Append(@"'>");
                sbr.Append(language == Languages.Hindi ? a.ApplicationNameHi : a.ApplicationNameEn);
                sbr.Append(@"</a>");
                sbr.Append(@"</li>");
            }
            sbr.Append(@"</ul></div>");
            return sbr.ToString();
        }

        public static String GetApplicationsButton(int site, Languages language, String encEmpNo, ICacheStorage adapter)
        {
            List<Applications> applications = BllApplications.GetApplicationsBySiteId(site, adapter);
            if (applications == null)
                return String.Empty;

            StringBuilder sbr = new StringBuilder();
            sbr.Append(@"<div style='border: 1px solid #000;'>");
            sbr.Append(@"<ul>");
            foreach (var a in applications)
            {
                sbr.Append(@"<li>");
                sbr.Append(@"<input type='button' value='");
                sbr.Append(language == Languages.Hindi ? a.ApplicationNameHi : a.ApplicationNameEn);
                sbr.Append(@"' onclick='window.location = """);
                sbr.Append(a.Url);
                sbr.Append(@"?en=");
                sbr.Append(encEmpNo);

                sbr.Append(@"""");
                sbr.Append(@"'");
                sbr.Append(@"/>");
                
                
                
                //sbr.Append(@"</a>");
                sbr.Append(@"</li>");
            }
            sbr.Append(@"</ul></div>");
            return sbr.ToString();
        }
    }
}
