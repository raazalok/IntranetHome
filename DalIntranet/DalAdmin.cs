using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.DirectoryServices;
using Com.Powergrid.Intranet.Model;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace Com.Powergrid.Intranet.Dal
{
    public class DalAdmin
    {
        private const String IntranetConString = "IntranetConString";
        private const String EmpConString = "EMPDETConString";

       

        //public static void SetGalleryPhotoList(int galleryId, String pictureUrl, String altText, String updatedBy, int status)
        //{
        //    var db = DatabaseFactory.CreateDatabase(IntranetConString);
        //    const String sqlCmd = "ISetGalleryPhotoList";
        //    var cmd = db.GetStoredProcCommand(sqlCmd);
        //    db.AddInParameter(cmd, "@GalleryId", DbType.Int32, galleryId);
        //    db.AddInParameter(cmd, "@PictureUrl", DbType.String, pictureUrl);
        //    db.AddInParameter(cmd, "@AltText", DbType.String, altText);
        //    db.AddInParameter(cmd, "@Status", DbType.Int32, status);
        //    db.AddInParameter(cmd, "@UpdatedBy", DbType.String, updatedBy);
        //    db.ExecuteNonQuery(cmd);
        //}

        

        public static DataSet GetPermissionByUser(String empNo)
        {
            var db = DatabaseFactory.CreateDatabase(IntranetConString);
            const String sqlCmd = "IGetPermissionsByUser";
            var cmd = db.GetStoredProcCommand(sqlCmd);
            db.AddInParameter(cmd, "@empNo", DbType.String, empNo);
            var ds = new DataSet();
            ds = db.ExecuteDataSet(cmd);
            return ds;   
        }

       
    }
}
