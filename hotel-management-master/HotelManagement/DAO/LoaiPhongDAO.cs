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
        // Lấy tất cả loại phòng
        public List<LoaiPhong> GetLoaiPhongs()
        {
                return db.LoaiPhongs.ToList();
        }    
        // Lấy loại phòng theo mã
        public LoaiPhong getLoaiPhong(string MaLP)
        {
                return db.LoaiPhongs.Find(MaLP);
        }
        // Thêm hoặc cập nhật loại phòng
        public void AddOrUpdate(LoaiPhong loaiPhong)
        {
                db.LoaiPhongs.AddOrUpdate(loaiPhong);
                db.SaveChanges();       
        }
        // Xóa loại phòng 
        public void RemoveLoaiPhong(LoaiPhong loaiPhong)
        {
                db.LoaiPhongs.Remove(loaiPhong);
                db.SaveChanges();
        }
        // Lấy loại phòng theo tên
        public List<LoaiPhong> getLoaiPhongWithName(string TenLP)
        {
            return db.LoaiPhongs.Where(p => p.TenLPH.Contains(TenLP)).ToList();
        }
        // Kiểm tra giá phòng được chỉnh sửa
        public bool IsValidGia(decimal giaNgay, decimal giaGio, out string error)
        {
            error = "";
            if (giaNgay < 50000 || giaGio < 50000) //Giá thuê theo ngày và giá thuê theo giờ phải lớn hơn 50.000
            {
                error = "Giá ngày và giá giờ phải lớn hơn hoặc bằng 50.000.";
                return false;
            }
            if (giaNgay <= giaGio) // Nếu giá thuê theo ngày bé hơn giá thuê theo giờ 
            {
                error = "Giá ngày phải lớn hơn giá giờ.";
                return false; // Trả về giá trị sai
            }
            return true; // Trả về giá trị đúng
        }
    }
}
