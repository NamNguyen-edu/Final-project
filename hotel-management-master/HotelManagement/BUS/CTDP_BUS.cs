using HotelManagement.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelManagement.DAO;
namespace HotelManagement.BUS
{
    internal class CTDP_BUS
    {
        private static CTDP_BUS instance;
        public static CTDP_BUS Instance
        {
            get { if (instance == null) instance = new CTDP_BUS(); return instance; }
            private set { instance = value; }
        }
        private CTDP_BUS() { }
        // Lấy tất cả CTDP
        public List<CTDP> GetCTDPs() // Lấy tất cả CTDP
        {
            return CTDP_DAO.Instance.GetCTDPs();
        }
        // Lấy thời gian ở của khách hàng tại 1 phòng nào đó
        public int getKhoangTGTheoNgay(string MaCTDP)
        {
            return CTDP_DAO.Instance.getKhoangTGTheoNgay(MaCTDP);
        }
        // Lấy thời gian ở của khách hàng tại 1 phòng nào đó
        public int getKhoangTGTheoGio(string MaCTDP)
        {
            return CTDP_DAO.Instance.getKhoangTGTheoGio(MaCTDP);
        }
        // Tìm chi tiết đặt phòng theo mã phòng và thời gian hiện tại
        public CTDP FindCTDP(string MaPhong, DateTime currentTime) 
        {
            return CTDP_DAO.Instance.FindCTDP(MaPhong, currentTime);
        }
        // Lấy danh sách CTDP trong khoảng thời gian
        public List<CTDP> getCTDPonTime(DateTime Checkin, DateTime Checkout, List<CTDP> DSPhongThem)
        {
            return CTDP_DAO.Instance.getCTDPonTime(Checkin, Checkout, DSPhongThem);
        }
        // Lấy mã CTDP tiếp theo
        public string getNextCTDP()
        {
            return CTDP_DAO.Instance.getNextCTDP();
        }
        // Cập nhật hoặc thêm CTDP
        public void UpdateOrAddCTDP(CTDP ctdp)
        {
            CTDP_DAO.Instance.UpdateOrAddCTDP(ctdp);
        }
        // Lấy mã CTDP tiếp theo với danh sách truyền vào
        public string getNextCTDPwithList(List<CTDP> list)
        {
            return CTDP_DAO.Instance.getNextCTDPwithList(list);
        }
        // Xóa CTDP
        public void RemoveCTDP(CTDP cTDP)
        {
            CTDP_DAO.Instance.RemoveCTDP(cTDP);
        }
        // Kiểm tra xem có đặt phòng trong tương lai cho phòng không
        public bool HasFutureBookingForRoom(string maPhong, DateTime now)
        {
            return CTDP_DAO.Instance.HasFutureBookingForRoom(maPhong, now);
        }
        // Cập nhật trạng thái quá hạn
        public void UpdateTrangThaiQuaHan(DateTime now)
        {
            CTDP_DAO.Instance.UpdateTrangThaiQuaHan(now);
        }
    }
}
