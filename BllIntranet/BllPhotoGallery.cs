using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Com.Powergrid.Intranet.Dal;
using Com.Powergrid.Intranet.Model;
using Com.Powergrid.Intranet.Utility;

namespace Com.Powergrid.Intranet.Bll
{
    public class BllPhotoGallery
    {
        public static List<Gallery> GetGalleryListBySiteId(int siteId, ICacheStorage adapter)
        {
            String storageKey = String.Format("Gallery_{0}", siteId);
            List<Gallery> galleryList = adapter.Retrieve<List<Gallery>>(storageKey);

            if (galleryList == null)
            {
                var ds = DalPhotoGallery.GetGalleryListBySiteId(siteId);

                galleryList = BindModel.GetGalleryWithoutPhoto(ds.Tables[0]);
                if (galleryList != null && galleryList.Count != 0)
                    adapter.Store(storageKey, galleryList);
                return galleryList;
            }
            return galleryList;
        }

        public static List<Photos> GetPhotoListByGalleryId(int galleryId, ICacheStorage adapter)
        {
            String storageKey = String.Format("Gallery_Photo_{0}", galleryId);
            List<Photos> photosList = adapter.Retrieve<List<Photos>>(storageKey);

            if (photosList == null)
            {
                var ds = DalPhotoGallery.GetPhotoListByGalleryId(galleryId);
                photosList = BindModel.GetPhotosForGallery(ds.Tables[0]);
                if (photosList != null && photosList.Count != 0)
                    adapter.Store(storageKey, photosList);
                return photosList;
            }
            return photosList;
        }

        public static List<Photos> GetAllPhotoListByGalleryId(int galleryId, ICacheStorage adapter)
        {
            String storageKey = String.Format("Gallery_All_Photo_{0}", galleryId);
            List<Photos> photosList = adapter.Retrieve<List<Photos>>(storageKey);

            if (photosList == null)
            {
                var ds = DalPhotoGallery.GetAllPhotoListByGalleryId(galleryId);
                photosList = BindModel.GetPhotosForGallery(ds.Tables[0]);
                if (photosList != null && photosList.Count != 0)
                    adapter.Store(storageKey, photosList);
                return photosList;
            }
            return photosList;
        }

        public static int SetPhotoGallery(Gallery g)
        {
            return DalPhotoGallery.SetPhotoGallery(g.SiteId, g.GalleryName, g.Status, g.UpdatedBy,g.IsDefault);
        }

        public static void SetGalleryPhotoList(List<Photos> photos)
        {
            DataSet ds = new DataSet();
            ds.Tables.Add("Photos");
            ds.Tables[0].Columns.Add("GalleryId");
            ds.Tables[0].Columns.Add("PictureUrl");
            ds.Tables[0].Columns.Add("AltText");
            ds.Tables[0].Columns.Add("UpdatedBy");
            ds.Tables[0].Columns.Add("Status");

            foreach (var p in photos)
            {
                var r = ds.Tables[0].NewRow();
                r["GalleryId"] = p.GalleryId;
                r["PictureUrl"] = p.PictureUrl;
                r["AltText"] = p.AltText;
                r["UpdatedBy"] = p.UpdatedBy;
                r["Status"] = p.Status;
                ds.Tables[0].Rows.Add(r);
            }
            DalPhotoGallery.SetGalleryPhotoListUsingTvp(ds.Tables[0]);
        }

        public static int GetSiteIdByGalleryId(int galleryId)
        {
            return DalPhotoGallery.GetSiteIdByGalleryId(galleryId);
        }

        public static void RemovePhotoGallery(int galleryId)
        {
            DalPhotoGallery.RemovePhotoGallery(galleryId);
        }

        public static void SetDefaultPhotoGallery(int siteId, int galleryId)
        {
            DalPhotoGallery.SetDefaultPhotoGallery(siteId,galleryId);
        }

        public static void SetPhotoFromGalleryPhotoList(String empNo, int galleryId, String pictureUrl, int status)
        {
            DalPhotoGallery.SetPhotoFromGalleryPhotoList(empNo, galleryId, pictureUrl, status);
        }
    }
}
