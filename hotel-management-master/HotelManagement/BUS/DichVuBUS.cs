using HotelManagement.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelManagement.DAO;

namespace HotelManagement.BUS
{
    internal class DichVuBUS
    {
        private static DichVuBUS instance;
        // Lấy phiên bản của DichVuBUS
        public static DichVuBUS Instance
        {
            get { if (instance == null) instance = new DichVuBUS(); return instance; }
            private set { instance = value; }
        }
        // Khởi tạo DichVuBUS
        private DichVuBUS() { }
        // Lấy tất cả dịch vụ
        public List<DichVu> GetDichVus()
        {
            return DichVuDAO.Instance.GetDichVus();
        }
        // Tìm dịch vụ theo mã dịch vụ
        public DichVu FindDichVu(string MaDV)
        {
            return DichVuDAO.Instance.FindDichVu(MaDV);     
        }
        // Cập nhật hoặc thêm dịch vụ
        public void UpdateORAdd(DichVu dv)
        {
            DichVuDAO.Instance.UpdateORAdd(dv);
        }
        // Xóa dịch vụ
        public void RemoveDV(DichVu dv)
        { 
            DichVuDAO.Instance.RemoveDV(dv);
        }
        // Lấy mã dịch vụ tiếp theo
        public string GetMaDVNext()
        {
           return DichVuDAO.Instance.GetMaDVNext();
        }
        // Tìm dịch vụ theo tên dịch vụ
        public List<DichVu> FindDichVuWithName(string TenDV)
        {
            return DichVuDAO.Instance.FindDichVuWithName(TenDV);
        }
        // Lấy danh sách dịch vụ còn lại (không bị xóa)
        public List<DichVu> GetDichVusConLai()
        {
            return DichVuDAO.Instance.GetDichVusConLai();
        }
        // Tìm dịch vụ theo tên dịch vụ và đơn giá
        public DichVu FindDichVuWithNameAndDonGia(string TenDV, string DonGia)
        {
            return DichVuDAO.Instance.FindDichVuWithNameAndDonGia(TenDV, DonGia);
        }
        // Cập nhật danh sách dịch vụ
        public void UpdateDV(List<DichVu> dichVus)
        {
            DichVuDAO.Instance.UpdateDV(dichVus);
        }    
    }
}
