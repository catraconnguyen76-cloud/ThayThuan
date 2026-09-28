using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using QUANLYBANHANG_ONLINE;

namespace QUANLYBANHANG_ONLINE.ADMIN.PROCESSDATA
{
    public class QUANLYSANPHAM_PROCESSDATA
    {
        private dbQUANLYBANHANGEntities db ;
        
        public QUANLYSANPHAM_PROCESSDATA()
        {
            db = new dbQUANLYBANHANGEntities();
        }
        
        public List<tbDANHMUC> getTableDanhmuc()
        {
            try
            {
                return db.tbDANHMUCs.ToList<tbDANHMUC>();
            }
            catch (Exception ex)
            {
            }
            return null;
        }

        public List<tbSANPHAM> getTableSanPham()
        {
            try
            {
                var tbsanpham = from tbSANPHAM in db.tbSANPHAMs
                                select tbSANPHAM;
                return tbsanpham.ToList();
            }
            catch (Exception ex)
            {
            }
            return null;
        }

        public int InsertRecord(Dictionary<String, Object> list)
        {
            int k = 0;
            try
            {
                k = db.Database.ExecuteSqlCommand("EXEC psInsertRecordSANPHAM @TENSANPHAM, @MADANHMUC, @DONGIA, @SOLUONG, @HINHANH, @MOTA",
                    new SqlParameter("@TENSANPHAM", (String)list["@TENSANPHAM"]),
                    new SqlParameter("@MADANHMUC", Convert.ToInt32(list["@MADANHMUC"])),
                    new SqlParameter("@DONGIA", Convert.ToDecimal(list["@DONGIA"])),
                    new SqlParameter("@SOLUONG", Convert.ToInt32(list["@SOLUONG"])),
                    new SqlParameter("@HINHANH", (String)list["@HINHANH"]),
                    new SqlParameter("@MOTA", (String)list["@MOTA"]));
            }
            catch(Exception ex)
            {
            } 
            return k;
        }

        public int UpdateRecord(Dictionary<String, Object> list)
        {
            int k = 0;
            try
            {
                k = db.Database.ExecuteSqlCommand("EXEC psUpdateRecordSANPHAM @MASANPHAM, @TENSANPHAM, @MADANHMUC, @DONGIA, @SOLUONG, @HINHANH, @MOTA",
                    new SqlParameter("@MASANPHAM", Convert.ToInt32(list["@MASANPHAM"])),
                    new SqlParameter("@TENSANPHAM", (String)list["@TENSANPHAM"]),
                    new SqlParameter("@MADANHMUC", Convert.ToInt32(list["@MADANHMUC"])),
                    new SqlParameter("@DONGIA", Convert.ToDecimal(list["@DONGIA"])),
                    new SqlParameter("@SOLUONG", Convert.ToInt32(list["@SOLUONG"])),
                    new SqlParameter("@HINHANH", (String)list["@HINHANH"]),
                    new SqlParameter("@MOTA", (String)list["@MOTA"]));
            }
            catch (Exception ex)
            {
            }
            return k;
        }

        public int DeleteRecord(Dictionary<String, Object> list)
        {
            int k = 0;
            try
            {
                int id = Convert.ToInt32(list["@MASANPHAM"]);
                k = db.Database.ExecuteSqlCommand("EXEC psDeleteRecordSANPHAM @MASANPHAM", 
                    new SqlParameter("@MASANPHAM", id));
            }
            catch (Exception ex)
            {
            }
            return k;
        }
    }
}
