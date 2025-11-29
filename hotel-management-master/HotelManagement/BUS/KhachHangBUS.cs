using HotelManagement.DAO;
using HotelManagement.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.BUS
{
    // Lớp BUS (tầng nghiệp vụ) quản lý các thao tác liên quan đến Khách hàng
    internal class KhachHangBUS
    {
        // Biến singleton cho lớp KhachHangBUS
        private static KhachHangBUS instance;

        // Thuộc tính singleton, đảm bảo chỉ có một đối tượng KhachHangBUS duy nhất
        public static KhachHangBUS Instance
        {
            get { if (instance == null) instance = new KhachHangBUS(); return instance; }
            private set { instance = value; }
        }

        // Hàm khởi tạo private, chỉ được gọi nội bộ thông qua Instance
        private KhachHangBUS() { }

        // Lấy danh sách khách hàng (chưa bị xóa) thông qua tầng DAO
        public List<KhachHang> GetKhachHangs()
        {
            return KhachHangDAO.Instance.GetKhachHangs();
        }

        // Tìm khách hàng theo mã khách hàng (MaKH)
        public KhachHang FindKhachHang(string MaKH)
        {
            return KhachHangDAO.Instance.FindKhachHang(MaKH);
        }

        // Thêm mới hoặc cập nhật thông tin khách hàng
        public void UpdateOrAdd(KhachHang khachHang)
        {
            KhachHangDAO.Instance.UpdateOrAdd(khachHang);
        }

        // Xóa mềm một khách hàng (gán DaXoa = true)
        public void RemoveKH(KhachHang khachHang)
        {
            KhachHangDAO.Instance.RemoveKH(khachHang);
        }

        // Tìm danh sách khách hàng theo tên (TenKH)
        public List<KhachHang> FindKhachHangWithName(string TenKH)
        {
            return KhachHangDAO.Instance.FindKhachHangWithName(TenKH);
        }

        // Lấy mã khách hàng kế tiếp theo định dạng KHxxx
        public string GetMaKHNext()
        {
            return KhachHangDAO.Instance.GetMaKHNext();
        }

        // Tìm khách hàng theo số CCCD/Passport
        public KhachHang FindKHWithCCCD(string cccd)
        {
            return KhachHangDAO.Instance.FindKHWithCCCD(cccd);
        }

        // Tìm khách hàng theo Email
        public KhachHang FindKHWithEmail(string email)
        {
            return KhachHangDAO.Instance.FindKHWithEmail(email);
        }
    }
}
