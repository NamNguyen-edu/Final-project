using HotelManagement.DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.DAO
{

    internal class CTDV_DAO
    {
        HotelDTO db = new HotelDTO();
        private static CTDV_DAO instance;
        public static CTDV_DAO Instance
        {
            get { if (instance == null) instance = new CTDV_DAO(); return instance; }
            private set { instance = value; }
        }
        private CTDV_DAO() { }
        // Tìm các dịch vụ đã được thêm vào lượt đặt phòng hiện tại
        public List<CTDV> FindCTDV(string MaCTDP)
        {

                return db.CTDVs.Where(p => p.MaCTDP == MaCTDP && p.DaXoa == false).ToList();           
        } 
        
        public void InsertOrUpdateList(List<CTDV> cTDVs)
        {
            using (HotelDTO db = new HotelDTO())
            {
                foreach (var item in cTDVs)
                {
                    // Nếu SL = 0 → xóa bản ghi
                    if (item.SL == 0)
                    {
                        var toDelete = db.CTDVs
                            .FirstOrDefault(p => p.MaDV == item.MaDV && p.MaCTDP == item.MaCTDP);

                        if (toDelete != null)
                            db.CTDVs.Remove(toDelete);
                    }
                    else
                    {
                        // SL > 0 → thêm hoặc cập nhật
                        db.CTDVs.AddOrUpdate(item);
                    }
                }

                db.SaveChanges();
            }
            db.Dispose();
            instance = null;
        }    

    }
}
