using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Com.Powergrid.Intranet.Dal;
using Com.Powergrid.Intranet.Model;
using Com.Powergrid.Intranet.Utility;


namespace Com.Powergrid.Intranet.Bll
{
    public class BllMenu
    {
        public List<Menu> GetMenu(int regionId)
        {
            return BindModel.GetMenu(DalMenu.GetActiveMenuByUser(regionId));
        }

        public static List<Menu> GetMenu(int siteId, ICacheStorage adapter)
        {
            String storageKey = String.Format("Menu_Site_{0}", siteId);
            List<Menu> menuToDisplay = adapter.Retrieve<List<Menu>>(storageKey);

            if (menuToDisplay == null)
            {
                List<Menu> menuList = BindModel.GetMenu(DalMenu.GetActiveMenuByUser(siteId));
                if(menuList!=null)
                {
                    adapter.Store(storageKey, menuList);    
                }
                return menuList;
            }
            return menuToDisplay;
        }


        public static List<Marquee> GetMarquee(int siteId, ICacheStorage adapter)
        {
            String storageKey = String.Format("Marquee_Site_{0}", siteId);
            List<Marquee> marqueeToDisplay = adapter.Retrieve<List<Marquee>>(storageKey);

            if (marqueeToDisplay == null)
            {
                List<Marquee> marqueeList = BindModel.GetMarquee(DalMenu.GetActiveMarqueeBySite(siteId));
                if (marqueeList != null)
                {
                    adapter.Store(storageKey, marqueeList);
                }
                return marqueeList;
            }
            return marqueeToDisplay;
        }

        public static List<Sites> GetActiveSites(ICacheStorage adapter)
        {
            String storageKey = String.Format("All_Sites");
            List<Sites> sites = adapter.Retrieve<List<Sites>>(storageKey);

            if (sites == null)
            {
                 sites= BindModel.GetAllSites(DalMenu.GetActiveSites());
                if (sites != null)
                {
                    adapter.Store(storageKey, sites);
                }
                //else
                //{
                //    adapter.Store(storageKey, String.Empty);
                //}
                return sites;
            }
            return sites;
        }
    }
}
