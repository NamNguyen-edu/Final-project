using HotelManagement.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelManagement.DAO;

namespace HotelManagement.BUS
{
    internal class LoaiPhongBUS
    {
        private static LoaiPhongBUS instance;
        public static LoaiPhongBUS Instance
        {
            get { if (instance == null) instance = new LoaiPhongBUS(); return instance; }
            private set { instance = value; }
        }
        private LoaiPhongBUS() { }
        // Lấy tất cả loại phòng
        public List<LoaiPhong> GetLoaiPhongs()
        {
            return LoaiPhongDAO.Instance.GetLoaiPhongs();
        }
        // Lấy loại phòng theo mã
        public LoaiPhong getLoaiPhong(string MaLP)
        {
            return LoaiPhongDAO.Instance.getLoaiPhong(MaLP);
        }
        // Thêm hoặc cập nhật loại phòng 
        public void AddOrUpdate(LoaiPhong loaiPhong)
        {
            LoaiPhongDAO.Instance.AddOrUpdate(loaiPhong);
        }
        // Xóa loại phòng 
        public void RemoveLoaiPhong(LoaiPhong loaiPhong)
        {
            LoaiPhongDAO.Instance.RemoveLoaiPhong(loaiPhong);
        }
        // Lấy các loại phòng 
        public List<LoaiPhong> getLoaiPhongWithName(string TenLP)
        {
            return LoaiPhongDAO.Instance.getLoaiPhongWithName(TenLP);
        }
        // Gọi hàm kiểm tra giá từ DAO
        public bool IsValidGia(decimal giaNgay, decimal giaGio, out string error)
        {
            return LoaiPhongDAO.Instance.IsValidGia(giaNgay, giaGio, out error);
        }
    }
}
