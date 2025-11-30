using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelManagement.DAO;
using HotelManagement.DTO;

namespace HotelManagement.BUS
{
    internal class PhieuThueBUS
    {
        // Tạo phiên lấy dữ liệu
        private static PhieuThueBUS instance;

        public static PhieuThueBUS Instance
        {
            get { if (instance == null) instance = new PhieuThueBUS(); return instance; }
            private set { instance = value; }
        }
        private PhieuThueBUS() { }
        // Lấy tất cả phiếu thuê
        public List<PhieuThue> GetPhieuThues()
        {
            return PhieuThueDAO.Instance.GetPhieuThues();
        }
        // Lấy từng phiếu thuê theo mã
        public PhieuThue GetPhieuThue(string MaPT)
        {
            return PhieuThueDAO.Instance.GetPhieuThue(MaPT);
        }
        // Thêm hoặc cập nhật phiếu thuê
        public void AddOrUpdatePhieuThue(PhieuThue phieuThue)
        {
            PhieuThueDAO.Instance.UpdatePhieuThue(phieuThue);
        }
        // Lấy tất cả phiếu thuê kèm theo tên khách hàng
        public List<PhieuThue> GetPhieuThuesWithNameCus(string name)
        {
            return PhieuThueDAO.Instance.GetPhieuThuesWithNameCus(name);
        }
        // Lấy mã phiếu thuê tiếp theo
        public string GetMaPTNext()
        {
            return PhieuThueDAO.Instance.GetMaPTNext();
        }
    }
}
