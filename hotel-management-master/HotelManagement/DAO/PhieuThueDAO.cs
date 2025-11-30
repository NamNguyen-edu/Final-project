using HotelManagement.CTControls;
using HotelManagement.DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Data.Entity.Validation;
using System.Linq;
using System.Windows.Forms;

namespace HotelManagement.DAO
{
    internal class PhieuThueDAO
    {
        // Biến singleton cho lớp PhieuThueDAO
        private static PhieuThueDAO instance;

        // Thuộc tính singleton, đảm bảo chỉ có một đối tượng PhieuThueDAO duy nhất
        public static PhieuThueDAO Instance
        {
            get { if (instance == null) instance = new PhieuThueDAO(); return instance; }
            private set { instance = value; }
        }

        // Hàm khởi tạo private, chỉ được gọi nội bộ thông qua thuộc tính Instance
        private PhieuThueDAO() { }

        // Lấy toàn bộ danh sách phiếu thuê, luôn tạo context mới và Include Khách hàng, Nhân viên
        public List<PhieuThue> GetPhieuThues()
        {
            using (var db = new HotelDTO())
            {
                return db.PhieuThues
                         .Include("KhachHang")
                         .Include("NhanVien")
                         .ToList();
            }
        }

        // Lấy thông tin một phiếu thuê theo mã (MaPT), luôn lấy mới từ CSDL
        public PhieuThue GetPhieuThue(string MaPT)
        {
            using (var db = new HotelDTO())
            {
                return db.PhieuThues
                         .Include("KhachHang")
                         .Include("NhanVien")
                         .SingleOrDefault(p => p.MaPT == MaPT);
            }
        }

        // Cập nhật hoặc thêm mới phiếu thuê, đảm bảo thông tin Khách hàng và Nhân viên được load mới
        public void UpdatePhieuThue(PhieuThue phieuThue)
        {
            try
            {
                using (var db = new HotelDTO())
                {
                    phieuThue.DaXoa = false;

                    // Gán lại điều hướng đến Khách hàng và Nhân viên từ context hiện tại
                    phieuThue.KhachHang = db.KhachHangs.Find(phieuThue.MaKH);
                    phieuThue.NhanVien = db.NhanViens.Find(phieuThue.MaNV);
                    db.PhieuThues.AddOrUpdate(phieuThue);
                    db.SaveChanges();
                }
            }
            catch (DbEntityValidationException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Tìm danh sách phiếu thuê theo tên khách hàng (lọc theo TenKH)
        public List<PhieuThue> GetPhieuThuesWithNameCus(string name)
        {
            using (var db = new HotelDTO())
            {
                return db.PhieuThues
                         .Include("KhachHang")
                         .Include("NhanVien")
                         .Where(p => p.KhachHang.TenKH.Contains(name))
                         .ToList();
            }
        }

        // Sinh mã phiếu thuê kế tiếp theo định dạng PTxxx
        public string GetMaPTNext()
        {
            using (var db = new HotelDTO())
            {
                var list = db.PhieuThues.ToList();
                if (list.Count == 0) return "PT001";
                string MaMax = list[list.Count - 1].MaPT;
                int num = int.Parse(MaMax.Substring(2));
                num++;
                return "PT" + num.ToString("000");
            }
        }

        // Xóa toàn bộ phiếu thuê theo danh sách truyền vào (xóa cứng trong CSDL)
        public void RemoveAllPhieuThueWithMaKH(List<PhieuThue> phieuThues)
        {
            using (var db = new HotelDTO())
            {
                if (phieuThues != null)
                {
                    foreach (var pt in phieuThues)
                    {
                        var fresh = db.PhieuThues.Find(pt.MaPT);
                        if (fresh != null)
                            db.PhieuThues.Remove(fresh);
                    }
                }
                db.SaveChanges();
            }
        }
    }
}
