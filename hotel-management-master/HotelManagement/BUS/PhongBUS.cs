using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelManagement.DTO;
using HotelManagement.DAO;

namespace HotelManagement.BUS
{
    internal class PhongBUS
    {
        private static PhongBUS instance;
        public static PhongBUS Instance
        {
            get { if (instance == null) instance = new PhongBUS(); return instance; }
            private set { instance = value; }
        }
        private PhongBUS() { }
        // Lấy toàn bộ phòng (gọi DAO)
        public List<Phong> GetAllPhong()
        {
            return PhongDAO.Instance.GetAllPhongs();
        }
        // Tìm phòng theo mã (gọi DAO)
        public Phong FindePhong(string MaPh)
        {
            return PhongDAO.Instance.FindPhong(MaPh);
        }
        // Tìm phòng theo mã (LIKE MaPH%) – chức năng tìm kiếm
        public List<Phong> FindPhongWithMaPH(string MaPh)
        {
            return PhongDAO.Instance.FindPhongWithMaPH(MaPh);
        }
        // Thêm hoặc cập nhật phòng (gọi DAO xử lý)
        public void UpdateOrAdd(Phong phong)
        {
            PhongDAO.Instance.UpdateOrAdd(phong);
        }
        // Tìm danh sách phòng trống theo khoảng thời gian
        public List<Phong> FindPhongTrong(DateTime Checkin, DateTime Checkout, List<CTDP> DSPhongThem)
        {
            return PhongDAO.Instance.FindPhongTrong(Checkin, Checkout, DSPhongThem);
        }
        // Xóa phòng (xóa mềm) – gọi DAO
        public void RemovePhong(string maPH)
        {
            PhongDAO.Instance.RemovePhong(maPH);
        }
        // Sinh mã phòng mới dựa theo tầng (P201, P305, ...)
        public string GenerateNextRoomCode(int tang)
        {
            return PhongDAO.Instance.GenerateNextRoomCode(tang);
        }
    }
}


