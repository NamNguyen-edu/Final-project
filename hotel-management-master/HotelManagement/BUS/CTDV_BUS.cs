using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelManagement.DTO;
using HotelManagement.DAO;
namespace HotelManagement.BUS
{
    internal class CTDV_BUS
    {
        private static CTDV_BUS instance;
        // Lấy phiên bản của CTDV_BUS
        public static CTDV_BUS Instance
        {
            get { if (instance == null) instance = new CTDV_BUS(); return instance; }
            private set { instance = value; }
        }
        // Khởi tạo CTDV_BUS
        private CTDV_BUS() { }

        // Tìm chi tiết dịch vụ theo mã hóa đơn
        public List<CTDV> FindCTDV(string MaHD)
        {
            return CTDV_DAO.Instance.FindCTDV(MaHD);
        }
        // Thêm hoặc cập nhật danh sách chi tiết dịch vụ
        public void InsertOrUpdateList(List<CTDV> cTDVs)
        {
            CTDV_DAO.Instance.InsertOrUpdateList(cTDVs);
        }
        // Tính tổng tiền dịch vụ theo mã chi tiết đặt phòng
        public decimal TinhTongTienDichVu(string maCTDP)
        {
            var list = FindCTDV(maCTDP);

            if (list == null || list.Count == 0)
                return 0;

            return list
                .Where(x => x.DaXoa == false && x.SL > 0)
                .Sum(x => x.ThanhTien);
        }
    }
}
