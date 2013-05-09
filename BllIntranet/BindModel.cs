using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Com.Powergrid.Intranet.Model;

namespace Com.Powergrid.Intranet.Bll
{
    public class BindModel
    {
        public static List<Menu> GetMenu(DataTable dt)
        {
            if (dt.Rows.Count == 0)
                return null;
            List<Menu> menuList = new List<Menu>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Menu m = new Menu();
                m.MenuId = (int)dt.Rows[i]["ID"];
                m.TextEnglish = (string)dt.Rows[i]["TextEnglish"];
                m.TextHindi = (string)dt.Rows[i]["TextHindi"];
                m.ParentId = (int)dt.Rows[i]["ParentId"];
                m.Status = true;
                m.UpdatedBy = (string)dt.Rows[i]["UpdatedBy"];
                m.UpdatedOn = (DateTime)dt.Rows[i]["UpdatedOn"];
                m.MenuOrder = (int)dt.Rows[i]["MenuOrder"];
                m.MenuLink = (string)dt.Rows[i]["Link"];
                //m.PageType= (int)dt.Rows[i]["PageType"];
                m.MenuLevel = (int)dt.Rows[i]["MenuLevel"];
                m.IsAdded = false;
                m.RegionId = (int)dt.Rows[i]["SiteId"];
                m.IsVisibleToOther = (bool)dt.Rows[i]["IsVisibleToOther"];
                m.LinkSiteId = (int)dt.Rows[i]["LinkSiteId"];
                menuList.Add(m);
            }
            return menuList;
        }

        public static Employee GetEmployee(DataTable dt)
        {
            if (dt.Rows.Count == 0)
                return null;
            Employee e = new Employee();
            e.EmpNo = (String)dt.Rows[0]["EmpNo"];
            e.EmpNameEn = (String)dt.Rows[0]["EmpName"];
            e.EmpNameHi = (String)dt.Rows[0]["EmpNameHi"] ?? String.Empty;
            e.Designation = (String)dt.Rows[0]["Designation"] ?? String.Empty;
            e.Grade = (String)dt.Rows[0]["Grade"] ?? String.Empty;
            e.Region = (String)dt.Rows[0]["Region"] ?? String.Empty;
            e.Location = (String)dt.Rows[0]["Location"] ?? String.Empty;
            e.IRegion = BllUtility.GetRegion(e.Region);
            e.Department = (String)dt.Rows[0]["Department"] ?? String.Empty;
            e.IsActive = (bool)dt.Rows[0]["Active"];
            e.Dob = (DateTime?)dt.Rows[0]["DOB"] ?? DateTime.MinValue;
            e.Gender = ((String)dt.Rows[0]["SEX"]).StartsWith("F") ? Gender.FEMALE : Gender.MALE;
            e.MaritalStatus = BllUtility.GetMaritalStatus((String)dt.Rows[0]["MARS"]);
            e.Religion = (String)dt.Rows[0]["RELIGION"];
            e.EmpState = (String)dt.Rows[0]["EMPSTATE"];
            e.BloodGroup = (String)dt.Rows[0]["BLOODGROUP"];
            e.Discipline = (String)dt.Rows[0]["DISCIPLINE"];
            e.PgEmail = (String)dt.Rows[0]["PGEMAIL"];
            e.ExtEmail = (String)dt.Rows[0]["EXTEMAIL"];
            e.CellNo = (String)dt.Rows[0]["CELLNO"];
            //e.OfficePhoneNo=(String)dt.Rows[0]["OFFICEPHONENO"]??String.Empty;
            e.OfficeRaxNo = (String)dt.Rows[0]["OFFICERAXNO"] ?? String.Empty;
            e.ResidenceAddress = (String)dt.Rows[0]["RESIDENCEADDRESS"] ?? String.Empty;
            e.Language = (int)dt.Rows[0]["DefaultLanguage"] == 1 ? Languages.English : Languages.Hindi;
            e.PasswordChangedAt = (DateTime?)dt.Rows[0]["PassChangedAt"] ?? DateTime.MinValue;
            e.ReportingOfficer = (String)dt.Rows[0]["REPORTINGOFFR"];
            e.ReviewingOfficer = (String)dt.Rows[0]["REVIEWINGOFFR"];
            e.ResidenceCity = (String)dt.Rows[0]["RESIDENCECITY"];
            e.OrganizationalUnit = (String)dt.Rows[0]["OU"];
            e.DOJ = (DateTime?)dt.Rows[0]["DOJ"] ?? DateTime.MinValue;
            e.OfficeSeat = (String)dt.Rows[0]["OFFICESEAT"];
            e.HomeTown = (String)dt.Rows[0]["HOMETOWN"];
            return e;
        }

        public static List<Marquee> GetMarquee(DataTable dt)
        {
            if (dt.Rows.Count == 0)
                return null;
            List<Marquee> marqueeList = new List<Marquee>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Marquee m = new Marquee();
                m.Id = (int)dt.Rows[i]["ID"];
                m.DisplayText = (string)dt.Rows[i]["DisplayText"];
                m.HasAttachment = (bool)dt.Rows[i]["HasAttachment"];
                m.ImageType = (int)dt.Rows[i]["ImageType"] == 1 ? ImageType.NEW : ImageType.UPDATE;
                m.Status = (int)dt.Rows[i]["ImageType"] == 1;
                m.StartDate = (DateTime)dt.Rows[i]["StartDate"];
                m.EndDate = (DateTime)dt.Rows[i]["EndDate"];
                m.AttachmentLink = (string)dt.Rows[i]["AttachmentLink"];
                //m.UpdatedBy = (string)dt.Rows[i]["UpdatedBy"];
                marqueeList.Add(m);
            }
            return marqueeList;
        }

        public static List<Gallery> GetGalleryWithoutPhoto(DataTable dt)
        {
            if (dt.Rows.Count == 0)
                return null;
            List<Gallery> galleryList = new List<Gallery>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Gallery g = new Gallery();
                g.SiteId = Convert.ToInt32(dt.Rows[i]["SiteID"]);
                g.GalleryId = Convert.ToInt32(dt.Rows[i]["GalleryId"]);
                g.GalleryName = dt.Rows[i]["GalleryName"].ToString();
                g.Status = Convert.ToInt32(dt.Rows[i]["Status"]);
                g.UpdatedBy = dt.Rows[i]["UpdatedBy"].ToString();
                g.UpdatedOn = Convert.ToDateTime(dt.Rows[i]["UpdatedOn"]);
                g.IsDefault = Convert.ToBoolean(dt.Rows[i]["IsDefault"]);
                galleryList.Add(g);
            }
            return galleryList;
        }

        public static List<Photos> GetPhotosForGallery(DataTable dt)
        {
            if (dt.Rows.Count == 0)
                return null;
            List<Photos> photoList= new List<Photos>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Photos p = new Photos();
                p.GalleryId = (int) dt.Rows[i]["GalleryId"];
                p.PictureUrl = (string)dt.Rows[i]["PictureUrl"];
                p.AltText = (String)dt.Rows[i]["AltText"];
                p.UpdatedBy = (String)dt.Rows[i]["UpdatedBy"];
                p.UpdatedOn = (DateTime)dt.Rows[i]["UpdatedOn"];
                p.Status = (int)dt.Rows[i]["Status"];
                photoList.Add(p);
            }
            return photoList;
        }

        public static List<Permissions> GetPermissions(DataTable dt)
        {
            if (dt.Rows.Count == 0)
                return null;
            List<Permissions> pList = new List<Permissions>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Permissions p = new Permissions();
                p.PermissionId = (int)dt.Rows[i]["PermissionId"];
                p.PermissionName = (string)dt.Rows[i]["PermissionName"];
                p.PermissionLink = (string)dt.Rows[i]["Link"];
                p.PermissionTo = (string)dt.Rows[i]["EmpNo"];
                pList.Add(p);
            }
            return pList;
        }

        public static List<EmployeePermissions> GetEmployeePermissionsByUser(DataTable dt)
        {
            if (dt.Rows.Count == 0)
                return null;
            List<EmployeePermissions> epList = new List<EmployeePermissions>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                EmployeePermissions ep = new EmployeePermissions();
                ep.PermissionId = (int)dt.Rows[i]["PermissionId"];
                ep.PermissionName = (String)dt.Rows[i]["PermissionName"];
                ep.Link = (String)dt.Rows[i]["Link"];
                ep.SiteId = (int)dt.Rows[i]["SiteId"];
                ep.ParentId = (int)dt.Rows[i]["ParentId"];
                ep.SiteName = (String)dt.Rows[i]["SiteName"]?? String.Empty;
                ep.SiteNameEn = (String)dt.Rows[i]["SiteNameEn"];
                ep.SiteNameHi = (String)dt.Rows[i]["SiteNameHi"];
                ep.Status = (int)dt.Rows[i]["Status"];
                int type = (int)dt.Rows[i]["SiteType"];
                ep.SiteType = BllUtility.GetSiteType(type);
                epList.Add(ep);
            }
            return epList;
        }

        public static List<Sites> GetAllSites(DataTable dt)
        {
            if (dt.Rows.Count == 0)
                return null;
            List<Sites> sites = new List<Sites>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Sites s = new Sites();
                s.SiteId= (int)dt.Rows[i]["SiteID"];
                s.SiteName= (string)dt.Rows[i]["SiteName"];
                s.SiteNameEn = (string)dt.Rows[i]["SiteNameEn"];
                s.SIteNameHi = (string)dt.Rows[i]["SiteNameHi"];
                s.ParentId = (int)dt.Rows[i]["ParentID"];
                s.Status = Convert.ToInt32(dt.Rows[i]["Status"]);
                s.UpdatedBy = (string)dt.Rows[i]["UpdatedBy"];
                s.UpdatedOn = (DateTime)dt.Rows[i]["UpdatedOn"];
                s.SuperParentId=(int)dt.Rows[i]["SuperParentId"];
                s.SiteType = BllUtility.GetSiteType((int) dt.Rows[i]["SiteType"]);
                sites.Add(s);
            }
            return sites;
        }

        public static List<Applications> GetApplications(DataTable dt)
        {
            if (dt.Rows.Count == 0)
                return null;
            List<Applications> applicationsList = new List<Applications>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Applications a = new Applications();
                a.ApplicationId = Convert.ToInt32(dt.Rows[i]["ApplicationId"]);
                a.ApplicationNameEn = dt.Rows[i]["ApplicationNameEn"].ToString();
                a.ApplicationNameHi = dt.Rows[i]["ApplicationNameHi"].ToString();
                a.SiteId = Convert.ToInt32(dt.Rows[i]["SiteID"]);
                a.Url = dt.Rows[i]["Url"].ToString();
                a.SortOrder = Convert.ToInt32(dt.Rows[i]["SortOrder"]);
                a.UpdatedBy = dt.Rows[i]["UpdatedBy"].ToString();
                a.UpdatedOn = Convert.ToDateTime(dt.Rows[i]["UpdatedOn"]);
                a.Status = Convert.ToInt32(dt.Rows[i]["Status"]);
                applicationsList.Add(a);
            }
            return applicationsList;
        }
    }
}
