using HotelManagement.DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HotelManagement.CTControls;

namespace HotelManagement.DAO
{
    internal class KhachHangDAO
    {
        // Ngữ cảnh Entity Framework làm việc với CSDL
        private HotelDTO db = new HotelDTO();

        // Biến singleton cho KhachHangDAO
        private static KhachHangDAO instance;

        // Thuộc tính singleton, đảm bảo chỉ có một instance KhachHangDAO
        public static KhachHangDAO Instance
        {
            get { if (instance == null) { instance = new KhachHangDAO(); }; return instance; }
            private set { instance = value; }
        }
        // Hàm khởi tạo private, chỉ được gọi nội bộ qua singleton
        private KhachHangDAO() { db = new HotelDTO(); }
        // Lấy danh sách khách hàng chưa bị xóa (DaXoa = false)
        public List<KhachHang> GetKhachHangs()
        {
            return db.KhachHangs.Where(p => p.DaXoa == false).ToList();
        }
        // Tìm một khách hàng theo mã khách hàng (MaKH)
        public KhachHang FindKhachHang(string MaKH)
        {
            return db.KhachHangs.Find(MaKH);
        }
        // Thêm mới hoặc cập nhật thông tin khách hàng, đồng thời đảm bảo cờ DaXoa = false
        public void UpdateOrAdd(KhachHang khachHang)
        {
            try
            {
                khachHang.DaXoa = false;
                db.KhachHangs.AddOrUpdate(khachHang);
                db.SaveChanges();

                // Reset instance để đảm bảo dữ liệu mới được load lại ở lần sử dụng sau
                instance = null;
            }
            catch (DbEntityValidationException ex)
            {
                CTMessageBox.Show(ex.Message);
            }
        }
        // Xóa mềm khách hàng: chỉ gán DaXoa = true, không xóa bản ghi khỏi CSDL
        public void RemoveKH(KhachHang khachHang)
        {
            khachHang.DaXoa = true;
            db.KhachHangs.AddOrUpdate(khachHang);
            db.SaveChanges();
        }
        // Tìm danh sách khách hàng theo tên (chứa chuỗi TenKH) và chưa bị xóa
        public List<KhachHang> FindKhachHangWithName(string TenKH)
        {
            return db.KhachHangs
                     .Where(p => p.TenKH.Contains(TenKH) && p.DaXoa == false)
                     .ToList();
        }
        // Sinh mã khách hàng tiếp theo dựa trên mã lớn nhất hiện có (định dạng KHxxx)
        public string GetMaKHNext()
        {
            List<KhachHang> KH = db.KhachHangs.ToList();

            string MaMax = KH[KH.Count - 1].MaKH.ToString();

            MaMax = MaMax.Substring(MaMax.Length - 3, 3);
            int max = int.Parse(MaMax);
            max++;
            if (max < 10)
            {
                return "KH00" + max.ToString();
            }
            else if (max < 100)
            {
                return "KH0" + max.ToString();
            }
            return "KH" + max.ToString();
        }
        // Tìm khách hàng theo số CCCD/Passport
        public KhachHang FindKHWithCCCD(string cccd)
        {
            return db.KhachHangs
                     .Where(p => p.CCCD_Passport == cccd)
                     .SingleOrDefault();
        }
        // Tìm khách hàng theo Email (tạo mới context cục bộ để truy vấn)
        public KhachHang FindKHWithEmail(string email)
        {
            using (HotelDTO db = new HotelDTO())
            {
                return db.KhachHangs.FirstOrDefault(k => k.Email == email);
            }
        }
    }
}
