using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace Com.Powergrid.Intranet.Dal
{
    public class DalPhotoGallery
    {
        private const String IntranetConString = "IntranetConString";
        private const String EmpConString = "EMPDETConString";

        public static DataSet GetGalleryListBySiteId(int siteId)
        {
            var db = DatabaseFactory.CreateDatabase(IntranetConString);
            const String sqlCmd = "IGetGalleryListBySiteId";
            var cmd = db.GetStoredProcCommand(sqlCmd);
            db.AddInParameter(cmd, "@SiteId", DbType.Int32, siteId);
            var ds = new DataSet();
            ds = db.ExecuteDataSet(cmd);
            return ds;
        }

        public static DataSet GetPhotoListByGalleryId(int galleryId)
        {
            var db = DatabaseFactory.CreateDatabase(IntranetConString);
            const String sqlCmd = "IGetPhotoListByGalleryId";
            var cmd = db.GetStoredProcCommand(sqlCmd);
            db.AddInParameter(cmd, "@GalleryId", DbType.Int32, galleryId);
            var ds = new DataSet();
            ds = db.ExecuteDataSet(cmd);
            return ds;
        }

        public static DataSet GetAllPhotoListByGalleryId(int galleryId)
        {
            var db = DatabaseFactory.CreateDatabase(IntranetConString);
            const String sqlCmd = "IGetAllPhotoListByGalleryId";
            var cmd = db.GetStoredProcCommand(sqlCmd);
            db.AddInParameter(cmd, "@GalleryId", DbType.Int32, galleryId);
            var ds = new DataSet();
            ds = db.ExecuteDataSet(cmd);
            return ds;
        }

        public static int SetPhotoGallery(int siteId, String galleryName, int status, String updatedBy, bool isDefault)
        {
            var db = DatabaseFactory.CreateDatabase(IntranetConString);
            const String sqlCmd = "ISetPhotoGallery";
            var cmd = db.GetStoredProcCommand(sqlCmd);
            db.AddInParameter(cmd, "@SiteId", DbType.Int32, siteId);
            db.AddInParameter(cmd, "@GalleryName", DbType.String, galleryName);
            db.AddInParameter(cmd, "@Status", DbType.Int32, status);
            db.AddInParameter(cmd, "@UpdatedBy", DbType.String, updatedBy);
            db.AddInParameter(cmd, "@IsDefault", DbType.Boolean, isDefault);
            var ds = new DataSet();
            ds = db.ExecuteDataSet(cmd);
            return (int)ds.Tables[0].Rows[0][0];
        }

        public static void SetGalleryPhotoListUsingTvp(DataTable dt)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings[IntranetConString].ConnectionString);
            SqlCommand cmd = new SqlCommand("ISetGalleryPhotoList", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter par = cmd.Parameters.AddWithValue("@Tvp", dt);
            par.SqlDbType = SqlDbType.Structured;
            if (con.State == ConnectionState.Closed)
                con.Open();
            cmd.ExecuteNonQuery();
            if (con.State == ConnectionState.Open)
                con.Close();
        }

        public static int GetSiteIdByGalleryId(int galleryId)
        {
            var db = DatabaseFactory.CreateDatabase(IntranetConString);
            const String sqlCmd = "IGetSiteIdByGalleryId";
            var cmd = db.GetStoredProcCommand(sqlCmd);
            db.AddInParameter(cmd, "@GalleryId", DbType.Int32, galleryId);
            var ds = new DataSet();
            ds = db.ExecuteDataSet(cmd);
            return (int)ds.Tables[0].Rows[0][0];
        }

        public static void RemovePhotoGallery(int galleryId)
        {
            var db = DatabaseFactory.CreateDatabase(IntranetConString);
            const String sqlCmd = "IRemovePhotoGallery";
            var cmd = db.GetStoredProcCommand(sqlCmd);
            db.AddInParameter(cmd, "@GalleryId", DbType.Int32, galleryId);
            db.ExecuteNonQuery(cmd);
        }

        public static void SetDefaultPhotoGallery(int siteId, int galleryId)
        {
            var db = DatabaseFactory.CreateDatabase(IntranetConString);
            const String sqlCmd = "ISetDefaultPhotoGallery";
            var cmd = db.GetStoredProcCommand(sqlCmd);
            db.AddInParameter(cmd, "@SiteId", DbType.Int32, siteId);
            db.AddInParameter(cmd, "@GalleryId", DbType.Int32, galleryId);
            db.ExecuteNonQuery(cmd);
        }

        public static void SetPhotoFromGalleryPhotoList(String empNo, int galleryId, String pictureUrl, int status)
        {
            var db = DatabaseFactory.CreateDatabase(IntranetConString);
            const String sqlCmd = "ISetPhotoFromGalleryPhotoList";
            var cmd = db.GetStoredProcCommand(sqlCmd);
            db.AddInParameter(cmd, "@EmpNo", DbType.String, empNo);
            db.AddInParameter(cmd, "@GalleryId", DbType.Int32, galleryId);
            db.AddInParameter(cmd, "@PictureUrl", DbType.String, pictureUrl);
            db.AddInParameter(cmd, "@Status", DbType.Int32, status);
            db.ExecuteNonQuery(cmd);
        }
    }
}
