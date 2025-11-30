using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelManagement.DAO;
using HotelManagement.DTO;

namespace HotelManagement.BUS
{
    internal class TaiKhoanBUS
    {
        private static TaiKhoanBUS instance;
        public static TaiKhoanBUS Instance
        {
            get { if (instance == null) instance = new TaiKhoanBUS(); return instance; }
            private set { instance = value; }
        }
        private TaiKhoanBUS() { }
        // Kiểm tra đăng nhập
        public bool checkLogin(string username, string password)
        {
            return TaiKhoanDAO.Instance.CheckLogin(username, password);
        }
        // Lấy quyền truy cập của tài khoản
        public int getQuyenTruyCap(string username)
        {
            return TaiKhoanDAO.Instance.GetQuyenTruyCap(username);
        }
        // Lấy danh sách tất cả tài khoản
        public List<TaiKhoan> GetTaiKhoans()
        {
            return TaiKhoanDAO.Instance.GetTaiKhoans();
        }
        // Lấy tài khoản theo tên 
        public List<TaiKhoan> GetTaiKhoansWithUserName(string username)
        {
            return TaiKhoanDAO.Instance.GetTaiKhoansWithUserName(username);
        }
        // Kiểm tra tài khoản đăng nhập
        public TaiKhoan CheckLegit(string username, string email)
        {
            return TaiKhoanDAO.Instance.CheckLegit(username, email);
        }
        // Thêm hoặc cập nhật tài khoản
        public void AddOrUpdateTK(TaiKhoan taiKhoan)
        {
            TaiKhoanDAO.Instance.AddOrUpdateTK(taiKhoan);
        }
        // Xóa tài khoản
        public void RemoveTk(TaiKhoan taiKhoan)
        {
            TaiKhoanDAO.Instance.RemoveTk(taiKhoan);
        }
        // Lấy tài khoản từ DAO
        public TaiKhoan GetTKDangNhap(string username)
        {
            return TaiKhoanDAO.Instance.GetTKDangNhap(username);
        }
    }
}
