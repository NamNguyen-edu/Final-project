using HotelManagement.DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelManagement.DAO
{
    internal class HoaDonDAO
    {
        private static HoaDonDAO instance;
        public static HoaDonDAO Instance
        {
            get { if (instance == null) instance = new HoaDonDAO(); return instance; }
            private set { instance = value; }
        }
        private HoaDonDAO() { }
        // Lấy tất cả hóa đơn
        public List<HoaDon> GetHoaDons()
        {
            HotelDTO db = new HotelDTO();
            return db.HoaDons.ToList();           
        } 
        // Tìm hóa đơn theo mã 
        public HoaDon FindHD(string MaHD)
        {
            HotelDTO db = new HotelDTO();
            return db.HoaDons.Find(MaHD);         
        }
        // Thêm hoặc cập nhật hóa đơn
        public void Update_InsertHD(HoaDon HD)
        {
            HotelDTO db = new HotelDTO();

            HD.CTDP = db.CTDPs.Find(HD.MaCTDP);
                HD.NhanVien = db.NhanViens.Find(HD.MaNV);
                
                db.HoaDons.AddOrUpdate(HD);
                db.SaveChanges();               
        }
        // Xử lý để tạo hóa đơn đã được thanh toán
        public void ThanhToanHD(HoaDon HD)
        {
            HotelDTO db = new HotelDTO();
            HD.CTDP = db.CTDPs.Find(HD.MaCTDP);
            HD.NhanVien = db.NhanViens.Find(HD.MaNV);
            db.HoaDons.AddOrUpdate(HD);
            db.SaveChanges();
            db.Dispose();
        }    
        // Tìm hóa đơn với CCCD
        public List<HoaDon> FindHoaDonWith_CCCD(string cccd)
        {
            HotelDTO db = new HotelDTO();

            return db.HoaDons.Where(p => p.CTDP.PhieuThue.KhachHang.CCCD_Passport.StartsWith(cccd)).ToList();
        }
        // Tìm hóa đơn theo ngày
        public List<HoaDon> FindHoaDonWith_Date(DateTime dateTime)
        {
            HotelDTO db = new HotelDTO();

            return db.HoaDons.Where(p => p.NgHD.Value.Month == dateTime.Month && p.NgHD.Value.Year == dateTime.Year && p.NgHD.Value.Day == dateTime.Day).ToList();
        }
        // Tìm hóa đơn theo ngày và CCCD
        public List<HoaDon> FindHoaDonWith_DateAndCCCD(DateTime dateTime, string cccd)
        {
            HotelDTO db = new HotelDTO();

            return db.HoaDons.Where(p => p.NgHD.Value.Month == dateTime.Month && p.NgHD.Value.Year == dateTime.Year && p.NgHD.Value.Day == dateTime.Day
                                    && p.CTDP.PhieuThue.KhachHang.CCCD_Passport.StartsWith(cccd)).ToList();
        }
        // Tự động lấy mã hóa đơn tiếp theo
        public string getMaHDNext()
        {
            HotelDTO db = new HotelDTO();
            List<HoaDon> HD = db.HoaDons.ToList();
                string MaMax = HD[HD.Count - 1].MaHD.ToString();
                MaMax = MaMax.Substring(MaMax.Length - 3, 3);
                int max = int.Parse(MaMax);
                max++;
                if (max < 10)
                {
                    return "HD00" + max.ToString();
                }
                else if (max < 100)
                {
                    return "HD0" + max.ToString();
                }
                return "HD" + max.ToString();          
        }
        // Xóa hóa đơn
        public void RemoveHD(HoaDon hoaDon)
        {
            HotelDTO db = new HotelDTO();

            db.HoaDons.Remove(hoaDon);
            db.SaveChanges();
        }
    }
}
