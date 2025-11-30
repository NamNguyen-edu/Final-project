using HotelManagement.DTO;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.DAO
{
    internal class DichVuDAO
    {
        HotelDTO db = new HotelDTO();
        private static DichVuDAO instance;
        public static DichVuDAO Instance
        {
            get { if (instance == null) instance = new DichVuDAO(); return instance; }
            private set { instance = value; }
        }
        private DichVuDAO() { }
        // Lấy tất cả dịch vụ không bị xóa
        public List<DichVu> GetDichVus()
        {
            instance = null;
            return db.DichVus.Where(p => p.DaXoa == false).ToList();

        }
        // Tìm dịch vụ theo mã 
        public DichVu FindDichVu(string MaDV)
        {
            using (HotelDTO hotelDTO = new HotelDTO())
            {
                return hotelDTO.DichVus.Find(MaDV);
            }

        }
        // Thêm hoặc cập nhật 
        public void UpdateORAdd(DichVu dv)
        {
            string error;
            if (!ValidateDonGia(dv, out error))
                throw new Exception(error);
            if (!ValidateSoLuong(dv, out error))
                throw new Exception(error);
            try 
            {
                dv.DaXoa = false; // Để trạng thái 
                db.DichVus.AddOrUpdate(dv);
                db.SaveChanges();
                instance = null;
            }
            catch (Exception ex )
            {
                throw new Exception(ex.Message);
            }

        }
        // Xử lý việc xóa dịch vụ
        public void RemoveDV(DichVu dv)
        {
            try
            {
                dv.DaXoa = true; // Để trạng thái Đã xóa của dịch vụ thành True
                db.DichVus.AddOrUpdate(dv);
                db.SaveChanges();
                instance = null;
            }
            catch (Exception)
            {
                db.DichVus.Remove(dv);
            }

        }
        // Gán mã dịch vụ tiếp theo
        public string GetMaDVNext()
        {

            List<DichVu> DV = db.DichVus.ToList();
            string MaMax = DV[DV.Count - 1].MaDV.ToString();
            MaMax = MaMax.Substring(MaMax.Length - 2, 2); // Tìm mã dịch vụ lớn nhất
            int max = int.Parse(MaMax);
            max++;
            if (max < 10)
            {
                return "DV0" + max.ToString();
            }
            return "DV" + max.ToString();

        }
        // Tìm dịch vụ theo tên
        public List<DichVu> FindDichVuWithName(string TenDV)
        {

            return db.DichVus.Where(p => p.TenDV.Contains(TenDV) && p.DaXoa == false).ToList();

        }
        // Lấy số lượng các dịch vụ còn lại
        public List<DichVu> GetDichVusConLai()
        {
            return db.DichVus.Where(p => p.DaXoa == false && p.SLConLai != 0).ToList();
        }
        // Tìm dịch vụ theo tên và đơn giá
        public DichVu FindDichVuWithNameAndDonGia(string TenDV, string DonGia)
        {
            decimal dongia = decimal.Parse(DonGia);
            return db.DichVus.Where(p => p.TenDV == TenDV && p.DonGia == dongia).SingleOrDefault();
        }
        // Thêm dịch vụ
        public void UpdateDV(List<DichVu> dichVus)
        {
            try
            {
                foreach (DichVu dichVu in dichVus)
                {
                    db.DichVus.AddOrUpdate(dichVu);
                }
                db.SaveChanges();
                instance = null;
            }
            catch (Exception)
            {
                foreach (DichVu dichVu in dichVus)
                {
                    db.DichVus.Remove(dichVu);
                }
            }
        }
        // Kiểm tra giá dịch vụ được nhập vào
        public bool ValidateDonGia(DichVu dv, out string error)
        {
            error = ""; // Khai báo chuỗi giá trị để đưa lỗi về

            if (dv.DonGia < 1000) // Nếu giá dịch vụ dưới 1.000 đồng
            {
                error = "Đơn giá phải từ 1.000 đồng trở lên.";
                return false;
            }

            return true;
        }
        // Kiểm tra số lượng dịch vụ nhập vào khi thêm hoặc sửa chi tiết dịch vụ
        public bool ValidateSoLuong(DichVu dv, out string error)
        {
            error = "";

            if (dv.SLConLai == null) //Nếu số lượng được sửa bị để trống
            {
                error = "Số lượng không hợp lệ.";
                return false;
            }

            if (dv.SLConLai < 0) // Nếu số lượng được sửa nhỏ hơn 0
            {
                error = "Số lượng dịch vụ không được nhỏ hơn 0.";
                return false;
            }

            return true;
        }
    }
}
