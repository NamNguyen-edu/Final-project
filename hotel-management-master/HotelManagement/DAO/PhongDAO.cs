using HotelManagement.DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.DAO
{
    internal class PhongDAO
    {
        HotelDTO db = new HotelDTO();
        private static PhongDAO instance;
        public static PhongDAO Instance
        {
            get { if (instance == null) instance = new PhongDAO(); return instance; }
            private set { instance = value; }
        }
        private PhongDAO() { }
        // Lấy tất cả phòng chưa bị xóa
        public List<Phong> GetAllPhongs()
        {

            return db.Phongs.Where(p => p.DaXoa == false).ToList();

        }
        // Tìm phòng theo mã (PK)
        public Phong FindPhong(string MaPh)
        {

            return db.Phongs.Find(MaPh);

        }
        // Tìm phòng theo mã, dùng LIKE (Contains)
        public List<Phong> FindPhongWithMaPH(string MaPh)
        {

            return db.Phongs.Where(p => p.MaPH.Contains(MaPh) && p.DaXoa == false).ToList();

        }
        // Thêm hoặc cập nhật phòng (set lại loại phòng, không xóa)
        public void UpdateOrAdd(Phong phong)
        {

            phong.LoaiPhong = db.LoaiPhongs.Find(phong.MaLPH);
            phong.DaXoa = false;
            db.Phongs.AddOrUpdate(phong);
            db.SaveChanges();

        }
        // Xóa mềm phòng (DaXoa = true)
        public void RemovePhong(string maPH)
        {
            Phong phong = db.Phongs.Find(maPH);
            phong.DaXoa = true;
            db.Phongs.AddOrUpdate(phong);
            db.SaveChanges();
        }
        // Tìm các phòng trống theo khoảng thời gian Check-in / Check-out
        public List<Phong> FindPhongTrong(DateTime Checkin, DateTime Checkout, List<CTDP> DSPhongThem)
        {
            List<CTDP> cTDPs = CTDP_DAO.Instance.getCTDPonTime(Checkin, Checkout, DSPhongThem).Where(p => p.TrangThai != "Đã hủy" || p.TrangThai != "Đã xong").ToList();
            var MaPh = cTDPs.Select(p => p.Phong.MaPH).ToList();
            List<Phong> phongs = db.Phongs.Where(p => p.DaXoa == false).ToList();
            List<Phong> phongtrong = new List<Phong>();
            for (int i = 0; i < phongs.Count; i++)
            {
                int flag = 0;
                foreach (CTDP cTDP in cTDPs)
                {
                    if (phongs[i].MaPH == cTDP.MaPH)
                        flag = 1;
                }
                if (flag == 0)
                {
                    phongtrong.Add(phongs[i]);
                }
            }
            return phongtrong;

        }
        // Kiểm tra 1 phòng cụ thể có trống trong khoảng CheckIn/CheckOut hay không
        public bool FindPhongTrong(CTDP room)
        {

            List<CTDP> cTDPs = CTDP_DAO.Instance.getCTDPonTime(room.CheckIn, room.CheckOut, null);
            var MaPh = cTDPs.Select(p => p.Phong.MaPH).ToList();
            List<Phong> phongs = db.Phongs.Where(p => p.TTDD != "Đang sửa chữa").ToList();
            List<Phong> phongtrong = new List<Phong>();
            for (int i = 0; i < phongs.Count; i++)
            {
                int flag = 0;
                foreach (CTDP cTDP in cTDPs)
                {
                    if (phongs[i].MaPH == cTDP.MaPH)
                        flag = 1;
                }
                if (flag == 0)
                {
                    phongtrong.Add(phongs[i]);
                }
            }
            foreach (Phong phong in phongtrong)
            {
                if (phong.MaPH == room.MaPH)
                    return true;
            }
            return false;

        }
        // Sinh mã phòng mới theo tầng (P201, P202,...)
        public string GenerateNextRoomCode(int tang)
        {
            var codes = db.Phongs
                          .Where(p => p.Tang == tang && p.DaXoa == false)
                          .Select(p => p.MaPH)
                          .ToList();

            int maxNum = tang * 100;
            foreach (var c in codes)
            {
                if (c != null && c.Length >= 4 && int.TryParse(c.Substring(1), out var n))
                {
                    if (n / 100 == tang && n > maxNum) maxNum = n;
                }
            }

            int next = (maxNum % 100) + 1;   // số thứ tự kế tiếp trong tầng
            int num = tang * 100 + next;    // VD: tầng 2 → 200 + 1 = 201
            return "P" + num.ToString("000"); // "P201"
        }

    }
}