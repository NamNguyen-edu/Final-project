using HotelManagement.DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.DAO
{
    internal class LoaiPhongDAO
    {
        HotelDTO db = new HotelDTO();
        private static LoaiPhongDAO instance;
        public static LoaiPhongDAO Instance
        {
            get { if (instance == null) instance = new LoaiPhongDAO(); return instance; }
            private set { instance = value; }
        }
        private LoaiPhongDAO() { }
        public List<LoaiPhong> GetLoaiPhongs()
        {

                return db.LoaiPhongs.ToList();
            
        }    
        public LoaiPhong getLoaiPhong(string MaLP)
        {

                return db.LoaiPhongs.Find(MaLP);
 
        }
        public void AddOrUpdate(LoaiPhong loaiPhong)
        {

                db.LoaiPhongs.AddOrUpdate(loaiPhong);
                db.SaveChanges();
            
        }
        public void RemoveLoaiPhong(LoaiPhong loaiPhong)
        {

                db.LoaiPhongs.Remove(loaiPhong);
                db.SaveChanges();

        }
        public List<LoaiPhong> getLoaiPhongWithName(string TenLP)
        {

            return db.LoaiPhongs.Where(p => p.TenLPH.Contains(TenLP)).ToList();

        }
        public bool IsValidGia(decimal giaNgay, decimal giaGio, out string error)
        {
            error = "";

            if (giaNgay < 50000 || giaGio < 50000)
            {
                error = "Giá ngày và giá giờ phải lớn hơn hoặc bằng 50.000.";
                return false;
            }

            if (giaNgay <= giaGio)
            {
                error = "Giá ngày phải lớn hơn giá giờ.";
                return false;
            }

            return true;
        }
    }
}
