using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelManagement.DAO;
using HotelManagement.DTO;

namespace HotelManagement.BUS
{
    internal class HoaDonBUS
    {
        private static HoaDonBUS instance;
        // Lấy phiên bản của HoaDonBUS
        public static HoaDonBUS Instance
        {
            get { if (instance == null) instance = new HoaDonBUS(); return instance; }
            private set { instance = value; }
        }
        // Khởi tạo HoaDonBUS
        private HoaDonBUS() { }
        // Lấy tất cả hóa đơn
        public List<HoaDon> GetHoaDons()
        {
            return HoaDonDAO.Instance.GetHoaDons();
        }
        // Tìm hóa đơn theo mã hóa đơn
        public HoaDon FindHD(string MaHD)
        {
            return HoaDonDAO.Instance.FindHD(MaHD);
        }
        // Cập nhật hoặc chèn hóa đơn
        public void Update_Inserthd(HoaDon HD)
        {
            HoaDonDAO.Instance.Update_InsertHD(HD);
        }
        //  Tìm hóa đơn theo CCCD
        public List<HoaDon> FindHoaDonWith_CCCD(string cccd)
        {
            return HoaDonDAO.Instance.FindHoaDonWith_CCCD(cccd);
        }
        // Tìm hóa đơn theo ngày và CCCD
        public List<HoaDon> FindHoaDonWith_DateAndCCCD(DateTime dateTime, string cccd)
        {
            return HoaDonDAO.Instance.FindHoaDonWith_DateAndCCCD(dateTime, cccd);
        }
        // Lấy mã hóa đơn tiếp theo
        public string getMaHDNext()
        {
            return HoaDonDAO.Instance.getMaHDNext();
        }
        // Thanh toán hóa đơn
        public void ThanhToanHD(HoaDon HD)
        {
            HoaDonDAO.Instance.ThanhToanHD(HD);
        }
        // Xóa hóa đơn
        public void RemoveHD(HoaDon hd)
        {
            HoaDonDAO.Instance.RemoveHD(hd);
        }
        // Tìm hóa đơn theo ngày
        public List<HoaDon> FindHoaDonWith_Date(DateTime dateTime)
        {
            return HoaDonDAO.Instance.FindHoaDonWith_Date(dateTime);
        }
    }
}
