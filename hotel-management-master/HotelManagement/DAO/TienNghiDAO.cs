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
        HotelDTO db = new HotelDTO();
        private static TienNghiDAO instance;
        public static TienNghiDAO Instance
        {
            get { if (instance == null) instance = new TienNghiDAO(); return instance; }
            private set { instance = value; }
        }
        private TienNghiDAO() { }

        public List<TienNghi> GetTienNghis()
        {

            // Lấy danh sách tiện nghi chưa xóa
            var tns = db.TienNghis.Where(p => p.DaXoa == false).ToList();

            // Lấy toàn bộ CTTN chưa xóa (để đỡ query nhiều lần)
            var cttns = db.CTTNs.Where(p => p.DaXoa == false).ToList();

            foreach (var tn in tns)
            {
                // Tổng SL của tiện nghi này trong tất cả CTTN
                tn.SoLuong = cttns
                    .Where(c => c.MaTN == tn.MaTN)
                    .Sum(c => (int?)c.SL) ?? 0;
            }

            return tns;

        }
        // Tìm tiện nghi theo mã 
        public TienNghi FindTienNghi(string MaTN)
        {
            return db.TienNghis.Find(MaTN);

        }
        public void RemoveTN(TienNghi tienNghi) // try catch th có phòng có mã tiện nghi đó
        {

            try
            {
                tienNghi.DaXoa = true;

                db.TienNghis.AddOrUpdate(tienNghi);
                db.SaveChanges();
            }
            catch (Exception)
            {
                db.TienNghis.Remove(tienNghi);
                return;
            }
            List<CTTN> cTTNs = db.CTTNs.ToList();
            foreach (CTTN cTTN in cTTNs.Where(p => p.MaTN == tienNghi.MaTN).ToList())
            {
                cTTN.DaXoa = true;
            }
            db.SaveChanges();
        }
        // Thêm hoặc cập nhật tiện nghi
        public void InsertOrUpdate(TienNghi tienNghi)
        {

            tienNghi.DaXoa = false;
            db.TienNghis.AddOrUpdate(tienNghi);
            db.SaveChanges();

        }
        // Tìm tiện nghi với tên tiện nghi 
        public List<TienNghi> FindTienNghiWithName(string name)
        {

            return db.TienNghis.Where(p => p.TenTN.Contains(name) && p.DaXoa == false).ToList();

        }
        // Lấy mã tiện nghi tiếp theo
        public string GetMaTNNext()
        {


            List<TienNghi> TN = db.TienNghis.ToList();
            string MaMax = TN[TN.Count - 1].MaTN.ToString();
            MaMax = MaMax.Substring(MaMax.Length - 3, 3); // Lấy mã tiện nghi lớn nhất
            int max = int.Parse(MaMax); 
            max++;
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