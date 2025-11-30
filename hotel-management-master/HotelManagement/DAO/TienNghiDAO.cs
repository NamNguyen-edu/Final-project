using HotelManagement.DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.DAO
{
    internal class TienNghiDAO
    {
        // Ngữ cảnh Entity Framework làm việc với CSDL
        HotelDTO db = new HotelDTO();

        // Biến singleton cho lớp TienNghiDAO
        private static TienNghiDAO instance;

        // Thuộc tính singleton, đảm bảo chỉ có một đối tượng TienNghiDAO duy nhất
        public static TienNghiDAO Instance
        {
            get { if (instance == null) instance = new TienNghiDAO(); return instance; }
            private set { instance = value; }
        }

        // Hàm khởi tạo private, chỉ được gọi nội bộ thông qua Instance
        private TienNghiDAO() { }

        // Lấy danh sách tiện nghi chưa bị xóa và tính tổng số lượng từ các chi tiết tiện nghi (CTTN)
        public List<TienNghi> GetTienNghis()
        {
            // Lấy danh sách tiện nghi chưa xóa
            var tns = db.TienNghis.Where(p => p.DaXoa == false).ToList();

            // Lấy toàn bộ CTTN chưa xóa (để hạn chế số lượng truy vấn)
            var cttns = db.CTTNs.Where(p => p.DaXoa == false).ToList();

            foreach (var tn in tns)
            {
                // Tổng số lượng của tiện nghi này trong tất cả CTTN
                tn.SoLuong = cttns
                    .Where(c => c.MaTN == tn.MaTN)
                    .Sum(c => (int?)c.SL) ?? 0;
            }

            return tns;
        }

        // Tìm một tiện nghi theo mã tiện nghi (MaTN)
        public TienNghi FindTienNghi(string MaTN)
        {
            return db.TienNghis.Find(MaTN);
        }

        // Xóa tiện nghi (xóa mềm bằng DaXoa, nếu lỗi thì xóa cứng), đồng thời đánh dấu xóa các CTTN liên quan
        public void RemoveTN(TienNghi tienNghi) // try catch trường hợp có phòng đang dùng mã tiện nghi đó
        {
            try
            {
                tienNghi.DaXoa = true;

                db.TienNghis.AddOrUpdate(tienNghi);
                db.SaveChanges();
            }
            catch (Exception)
            {
                // Nếu không xóa mềm được (vướng ràng buộc), xóa trực tiếp bản ghi tiện nghi
                db.TienNghis.Remove(tienNghi);
                return;
            }

            // Sau khi xóa tiện nghi, đánh dấu xóa tất cả chi tiết tiện nghi (CTTN) liên quan
            List<CTTN> cTTNs = db.CTTNs.ToList();
            foreach (CTTN cTTN in cTTNs.Where(p => p.MaTN == tienNghi.MaTN).ToList())
            {
                cTTN.DaXoa = true;
            }
            db.SaveChanges();
        }

        // Thêm mới hoặc cập nhật tiện nghi, luôn đặt DaXoa = false (không bị xóa)
        public void InsertOrUpdate(TienNghi tienNghi)
        {
            tienNghi.DaXoa = false;
            db.TienNghis.AddOrUpdate(tienNghi);
            db.SaveChanges();
        }

        // Tìm danh sách tiện nghi theo tên (TenTN) và chưa bị xóa
        public List<TienNghi> FindTienNghiWithName(string name)
        {
            return db.TienNghis
                     .Where(p => p.TenTN.Contains(name) && p.DaXoa == false)
                     .ToList();
        }

        // Sinh mã tiện nghi kế tiếp theo định dạng TNxxx
        public string GetMaTNNext()
        {
            List<TienNghi> TN = db.TienNghis.ToList();

            // Lấy mã tiện nghi cuối cùng
            string MaMax = TN[TN.Count - 1].MaTN.ToString();

            // Lấy 3 ký tự số cuối cùng
            MaMax = MaMax.Substring(MaMax.Length - 3, 3);
            int max = int.Parse(MaMax);
            max++;

            // Ghép tiền tố TN và số thứ tự với đủ 3 chữ số
            if (max < 10)
            {
                return "TN00" + max.ToString();
            }
            else if (max < 100)
            {
                return "TN0" + max.ToString();
            }
            return "TN" + max.ToString();
        }
    }
}
