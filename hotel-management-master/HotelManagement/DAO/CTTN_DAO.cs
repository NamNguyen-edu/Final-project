using HotelManagement.DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.DAO
{
    internal class CTTN_DAO
    {
        HotelDTO db = new HotelDTO();
        private static CTTN_DAO instance;
        public static CTTN_DAO Instance
        {
            get { if (instance == null) instance = new CTTN_DAO(); return instance; }
            private set { instance = value; }
        }
        private CTTN_DAO() { }
        // Lấy tất cả chi tiết tiện nghi
        public List<CTTN> GetCTTNs()
        {
                return db.CTTNs.Where(p => p.DaXoa == false).ToList();          
        }
        // Xử lý thêm hoặc cập nhật các chi tiết tiện nghi
        public void UpdateOrInsert(CTTN cTTN)
        {
            try
            {
                cTTN.DaXoa = false;
                cTTN.TienNghi = db.TienNghis.Find(cTTN.MaTN);               
                db.CTTNs.AddOrUpdate(cTTN);
                db.SaveChanges();
                instance = null;
            }
            catch(Exception)
            {
                db.CTTNs.Remove(cTTN);
            }
        }
        // Xử lý xóa chi tiết tiện nghi
        public void RemoveCTTN(CTTN cTTN)
        {
            try
            {
                cTTN.DaXoa = true;
                db.CTTNs.AddOrUpdate(cTTN);
                db.SaveChanges();
                instance = null;
            }
            catch (Exception)
            {
                db.CTTNs.Remove(cTTN);
            }

        }
        // Tìm chi tiết tiện nghi theo mã loại phòng
        public List<CTTN> FindCTTN(string MaLPH)
        {
                return db.CTTNs.Where(p => p.MaLPH == MaLPH && p.DaXoa == false).ToList();          
        }
    }
}
