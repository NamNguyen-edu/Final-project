using HotelManagement.DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.DAO
{
    internal class TaiKhoanDAO
    {
        HotelDTO db = new HotelDTO();
        private static TaiKhoanDAO instance;
        public static TaiKhoanDAO Instance
        {
            get { if (instance == null) instance = new TaiKhoanDAO(); return instance; }
            private set { instance = value; }
        }
        private TaiKhoanDAO() { }
        // Kiểm tra thông tin đăng nhập
        public bool CheckLogin(string username, string password)
        {

                TaiKhoan tk = db.TaiKhoans.Where(p => p.TenTK == username && p.Password == password && p.DaXoa == false).SingleOrDefault();
                if (tk == null)
                    return false;
                return true;
            
        }
        // Kiểm tra quyền truy cập để trả về cấp độ
        public int GetQuyenTruyCap(string username)
        {

            TaiKhoan tk = db.TaiKhoans.Where(p => p.TenTK == username && p.DaXoa == false).SingleOrDefault();
                return tk.CapDoQuyen;
            
        }
        // Lấy danh sách tất cả tài khoản
        public List<TaiKhoan> GetTaiKhoans()
        {

                return db.TaiKhoans.Where(p=>p.DaXoa==false).ToList();
            
        }
        // Lấy danh sách các tài khoản với tên người dùng
        public List<TaiKhoan> GetTaiKhoansWithUserName(string username)
        {

                return db.TaiKhoans.Where(p => p.TenTK.Contains(username)).ToList();
            
        }    
        // Lấy tên tài khoản đăng nhập 
        public TaiKhoan GetTKDangNhap(string username)
        {
            HotelDTO db = new HotelDTO();
            TaiKhoan tk = db.TaiKhoans.Where(p => p.TenTK == username && p.DaXoa == false).SingleOrDefault();

            return tk;
            
        }
        // Thêm hoặc cập nhật thông tin tài khoản
        public void AddOrUpdateTK(TaiKhoan taiKhoan)
        {
            try
            {
                taiKhoan.NhanVien = db.NhanViens.Find(taiKhoan.MaNV);
                taiKhoan.DaXoa = false;
                db.TaiKhoans.AddOrUpdate(taiKhoan);
                db.SaveChanges();
                instance = null;
            }
            catch(Exception)
            {
                db.TaiKhoans.Remove(taiKhoan);
            }
            
        }
        // Xóa tài khoản
        public void RemoveTk(TaiKhoan taiKhoan)
        {

                taiKhoan.DaXoa = true; // Đổi tình trạng đã xóa của tài khoản thành True
                db.TaiKhoans.AddOrUpdate(taiKhoan);
                db.SaveChanges();
                instance = null;

        }
        // Kiểm tra việc đúng sai của việc đăng nhập
        public TaiKhoan CheckLegit(string username,string email)
        {

                return db.TaiKhoans.Where(p => p.TenTK == username && p.NhanVien.Email == email && p.DaXoa==false).SingleOrDefault();
            
        }
        
    }

}
