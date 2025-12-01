using HotelManagement.DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.DAO
{
    internal class NhanVienDAO
    {
        HotelDTO db = new HotelDTO();
        private static NhanVienDAO instance;
        public static NhanVienDAO Instance
        {
            get { if (instance == null) instance = new NhanVienDAO(); return instance; }
            private set { instance = value; }
        }
        private NhanVienDAO() { }
        // Lấy toàn bộ nhân viên (trả về cả nhân viên đã xóa)
        public List<NhanVien> GetAllNhanViens()
        {
            return db.NhanViens.ToList();
        }
        // Lấy toàn bộ nhân viên (không trả về nhân viên đã xóa)
        public List<NhanVien> GetNhanViens()
        {
            return db.NhanViens.Where(p => p.DaXoa == false).ToList();
        }
        // Lấy nhân viên theo mã nhân viên
        public NhanVien GetNhanVien(string MaNV)
        {
            return db.NhanViens.Find(MaNV);
        }
        // Thêm hoặc cập nhật nhân viên với các điều kiện kiểm tra
        public void UpdateOrInsert(NhanVien nhanVien)
        {
            int age = DateTime.Now.Year - nhanVien.NgaySinh.Year;
            if (nhanVien.NgaySinh > DateTime.Now.AddYears(-age))
            {
                age--; 
            }
            if (age < 18)
            {
                throw new Exception("Nhân viên phải từ 18 tuổi trở lên.");
            }
            if (nhanVien.SDT.Length != 10)
            {
                throw new Exception("Số điện thoại phải đúng 10 chữ số.");
            }
            if (nhanVien.CCCD.Length != 12)
            {
                throw new Exception("CCCD phải đúng 12 chữ số.");
            }
            if (!nhanVien.Email.Contains("@") || !nhanVien.Email.Contains((".")))
            {
                throw new Exception("Email không hợp lệ.");
            }
            nhanVien.DaXoa = false;
            db.NhanViens.AddOrUpdate(nhanVien);
            db.SaveChanges();
        }
        // Xóa mềm nhân viên (gán DaXoa = true)
        public void RemoveNhanVien(NhanVien nhanVien)
        {
            nhanVien.DaXoa = true;
            db.NhanViens.AddOrUpdate(nhanVien);
            db.SaveChanges();
        }
        // Tìm nhân viên theo tên (không trả về nhân viên đã xóa)
        public List<NhanVien> GetNhanViensWithName(string tenNV)
        {
            return db.NhanViens.Where(p => p.TenNV.Contains(tenNV) && p.DaXoa == false).ToList();
        }
        // Sinh mã nhân viên tiếp theo (NV001 → NV002 )
        public string GetMaNVNext()
        {
            List<NhanVien> NV = db.NhanViens.Where(p => p.MaNV.Contains("NV")).ToList();
            string MaMax = NV[NV.Count - 1].MaNV;
            MaMax = MaMax.Substring(MaMax.Length - 3, 3);
            int max = int.Parse(MaMax);
            max++;
            if (max < 10)
            {
                return "NV00" + max.ToString();
            }
            else if (max < 100)
            {
                return "NV0" + max.ToString();
            }
            return "NV" + max.ToString();
       }
        public List<NhanVien> FindNhanVienWithName(string TenNV)
        {
            return db.NhanViens.Where(p => p.TenNV.Contains(TenNV) && p.DaXoa == false).ToList();
        }
    }
}
