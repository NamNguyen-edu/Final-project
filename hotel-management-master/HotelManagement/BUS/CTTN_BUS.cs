using HotelManagement.DAO;
using HotelManagement.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.BUS
{
    internal class CTTN_BUS
    {
        // Tạo phiên lấy dữ liệu
        private static CTTN_BUS instance;
        // Lấy phiên bản của CTTN_BUS
        public static CTTN_BUS Instance
        {
            get { if (instance == null) instance = new CTTN_BUS(); return instance; }
            private set { instance = value; }
        }
        // Khởi tạo CTTN_BUS
        private CTTN_BUS() { }
        // Lấy tất cả CTTN
        public List<CTTN> GetCTTNs()
        {
            return CTTN_DAO.Instance.GetCTTNs();
        }
        // Cập nhật hoặc chèn CTTN
        public void UpdateOrInsert(CTTN cTTN)
        {
            CTTN_DAO.Instance.UpdateOrInsert(cTTN);
        }
        // Xóa CTTN
        public void RemoveCTTN(CTTN cTTN)
        {
            CTTN_DAO.Instance.RemoveCTTN(cTTN);
        }
        // Tìm chi tiết thanh toán theo mã loại phiếu thuê
        public List<CTTN> FindCTTN(string MaLPH)
        {
            return CTTN_DAO.Instance.FindCTTN(MaLPH);
        }
    }
}
